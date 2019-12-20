using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        public readonly IThongKe IThongKe;
        public readonly IDonHang IDonHang;
        public ThongKeController(IThongKe _IThongKe,IDonHang _IDonHang)
        {
            IThongKe = _IThongKe;
            IDonHang = _IDonHang;
        }

        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            ViewBag.ListDonHang = IDonHang.GetDonhangs;
            ViewBag.ListDate = IThongKe.GetDates();
            ViewBag.listChiTietDonHang = IDonHang.GetChitietdonhangs;
            return View(IDonHang.GetDonhangs);
        }
    }
}