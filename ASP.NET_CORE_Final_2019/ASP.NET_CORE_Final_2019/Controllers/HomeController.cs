using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class HomeController : ChaController
    {
        public HomeController(IFSanpham _IFSanpham, IFDonHang _IFDonhang):base(_IFSanpham, _IFDonhang)
        {}

        [Route("Home")]
        [HttpGet]
        public IActionResult Index()
        {
            getSession();

            //ViewBag.ctdh = _Donhang.getChiTietDonHang(HttpContext.Session.GetInt32("Id"));

            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListSanPhamMoiNhat = _Sanpham.GetSanPhamMoiNhat();
            ViewBag.ListSanPhamBanChayNhat = _Sanpham.GetSanPhamBanChayNhat();
            ViewBag.List8SanPham = _Sanpham.Get8SanPhams();
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaiSanPhams;
            return View();
        }

        [Route("Home")]
        [HttpPost]
        public IActionResult Index(Contact _Contact)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Bá Khoa", "tbkhoa1999.com"));
                message.To.Add(new MailboxAddress(_Contact.Ten, _Contact.Email));
                message.Subject = "Thông báo từ khách hàng có Email: " + _Contact.Email;
                message.Body = new TextPart("plain")
                {
                    Text = _Contact.ChuDe + " | ĐK nhận Email: " + _Contact.Email + " | Nội dung: " + _Contact.NoiDung
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

            getSession();

            ViewBag.ctdh = _Donhang.getChiTietDonHang(HttpContext.Session.GetInt32("Id"));

            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListSanPhamMoiNhat = _Sanpham.GetSanPhamMoiNhat();
            ViewBag.ListSanPhamBanChayNhat = _Sanpham.GetSanPhamBanChayNhat();
            ViewBag.List8SanPham = _Sanpham.Get8SanPhams();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
