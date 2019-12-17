using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class ShopController : Controller
    {
        public readonly IFSanpham _Sanpham;
      
        public ShopController(IFSanpham _IFSanpham)
        {
            _Sanpham = _IFSanpham;
        }

        [Route("Shop")]
        public IActionResult Index()
        {
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaisanphams;
            return View(_Sanpham.GetSanPhams);
        }

        [Route("Shop/Product")]
        public IActionResult SingleProduct(int Id)
        {
            ViewBag.Sanpham = _Sanpham.GetSanpham(Id);
            ViewBag.Chitietsanpham = _Sanpham.GetChitietsanpham(Id);
            ViewBag.Loai = _Sanpham.GetLoaisanpham(Id);
            return View();
        }
    }
}