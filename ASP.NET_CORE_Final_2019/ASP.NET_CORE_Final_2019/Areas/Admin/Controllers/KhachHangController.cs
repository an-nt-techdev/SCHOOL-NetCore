using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        public readonly IKhachHang IKhachHang;
        public readonly IDonHang IDonHang;
        public KhachHangController(IKhachHang _IKhachHang,IDonHang _IDonHang)
        {
            IKhachHang = _IKhachHang;
            IDonHang = _IDonHang;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            ViewBag.DonHang = IDonHang.GetDonhangs;
            return View(IKhachHang.GetKhachhangs);
        }
        [HttpGet]
        public IActionResult Edit(string Email)
        {
            return View(IKhachHang.GetKhachHang(Email));
        }

        [HttpPost]
        public IActionResult Edit(Khachhang _KhachHang)
        {
            IKhachHang.UpdateKhachHang(_KhachHang);
            return RedirectToAction("Index");
        }
    }
}