using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Services
{
    public interface ILoaiSanPham
    {
        IEnumerable<Loaisanpham> GetLoaisanphams { get; }
        Loaisanpham GetLoaisanpham(int? Id);
        void Add(Loaisanpham _LoaiSanPham);
        void Remove(int? Id);
        void Update(Loaisanpham _LoaiSanPham);
    }
}
