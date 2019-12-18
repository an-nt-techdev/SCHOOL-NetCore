using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(String pass)
        {
            if (pass == "admin")
            {
               HttpContext.Session.SetString("Pass", pass);
                return RedirectToAction("Index", "LoaiSanPham", new { area = "Admin" });
            }
            return View();
        }
    }
}