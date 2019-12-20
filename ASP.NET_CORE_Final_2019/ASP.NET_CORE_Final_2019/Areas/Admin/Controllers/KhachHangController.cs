using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        public readonly IKhachHang IKhachHang;

        public KhachHangController(IKhachHang _IKhachHang)
        {
            IKhachHang = _IKhachHang;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            return View(IKhachHang.GetKhachhangs);
        }
    }
}