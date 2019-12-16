using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final2019.Models
{
    public partial class Chitietsanpham
    {
        public int IdSanPham { get; set; }
        public double? Gia { get; set; }
        public int? SoLuongNhap { get; set; }
        public int? SoLuongTieuThu { get; set; }
        public double? GiaKhuyenMai { get; set; }
    }
}
