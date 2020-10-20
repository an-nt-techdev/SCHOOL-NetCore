using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;
using System.Diagnostics;
using ASP.NET_CORE_Final_2019.PayPalHelper;
using Microsoft.Extensions.Configuration;
using PayPal.v1.Payments;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CheckoutController : ChaController
    {
        public readonly IKhachHang _KhachHang;
        //public readonly IFDonHang _Donhang;
        public readonly IDonHang _DonhangAdmin;
        public IConfiguration _configuration { get; }
        public string AuthyAPIKey = "tgDxCGfgDsoz0zwFf39dWCUkLuvL3Lm1";
        public CheckoutController(IFSanpham _IFSanpham, IFDonHang _IFDonhang, IKhachHang _IKhachHang, IConfiguration _Iconfiguration, IDonHang _IDonhang) : base(_IFSanpham, _IFDonhang)
        {
            _KhachHang = _IKhachHang;
            //_Donhang = _IFDonhang;
            _configuration = _Iconfiguration;
            _DonhangAdmin = _IDonhang;
        }

        [Route("Checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            getSession();
            return View();
        }
        [Route("CheckCode")]
        [HttpPost]
        public IActionResult CheckCode(CheckoutSum sum)
        {
            //test send SMS code

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Authy-API-Key", AuthyAPIKey);

                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("via", "sms"),
                new KeyValuePair<string, string>("phone_number", sum.khachhang.Sdt.ToString()),
                new KeyValuePair<string, string>("locale", "vi"),
                new KeyValuePair<string, string>("code_length", "6"),
                new KeyValuePair<string, string>("country_code", "84"),
            });

                HttpResponseMessage response = client.PostAsync(
                    "https://api.authy.com/protected/json/phones/verification/start",
                    requestContent).Result;

                HttpContent responseContent = response.Content;
                Console.WriteLine(responseContent.ReadAsStringAsync().Result);
            }
            return View(sum);
        }

        [Route("VerifyCode")]
        [HttpPost]
        public async Task<IActionResult> VerifyCode(CheckoutSum sum, String code)
        {

            var client = new HttpClient();

            // Add authentication header
            client.DefaultRequestHeaders.Add("X-Authy-API-Key", AuthyAPIKey);

            // https://api.authy.com/protected/json/phones/verification/check?phone_number=$USER_PHONE&country_code=$USER_COUNTRY&verification_code=$VERIFY_CODE
            var api = "https://api.authy.com/protected/json/phones/verification/check?phone_number=" + sum.khachhang.Sdt + "&country_code=84&verification_code=" + code;
            HttpResponseMessage response = await client.GetAsync(api);

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.

                var result = await reader.ReadToEndAsync();
                result = @"[" + result + "]";
                Debug.WriteLine(result);
                dynamic blogPosts = JArray.Parse(result);

                dynamic blogPost = blogPosts[0];
                string isTrue = blogPost.success;
                if(isTrue == "True")
                {
                    TempData["sum"] = JsonConvert.SerializeObject(sum);
                    return RedirectToAction("VerifySuccess");
                }
                else
                {
                    return null;
                }
            }
        }
        [Route("VerifySuccess")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifySuccess()
        {
            CheckoutSum sum = JsonConvert.DeserializeObject<CheckoutSum>((string)TempData["sum"]);
            Debug.WriteLine(sum.PhuongThucThanhToan);
            if (_KhachHang.GetKhachHang(sum.khachhang.Email) != null)
            {
                _KhachHang.UpdateKhachHang(sum.khachhang);
            }
            _KhachHang.AddKhachHang(sum.khachhang, HttpContext.Session.GetInt32("Id"));
            _Donhang.UpdatePhuongThuc(HttpContext.Session.GetInt32("Id"), sum.PhuongThucThanhToan);

            if (sum.PhuongThucThanhToan == "Thanh Toán Khi Nhận Hàng")
            {

                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Bá Khoa", "tbkhoa1999@gmail.com"));
                    message.To.Add(new MailboxAddress(sum.khachhang.Ten, sum.khachhang.Email));
                    message.Subject = "Thông báo cửa hàng Khoa Rau Củ: ";
                    message.Body = new TextPart("plain")
                    {
                        Text = " Bạn đã thanh toán thành công đơn hàng có mã: " + HttpContext.Session.GetInt32("Id") + "  |  Chúng tôi sẽ tiến hành kiểm tra và giao hàng đến bạn trong thời gian ngắn nhất. Cảm ơn bạn đã tin tưởng mua hàng ở Khoa Rau Củ. LOVE!!"
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("tbkhoa1999@gmail.com", "Iamonmyway1999@10101999");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Oops! We have a problem here {ex.Message}";
                }
            } // end thanh toan khi nhan hang
            else if (sum.PhuongThucThanhToan == "PayPal")
            {
                Double summ = 0;
                var PayPalAPI = new PayPalAPI(_configuration);
                var itemList = new ItemList()
                {
                    Items = new List<Item>()
                };
                IEnumerable<Chitietdonhang> a = _DonhangAdmin.GetChitietdonhang((int)HttpContext.Session.GetInt32("Id"));
                foreach (var item in a)
                {
                    Decimal soluong = 0;
                    string des = "";
                    Sanpham sp = _Sanpham.GetSanPham(item.IdSanPham);
                    if (sp.IdLoaiSanPham == 4)
                    {
                        soluong = (Decimal)item.SoLuong;
                        des = "unit: 1 cup";
                    }
                    else
                    {
                        soluong = (Decimal)item.SoLuong / 100;
                        des = "Unit: 100 gam";
                    }
                    itemList.Items.Add(new Item()
                    {
                        Name = sp.Ten,
                        Currency = "USD",
                        Price = Math.Round(((Decimal)item.Gia / 23000 / soluong), 2).ToString(),
                        Quantity = soluong.ToString(),
                        Description = des
                    });

                }
                foreach (var item in itemList.Items)
                {
                    Debug.WriteLine(item.Name + " " + item.Quantity + " " + item.Price); // debug log
                    summ = summ + Math.Round((double.Parse(item.Price) * double.Parse(item.Quantity)), 2);
                }

                Debug.WriteLine(summ); // debug log
                string URL = await PayPalAPI.getRedirectURLtoPayPal(summ, "USD", itemList);
                return Redirect(URL);
            }
            return RedirectToAction("Start", "Cha", new { area = "" });
        }
		[Route("Checkout/Success")]
        public async Task<IActionResult> Success([FromQuery(Name = "paymentId" )] string paymentId, [FromQuery(Name = "PayerID" )] string payerId )
        {
			var PayPalAPI = new PayPalAPI(_configuration);
            var result = await PayPalAPI.executedPayment(paymentId, payerId);
			return View();
		}

        [Route("Checkout/Fail")]
        public IActionResult Fail()
        {
            return View();
        }
    }
}