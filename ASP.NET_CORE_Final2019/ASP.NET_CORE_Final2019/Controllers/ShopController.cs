using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final2019.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final2019.Controllers
{
    public class ShopController : Controller
    {
        public readonly IFSanpham _Sanpham;
        public ShopController(IFSanpham _IFSanpham)
        {
            _Sanpham = _IFSanpham;
        }
        public IActionResult Index()
        {
            return View(_Sanpham.GetSanPhams);
        }
    }
}