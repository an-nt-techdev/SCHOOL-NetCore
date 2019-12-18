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

        [Route("Shop/{Page=1}")]
        public IActionResult Index(int Page)
        {
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaiSanPhams;
            ViewBag.Cate = false;

            if (_Sanpham.GetSanPhams.Count() % 8 > 0) ViewBag.AllPage = _Sanpham.GetSanPhams.Count() / 8 + 1;
            else ViewBag.AllPage = _Sanpham.GetSanPhams.Count() / 8;

            if (Page < 1) ViewBag.CurrentPage = 1;
            else if (Page > ViewBag.AllPage) ViewBag.CurrentPage = ViewBag.AllPage;
            else ViewBag.CurrentPage = Page;

            return View(_Sanpham.GetSanPhams);
        }

        [Route("Shop/Cate/{Id=1}/{Page=1}")]
        public IActionResult Index(int Id, int Page)
        {
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaiSanPhams;
            ViewBag.Cate = true;

            if (_Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() % 8 > 0) ViewBag.AllPage = _Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() / 8 + 1;
            else ViewBag.AllPage = _Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() / 8;
            ViewBag.IdCate = Id;

            if (Page < 1) ViewBag.CurrentPage = 1;
            else if (Page > ViewBag.AllPage) ViewBag.CurrentPage = ViewBag.AllPage;
            else ViewBag.CurrentPage = Page;

            return View(_Sanpham.GetSanPhamsByIdLoaiSanPham(Id));
        }

        [Route("Shop/Product/{Id=1}")]
        public IActionResult SingleProduct(int Id)
        {
            ViewBag.SanPham = _Sanpham.GetSanPham(Id);
            ViewBag.ChiTietSanPham = _Sanpham.GetChiTietSanPham(Id);
            ViewBag.Loai = _Sanpham.GetLoaiSanPham(Id);

            ViewBag.SanPhamCungLoai = _Sanpham.GetSanPhamsByIdLoaiSanPham(_Sanpham.GetLoaiSanPham(Id).Id);
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            //ViewBag.ListSanPham = _Sanpham.GetSanPhams;
            return View();
        }
    }
}