using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ASP.NET_CORE_Final_2019.Services;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CartController : Controller
    {
        public readonly IFSanpham _Sanpham;

        public CartController(IFSanpham _IFSanpham)
        {
            _Sanpham = _IFSanpham;

        }

        [Route("Cart")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Cart/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Cart/Update")]
        public IActionResult Update()
        {
            return View();
        }

        [Route("Cart/Remove")]
        public IActionResult Remove()
        {
            return View();
        }
    }
}