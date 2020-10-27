using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
            ViewBag.IFSanpham = IFSanpham;
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
                _SanPham.HinhAnh = "/Images/" + _SanPham.HinhAnh;
                _SanPham.metatitle = FriendlyURLHelper.GetFriendlyTitle(_SanPham.Ten);

                IFSanpham.addSanPham(_SanPham);
                Sanpham a = IFSanpham.GetSanPhamByMetaTitle(_SanPham.metatitle);
                Chitietsanpham newone = new Chitietsanpham();
                newone.IdSanPham = a.Id;
                newone.Gia = 0;
                newone.GiaKhuyenMai = 0;
                newone.SoLuongNhap = 0;
                newone.SoLuongTieuThu = 0;
                IFSanpham.addChiTietSanPham(newone);
                return RedirectToAction("Index");
            }
            return View(_SanPham);
        }
        [HttpGet]
        public IActionResult Detail(int Id)
        {   
            ViewBag.SanPham = IFSanpham.GetSanPham(Id);
            Chitietsanpham res = IFSanpham.GetChiTietSanPham(Id);
            return View(res);
        }
        [HttpPost]
        public IActionResult Detail(Chitietsanpham _ChiTietSanPham)
        {
            IFSanpham.updateChiTietSanPham(_ChiTietSanPham);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.ListLoaiSanPham = ILoaiSanPham.GetLoaisanphams;
            ViewBag.ListNhaCungCap = INhaCungCap.GetNhacungcaps;
            Sanpham res = IFSanpham.GetSanPham(Id);
            ViewBag.HinhAnh = res.HinhAnh;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(Sanpham _SanPham, string oldImage)
        {
            if (_SanPham.HinhAnh == "" || _SanPham.HinhAnh == null)
            {
                _SanPham.HinhAnh = oldImage;
            }
            else
            {
                _SanPham.HinhAnh = "/Images/" + _SanPham.HinhAnh;
            }
            string tmp = FriendlyURLHelper.GetFriendlyTitle(_SanPham.Ten);
            _SanPham.metatitle = tmp;
            IFSanpham.updateSanPham(_SanPham);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View(IFSanpham.GetSanPham(Id));
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            IFSanpham.removeSanPham(Id);
            return RedirectToAction("Index");
        }
    }
}