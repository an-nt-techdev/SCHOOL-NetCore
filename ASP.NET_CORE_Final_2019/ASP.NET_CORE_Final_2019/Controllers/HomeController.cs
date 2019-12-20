using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class HomeController : ChaController
    {
        public HomeController(IFSanpham _IFSanpham, IFDonHang _IFDonhang):base(_IFSanpham, _IFDonhang)
        {}

        [Route("Home")]
        public IActionResult Index()
        {
            getSession();

            ViewBag.ctdh = _Donhang.getChiTietDonHang(HttpContext.Session.GetInt32("Id"));

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
