using System;
using System.Collections.Generic;

namespace ASP.NET_CORE_Final2019.Models
{
    public partial class Donhang
    {
        public int Id { get; set; }
        public string EmailKhachHang { get; set; }
        public int? TrangThai { get; set; }
    }
}
