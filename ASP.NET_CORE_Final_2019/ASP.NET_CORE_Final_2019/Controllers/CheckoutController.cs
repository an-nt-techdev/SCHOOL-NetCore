﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_Final_2019.Services;
using ASP.NET_CORE_Final_2019.Models;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Final_2019.Areas.Services;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_Final_2019.Controllers
{
    public class CheckoutController : ChaController
    {
        public readonly IKhachHang _KhachHang;
        public CheckoutController(IFSanpham _IFSanpham, IFDonHang _IFDonhang, IKhachHang _IKhachHang) : base(_IFSanpham, _IFDonhang)
        {
            _KhachHang = _IKhachHang;
        }

        [Route("Checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            getSession();
            return View();
        }

        [Route("Checkout")]
        [HttpPost]
        public IActionResult Checkout(Khachhang _kh)
        {
            if (_KhachHang.GetKhachHang(_kh.Email) != null)
            {
                _KhachHang.UpdateKhachHang(_kh);
            }
            _KhachHang.AddKhachHang(_kh, HttpContext.Session.GetInt32("Id"));
            return RedirectToAction("Index", "Home", new { area = ""});
        }
    }
}