using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        public readonly IDonHang IDonHang;

        public DonHangController(IDonHang _IDonHang)
        {
            IDonHang = _IDonHang;
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
            return View(IDonHang.GetDonhang(Id));
        }
    }
}