using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        public readonly IDonHang IDonHang;
        public readonly IFSanpham IFSanPham;

        public DonHangController(IDonHang _IDonHang,IFSanpham _IFSanPham)
        {
            IDonHang = _IDonHang;
            IFSanPham = _IFSanPham;
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