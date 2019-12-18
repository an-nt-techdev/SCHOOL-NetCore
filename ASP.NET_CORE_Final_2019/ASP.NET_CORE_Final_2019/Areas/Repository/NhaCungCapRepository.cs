using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class NhaCungCapRepository : INhaCungCap
    {
        private VEGEFOOD_DBContext db;

        public NhaCungCapRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Nhacungcap> GetNhacungcaps => db.Nhacungcap;
    }
}
