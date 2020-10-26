using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final_2019.Models
{
    public partial class Sanpham
    {
        public int Id { get; set; }
        public int? IdLoaiSanPham { get; set; }
        public string Ten { get; set; }
        public int? IdNhaCungCap { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public string metatitle { get; set; }
    }
}
