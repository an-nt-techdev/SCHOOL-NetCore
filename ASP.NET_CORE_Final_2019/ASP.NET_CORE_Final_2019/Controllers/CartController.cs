using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CartController : ChaController
    {
        public CartController(IFSanpham _IFSanpham, IFDonHang _IFDonhang):base(_IFSanpham, _IFDonhang)
        {}

        [Route("Cart")]
        public IActionResult Index()
        {
            getSession();
            return View();
        }

        [Route("Cart/Update/{Id?}/{IdSanPham?}")]
        public IActionResult Update(int Id, int IdSanPham)
        {
            Chitietdonhang ctdh = _Donhang.getChiTietDonHang(Id, IdSanPham);
            Chitietsanpham ctsp = _Sanpham.GetChiTietSanPham(IdSanPham);
            Sanpham sp = _Sanpham.GetSanPham(IdSanPham);
            ctdh.Id = Id;
            ctdh.IdSanPham = IdSanPham;
            if (sp.IdLoaiSanPham == 4)
            {
                ctdh.SoLuong = ctdh.SoLuong + 1;
                ctdh.Gia = ctsp.Gia * ctsp.GiaKhuyenMai / 100 * ctdh.SoLuong;
            }
            else
            {
                ctdh.SoLuong = ctdh.SoLuong + 100;
                ctdh.Gia = ctsp.Gia * (ctsp.GiaKhuyenMai / 100) * (ctdh.SoLuong / 1000);
            }
            
            _Donhang.updateChiTietDonHang(ctdh);
            getSession();
            return RedirectToAction("Index", "Cart", new { area = ""} );
        }

        [Route("Cart/Remove")]
        public IActionResult Remove()
        {
            return View();
        }
    }
}