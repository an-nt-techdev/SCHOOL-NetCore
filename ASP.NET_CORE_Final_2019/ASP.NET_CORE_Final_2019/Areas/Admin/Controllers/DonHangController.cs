using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class DonHangController : Controller
    {
        public readonly IDonHang IDonHang;

        public DonHangController(IDonHang _IDonHang)
        {
            IDonHang = _IDonHang;
        }
        public IActionResult Index()
        {
            return View(IDonHang.GetDonhangs);
        }
    }
}