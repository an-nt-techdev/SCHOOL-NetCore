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
    }
}
