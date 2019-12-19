using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            Random rand = new Random();
            int sess = rand.Next(1, 9) * 100000 + rand.Next(0, 9) * 10000 + rand.Next(0, 9) * 1000 + rand.Next(0, 9) * 100 + rand.Next(0, 9) * 10 + rand.Next(0, 9);
            HttpContext.Session.SetInt32("Id", sess);
            Donhang dh = new Donhang();
            dh.Id = HttpContext.Session.GetInt32("Id");
            //_Donhang.addDonHang(dh);
            return View();
        }
    }
}