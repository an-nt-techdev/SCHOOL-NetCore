using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class HomeController : Controller
    {
        public readonly IFSanpham _Sanpham;
        
        public HomeController(IFSanpham _IFSanpham)
        {
            _Sanpham = _IFSanpham;
        }

        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListSanPhamMoiNhat = _Sanpham.GetSanPhamMoiNhat();
            ViewBag.ListSanPhamBanChayNhat = _Sanpham.GetSanPhamBanChayNhat();
            return View(_Sanpham.Get8SanPhams());
        }

        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
