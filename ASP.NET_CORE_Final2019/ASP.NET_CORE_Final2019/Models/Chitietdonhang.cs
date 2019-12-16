using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final2019.Models
{
    public partial class Chitietdonhang
    {
        public int Id { get; set; }
        public int? IdSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }
    }
}
