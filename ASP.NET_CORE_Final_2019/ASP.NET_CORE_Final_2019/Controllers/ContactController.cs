using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class ContactController : ChaController
    {
        public ContactController(IFSanpham _IFSanpham, IFDonHang _IFDonhang) : base(_IFSanpham, _IFDonhang)
        { }

        [Route("Contact")]
        public IActionResult Index()
        {
            getSession();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}