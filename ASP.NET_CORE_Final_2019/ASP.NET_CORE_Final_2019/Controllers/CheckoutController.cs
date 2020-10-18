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

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CheckoutController : ChaController
    {
        public readonly IKhachHang _KhachHang;
        //public readonly IFDonHang _Donhang;
        public readonly IDonHang _DonhangAdmin;
        public IConfiguration _configuration { get; }
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

        [Route("Checkout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutSum sum)
        {
            if (_KhachHang.GetKhachHang(sum.khachhang.Email) != null)
            {
                _KhachHang.UpdateKhachHang(sum.khachhang);
            }
            _KhachHang.AddKhachHang(sum.khachhang, HttpContext.Session.GetInt32("Id"));
            _Donhang.UpdatePhuongThuc(HttpContext.Session.GetInt32("Id"), sum.PhuongThucThanhToan);

            if(sum.PhuongThucThanhToan == "Thanh Toán Khi Nhận Hàng") {

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
            else if(sum.PhuongThucThanhToan =="PayPal")
            {
                Double summ = 0;
                var PayPalAPI = new PayPalAPI(_configuration);
                var itemList = new ItemList()
                {
                    Items = new List<Item>()
                };
                IEnumerable<Chitietdonhang> a = _DonhangAdmin.GetChitietdonhang((int)HttpContext.Session.GetInt32("Id"));
                foreach(var item in a)
                {
                    Decimal soluong = 0;
                    string des = "";
                    Sanpham sp = _Sanpham.GetSanPham(item.IdSanPham);
                    if(sp.IdLoaiSanPham == 4)
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
                        Currency ="USD",
                        Price =  Math.Round(((Decimal)item.Gia/23000/soluong),2).ToString(),
                        Quantity = soluong.ToString(),
                        Description = des
                    });
 
                }
                foreach (var item in itemList.Items)
                {
                    Debug.WriteLine(item.Name + " " + item.Quantity +" " + item.Price); // debug log
                    summ = summ + Math.Round((double.Parse(item.Price) * double.Parse(item.Quantity)),2);
                }
                
                Debug.WriteLine(summ); // debug log
                string URL = await PayPalAPI.getRedirectURLtoPayPal(summ, "USD", itemList);
                return Redirect(URL);
            }
            return null;
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