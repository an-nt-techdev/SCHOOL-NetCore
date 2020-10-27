using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_Final_2019.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LoaiSanPhamController : Controller
    {
        public readonly ILoaiSanPham ILoaiSanPham;

        public LoaiSanPhamController(ILoaiSanPham _ILoaiSanPham)
        {
            ILoaiSanPham = _ILoaiSanPham;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            return View(ILoaiSanPham.GetLoaisanphams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loaisanpham _LoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _LoaiSanPham.metatitle = FriendlyURLHelper.GetFriendlyTitle(_LoaiSanPham.Ten);
                ILoaiSanPham.Add(_LoaiSanPham);
                return RedirectToAction("Index");
            }
            return View(_LoaiSanPham);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                Loaisanpham model = ILoaiSanPham.GetLoaisanpham(Id);
                return View(model);
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            ILoaiSanPham.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                Loaisanpham res = ILoaiSanPham.GetLoaisanpham(Id);
                return View(res);
            }
        }

        [HttpPost]
        public IActionResult Edit(Loaisanpham _LoaiSanPham)
        {
            _LoaiSanPham.metatitle = FriendlyURLHelper.GetFriendlyTitle(_LoaiSanPham.Ten);
            ILoaiSanPham.Update(_LoaiSanPham);
            return RedirectToAction("Index");
        }
    }
}
