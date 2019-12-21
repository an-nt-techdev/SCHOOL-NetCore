using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        public readonly IDonHang IDonHang;
        public readonly IFSanpham IFSanPham;
        public readonly IKhachHang IKhachHang;
        public DonHangController(IDonHang _IDonHang,IFSanpham _IFSanPham,IKhachHang _IKhachHang)
        {
            IDonHang = _IDonHang;
            IFSanPham = _IFSanPham;
            IKhachHang = _IKhachHang;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            return View(IDonHang.GetDonhangs);
        }

        [HttpGet]
        public IActionResult GiaoHang(int Id)
        {
            IDonHang.GiaoHang(Id);
            Donhang res = IDonHang.GetDonhang(Id);
            Khachhang _kh = IKhachHang.GetKhachHang(res.EmailKhachHang);
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Thiên Ân", "ndsg1964@gmail.com"));
                message.To.Add(new MailboxAddress(_kh.Ten, _kh.Email));
                message.Subject = "Thông báo cửa hàng Khoa Rau Củ: ";
                message.Body = new TextPart("plain")
                {
                    Text = "Đơn Hàng Của Bạn Đang Trên Đường Vận Chuyển Tới Địa Chỉ : " + _kh.DiaChi +". Vui Lòng Cho Chúng Tôi Biết Nếu Hàng Đã Tới Nơi."
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult HoanThanh(int Id)
        {
            IDonHang.HoanThanh(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChuaXuLy(int Id)
        {
            IDonHang.ChuaXuLy(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int Id)
        {
            ViewBag.SanPham = IFSanPham.GetSanPhams;
            ViewBag.DonHang = IDonHang.GetDonhang(Id);
            return View(IDonHang.GetChitietdonhang(Id));
        }

        [HttpGet]
        public IActionResult Clean()
        {
            IDonHang.Clean();
            return RedirectToAction("Index");
        }
    }
}