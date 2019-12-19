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
        public readonly IFSanpham _Sanpham;
        public readonly IFDonHang _Donhang;

        public CartController(IFSanpham _IFSanpham, IFDonHang _IFDonhang):base(_IFSanpham, _IFDonhang)
        {
            _Sanpham = _IFSanpham;
            _Donhang = _IFDonhang;
        }

        [Route("Cart")]
        public IActionResult Index()
        {
            getSession();
            return View();
        }

        [Route("Cart/Create")]
        public void Create()
        {
            getSession();
        }

        [Route("Cart/Update")]
        public void Update()
        {
            getSession();
            
        }

        [Route("Cart/Remove")]
        public IActionResult Remove()
        {
            return View();
        }
    }
}