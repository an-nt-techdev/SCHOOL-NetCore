using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class LoaiSanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}