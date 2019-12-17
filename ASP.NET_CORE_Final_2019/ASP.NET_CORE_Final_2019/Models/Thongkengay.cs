using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final_2019.Models
{
    public partial class Thongkengay
    {
        public DateTime Ngay { get; set; }
        public int IdSanPham { get; set; }
        public int? SoLuongTieuThu { get; set; }
    }
}
