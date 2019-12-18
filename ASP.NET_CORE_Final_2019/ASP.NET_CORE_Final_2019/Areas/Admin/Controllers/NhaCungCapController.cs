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
    public class NhaCungCapController : Controller
    {
        public readonly INhaCungCap INhaCungCap;
        
        public NhaCungCapController(INhaCungCap _INhaCungCap)
        {
            INhaCungCap = _INhaCungCap;
        }
        [Route("admin/[controller]")]
        public IActionResult Index()
        {
            return View(INhaCungCap.GetNhacungcaps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nhacungcap _NhaCungCap)
        {
            if (ModelState.IsValid)
            {
                INhaCungCap.Add(_NhaCungCap);
                return RedirectToAction("Index");
            }
            return View(_NhaCungCap);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Nhacungcap model = INhaCungCap.GetNhacungcap(id);
                return View(model);
            }
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
                INhaCungCap.Remove(id);
                return RedirectToAction("Index");
        }
    }
}