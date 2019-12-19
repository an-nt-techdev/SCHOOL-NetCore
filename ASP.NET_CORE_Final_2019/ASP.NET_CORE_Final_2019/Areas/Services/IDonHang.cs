using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Services
{
    public interface IDonHang
    {
        IEnumerable<Donhang> GetDonhangs { get; }
        Donhang GetDonhang(int Id);
        void GiaoHang(int Id);
        void HoanThanh(int Id);
        void ChuaXuLy(int Id);
        IEnumerable<Chitietsanpham> GetChitietsanphams(int Id);
    }
}
