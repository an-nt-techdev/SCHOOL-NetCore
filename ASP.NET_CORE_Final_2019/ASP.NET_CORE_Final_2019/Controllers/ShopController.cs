using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class ShopController : ChaController
    {
        public ShopController(IFSanpham _IFSanpham, IFDonHang _IFDonhang):base(_IFSanpham, _IFDonhang)
        {}

        [Route("Shop/{Page=1}")]
        [Route("Shop")]
        public IActionResult Index(int Page)
        {
            getSession();
            ViewBag.MySession = HttpContext.Session.GetInt32("Id");
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaiSanPhams;
            ViewBag.Cate = false;

            if (_Sanpham.GetSanPhams.Count() % 8 > 0) ViewBag.AllPage = _Sanpham.GetSanPhams.Count() / 8 + 1;
            else ViewBag.AllPage = _Sanpham.GetSanPhams.Count() / 8;

            if (Page < 1) ViewBag.CurrentPage = 1;
            else if (Page > ViewBag.AllPage) ViewBag.CurrentPage = ViewBag.AllPage;
            else ViewBag.CurrentPage = Page;
            ViewBag.ISanPham = _Sanpham;
            return View(_Sanpham.GetSanPhams);
        }

        [Route("Shop/{metatitle}/{Page}")]
        [Route("Shop/{metatitle}")]
        public IActionResult Index(string metatitle, int Page)
        {
            getSession();
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            ViewBag.ListLoaiSanPham = _Sanpham.GetLoaiSanPhams;
            ViewBag.Cate = true;
            Loaisanpham res = _Sanpham.getLoaiSanPhamByMetatitle(metatitle);
            int Id = res.Id;
            if (_Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() % 8 > 0) ViewBag.AllPage = _Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() / 8 + 1;
            else ViewBag.AllPage = _Sanpham.GetSanPhamsByIdLoaiSanPham(Id).Count() / 8;
            ViewBag.IdCate = Id;
            ViewBag.metatitle = res.metatitle;

            if (Page < 1) ViewBag.CurrentPage = 1;
            else if (Page > ViewBag.AllPage) ViewBag.CurrentPage = ViewBag.AllPage;
            else ViewBag.CurrentPage = Page;

            return View(_Sanpham.GetSanPhamsByIdLoaiSanPham(Id));
        }

        [Route("Shop/{catetitle}/{metatitle}")]
        [HttpGet]
        public IActionResult SingleProduct(string metatitle,string catetitle)
        {
            getSession();
            Sanpham tmp = _Sanpham.GetSanPhamByMetaTitle(metatitle);
            Loaisanpham a = _Sanpham.GetLoaiSanPham((int)tmp.IdLoaiSanPham);
            ViewBag.CateTitle = a.metatitle;
            var Id = tmp.Id;
            ViewBag.SanPham = _Sanpham.GetSanPham(Id);
            ViewBag.ChiTietSanPham = _Sanpham.GetChiTietSanPham(Id);
            ViewBag.Loai = _Sanpham.GetLoaiSanPham(Id);

            ViewBag.ss = HttpContext.Session.GetInt32("Id");
            ViewBag.SanPhamCungLoai = _Sanpham.GetSanPhamsByIdLoaiSanPham(_Sanpham.GetLoaiSanPham(Id).Id);
            ViewBag.ListChiTietSanPham = _Sanpham.GetChiTietSanPhams;
            //ViewBag.ListSanPham = _Sanpham.GetSanPhams;

            Chitietdonhang dh = new Chitietdonhang();
            dh.Id = HttpContext.Session.GetInt32("Id");
            dh.IdSanPham = Id;
            dh.SoLuong = 0;
            dh.Gia = 0;

            return View(dh);
        }

        [Route("Shop/{cate}/{Id}")]
        [HttpPost]
        public IActionResult SingleProduct(Chitietdonhang ctdh)
        {
            Chitietdonhang _ctdh = _Donhang.getChiTietDonHang(ctdh.Id, ctdh.IdSanPham);
            Chitietsanpham ctsp = _Sanpham.GetChiTietSanPham(ctdh.IdSanPham);
            Sanpham sp = _Sanpham.GetSanPham(ctdh.IdSanPham);
            if (sp.IdLoaiSanPham == 4)
            {
                _ctdh.SoLuong = _ctdh.SoLuong + ctdh.SoLuong;
                _ctdh.Gia = ctsp.Gia * ctsp.GiaKhuyenMai / 100 * _ctdh.SoLuong;
            }
            else
            {
                _ctdh.SoLuong = _ctdh.SoLuong + ctdh.SoLuong;
                _ctdh.Gia = (ctsp.Gia * ctsp.GiaKhuyenMai / 100 * _ctdh.SoLuong) / 1000;
            }

            _Donhang.updateChiTietDonHang(_ctdh);
            //getSession();            
            return RedirectToAction("Index", "Cart", new { area = "" } );
        }
    }
}