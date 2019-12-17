using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final2019.Models;
using ASP.NET_CORE_Final2019.Services;

namespace ASP.NET_CORE_Final2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFSanpham _ISanpham;
        VEGEFOOD_DBContext db = new VEGEFOOD_DBContext();

        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            List<Sanpham> sanphams = db.Sanpham.ToList();
            return View(sanphams);
        }

        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
