using ASP.NET_CORE_Final2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final2019.Services
{
    public interface IFSanpham
    {
        IEnumerable<Sanpham> GetSanPhams { get; }
        Sanpham GetSanpham(int Id);
        Chitietsanpham GetChitietsanpham(int Id);
        void add(Sanpham _Sanpham);
        void remove(int Id);
    }
}
