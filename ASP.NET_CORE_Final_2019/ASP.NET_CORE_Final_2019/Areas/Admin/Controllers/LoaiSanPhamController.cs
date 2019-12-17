using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class LoaiSanPhamController : Controller
    {
        VEGEFOOD_DBContext db = new VEGEFOOD_DBContext();
        public IActionResult Index()
        {
            List<Loaisanpham> loaisanphams = db.Loaisanpham.ToList();
            return View(loaisanphams);
        }
    }
}
