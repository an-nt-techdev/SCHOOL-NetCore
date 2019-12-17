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
        public readonly IFSanpham _Sanpham;
        //VEGEFOOD_DBContext db = new VEGEFOOD_DBContext();
        public HomeController(IFSanpham _IFSanpham)
        {
            _Sanpham = _IFSanpham;
        }

        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View(_Sanpham.GetSanPhams);
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
