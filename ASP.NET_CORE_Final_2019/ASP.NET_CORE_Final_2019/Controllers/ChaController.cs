using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Repository;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class ChaController : Controller
    {
        public readonly IFSanpham _Sanpham;
        public readonly IFDonHang _Donhang;
        public ChaController(IFSanpham _IFSanpham, IFDonHang _IFDonhang)
        {
            _Sanpham = _IFSanpham;
            _Donhang = _IFDonhang;
        }

        public IActionResult Start()
        {
            Random rand = new Random();
            int sess = rand.Next(1, 9) * 100000 + rand.Next(0, 9) * 10000 + rand.Next(0, 9) * 1000 + rand.Next(0, 9) * 100 + rand.Next(0, 9) * 10 + rand.Next(0, 9);
            HttpContext.Session.SetInt32("Id", sess);
            
            // ADD DON HANG
            Donhang dh = new Donhang();
            dh.Id = HttpContext.Session.GetInt32("Id");
            DateTime now = DateTime.Now;
            dh.Ngay = now;
            dh.TrangThai = 0;
            dh.EmailKhachHang = "not";
            dh.PhuongThucThanhToan = "None";
            _Donhang.addDonHang(dh);

            // ADD CHI TIET DON HANG
            Chitietdonhang ctdh = new Chitietdonhang(); ;
            IEnumerable<Sanpham> list = _Sanpham.GetSanPhams;
            List<Sanpham> listt = list.ToList();
            foreach (Sanpham l in listt)
            {
                ctdh.Id = HttpContext.Session.GetInt32("Id");
                ctdh.IdSanPham = l.Id;
                ctdh.SoLuong = 0;
                ctdh.Gia = 0;
                _Donhang.addChiTietDonHang(ctdh);
            }  

            //getSession();
            return RedirectToAction("Index", "Home", new { area = ""} );
        }

        public void getSession()
        {
            IEnumerable<Chitietdonhang> list = _Donhang.getChiTietDonHang(HttpContext.Session.GetInt32("Id"));
            int cnt = 0;
            foreach (Chitietdonhang l in list)
            {
                if (l.SoLuong > 0) cnt++;
            }
            ViewData["Count"] = cnt;
            ViewData["Session"] = HttpContext.Session.GetInt32("Id");
        }
    }
}