using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final_2019.Models
{
    public partial class Donhang
    {
        public int? Id { get; set; }
        public string EmailKhachHang { get; set; }
        public DateTime Ngay { get; set; }
        public int? TrangThai { get; set; }
    }
}
