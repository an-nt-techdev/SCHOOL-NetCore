using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class SanPhamController : Controller
    {
        public readonly ISanPham ISanPham;
        
        public SanPhamController(ISanPham _ISanPham)
        {
            ISanPham = _ISanPham;
        }
        public IActionResult Index()
        {
            return View(ISanPham.GetSanphams);
        }
    }
}