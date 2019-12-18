using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Services
{
    public interface ISanPham
    {
        IEnumerable<Sanpham> GetSanphams { get; }
        Sanpham GetSanpham(int Id);
        Loaisanpham GetLoaisanphamByIdSanPham(int Id);
        Nhacungcap GetNhacungcapByIdSanPham(int Id);

          
    }
}
