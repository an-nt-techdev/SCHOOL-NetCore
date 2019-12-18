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
    public class NhaCungCapController : Controller
    {
        public readonly INhaCungCap INhaCungCap;
        
        public NhaCungCapController(INhaCungCap _INhaCungCap)
        {
            INhaCungCap = _INhaCungCap;
        }
        public IActionResult Index()
        {
            return View(INhaCungCap.GetNhacungcaps);
        }
    }
}