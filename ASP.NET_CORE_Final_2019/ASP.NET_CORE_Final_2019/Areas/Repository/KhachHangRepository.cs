using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class KhachHangRepository:IKhachHang
    {
        private VEGEFOOD_DBContext db;

        public KhachHangRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Khachhang> GetKhachhangs => db.Khachhang;
    }
}
