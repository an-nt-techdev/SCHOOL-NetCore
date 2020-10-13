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

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CheckoutController : ChaController
    {
        public readonly IKhachHang _KhachHang;
        public readonly IFDonHang _Donhang;
        public IConfiguration _configuration { get; }
        public CheckoutController(IFSanpham _IFSanpham, IFDonHang _IFDonhang, IKhachHang _IKhachHang, IConfiguration _Iconfiguration) : base(_IFSanpham, _IFDonhang)
        {
            _KhachHang = _IKhachHang;
            _Donhang = _IFDonhang;
            _configuration = _Iconfiguration;
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
                var PayPalAPI = new PayPalAPI(_configuration);
                string URL = await PayPalAPI.getRedirectURLtoPayPal(20, "USD");
                return Redirect(URL);
            }
            return RedirectToAction("Start", "Cha", new { area = "" });
        }
    }
}