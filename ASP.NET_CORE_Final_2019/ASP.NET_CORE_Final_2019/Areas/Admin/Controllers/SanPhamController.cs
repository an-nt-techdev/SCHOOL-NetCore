using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        public readonly IFSanpham IFSanpham;
        public readonly INhaCungCap INhaCungCap;
        public readonly ILoaiSanPham ILoaiSanPham;
        public SanPhamController(IFSanpham _IFSanpham,INhaCungCap _INhaCungCap,ILoaiSanPham _ILoaiSanPham)
        {
            IFSanpham = _IFSanpham;
            INhaCungCap = _INhaCungCap;
            ILoaiSanPham = _ILoaiSanPham;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            ViewBag.ListNhaCungCap = INhaCungCap.GetNhacungcaps;
            ViewBag.ListLoaiSanPham = IFSanpham.GetLoaiSanPhams;
            return View(IFSanpham.GetSanPhams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListLoaiSanPham = ILoaiSanPham.GetLoaisanphams;
            ViewBag.ListNhaCungCap = INhaCungCap.GetNhacungcaps;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sanpham _SanPham)
        {
            if (ModelState.IsValid)
            {
                IFSanpham.addSanPham(_SanPham);
                return RedirectToAction("Index");
            }
            return View(_SanPham);
        }

        public IActionResult Detail(int? Id)
        {
            return View();
        }
    }
}