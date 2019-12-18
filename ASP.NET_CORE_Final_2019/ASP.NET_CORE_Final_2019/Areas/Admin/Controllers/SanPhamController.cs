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
    [Route("admin/[controller]")]
    public class SanPhamController : Controller
    {
        public readonly IFSanpham IFSanpham;
        public readonly INhaCungCap INhaCungCap;
        public SanPhamController(IFSanpham _IFSanpham,INhaCungCap _INhaCungCap)
        {
            IFSanpham = _IFSanpham;
            INhaCungCap = _INhaCungCap;
        }
        public IActionResult Index()
        {
            ViewBag.ListNhaCungCap = INhaCungCap.GetNhacungcaps;
            ViewBag.ListLoaiSanPham = IFSanpham.GetLoaiSanPhams;
            return View(IFSanpham.GetSanPhams);
        }
    }
}