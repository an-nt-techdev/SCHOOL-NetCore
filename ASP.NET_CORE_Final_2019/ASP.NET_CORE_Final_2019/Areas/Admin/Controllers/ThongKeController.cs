using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using ASP.NET_CORE_Final_2019.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        public readonly IThongKe IThongKe;
        public readonly IDonHang IDonHang;
        public readonly IFSanpham IFSanPham;
        public ThongKeController(IThongKe _IThongKe,IDonHang _IDonHang,IFSanpham _IFSanPham)
        {
            IThongKe = _IThongKe;
            IDonHang = _IDonHang;
            IFSanPham = _IFSanPham;
        }

        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            VEGEFOOD_DBContext db = new VEGEFOOD_DBContext();
            ViewBag.ListDonHang = IDonHang.GetDonhangs;
            ViewBag.ListDate = IThongKe.GetDates();
            ViewBag.ListThongKeNgay = IThongKe.GetThongkengays;
            ViewBag.ListSanPham = IFSanPham.GetSanPhams;
            return View(IDonHang.GetDonhangs);
        }
    }
}