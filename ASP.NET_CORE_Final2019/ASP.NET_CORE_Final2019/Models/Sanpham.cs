using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final2019.Models
{
    public partial class Sanpham
    {
        public int Id { get; set; }
        public string IdLoaiSanPham { get; set; }
        public string Ten { get; set; }
        public string IdNhaCungCap { get; set; }
    }
}
