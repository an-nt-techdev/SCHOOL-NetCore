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

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CheckoutController : ChaController
    {
        public readonly IKhachHang _KhachHang;
        public CheckoutController(IFSanpham _IFSanpham, IFDonHang _IFDonhang, IKhachHang _IKhachHang) : base(_IFSanpham, _IFDonhang)
        {
            _KhachHang = _IKhachHang;
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
        public IActionResult Checkout(Khachhang _kh)
        {
            if (_KhachHang.GetKhachHang(_kh.Email) != null)
            {
                _KhachHang.UpdateKhachHang(_kh);
            }
            _KhachHang.AddKhachHang(_kh, HttpContext.Session.GetInt32("Id"));

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Thiên Ân", "ndsg1964@gmail.com"));
                message.To.Add(new MailboxAddress(_kh.Ten, _kh.Email));
                message.Subject = "Thông báo cửa hàng Khoa Rau Củ: ";
                message.Body = new TextPart("plain")
                {
                    Text = " Bạn đã thanh toán thành công đơn hàng có mã: " + HttpContext.Session.GetInt32("Id") + "  |  Chúng tôi sẽ tiến hành kiểm tra và giao hàng đến bạn trong thời gian ngắn nhất. Cảm ơn bạn đã tin tưởng mua hàng ở Khoa Rau Củ. LOVE!!"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("ndsg1964@gmail.com", "Thienanbao0399");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $" Oops! We have a problem here {ex.Message}";
            }

            return RedirectToAction("Start", "Cha", new { area = ""});
        }
    }
}