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

        public void Add(Nhacungcap _NhaCungCap)
        {
            db.Nhacungcap.Add(_NhaCungCap);
            db.SaveChanges();
        }

        public Nhacungcap GetNhacungcap(int? Id)
        {
            Nhacungcap res = db.Nhacungcap.Find(Id);
            return res;
        }

        public void Remove(int? Id)
        {
            Nhacungcap res = db.Nhacungcap.Find(Id);
            db.Nhacungcap.Remove(res);
            db.SaveChanges();
        }

        public void Update(Nhacungcap _NhaCungCap)
        {
            Nhacungcap res = db.Nhacungcap.Find(_NhaCungCap.Id);
            res.Sdt = _NhaCungCap.Sdt;
            res.Ten = _NhaCungCap.Ten;
            res.Diachi = _NhaCungCap.Diachi;
            db.SaveChanges();
        }
    }
}
