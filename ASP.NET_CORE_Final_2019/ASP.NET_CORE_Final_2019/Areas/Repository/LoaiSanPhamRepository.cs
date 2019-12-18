using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class LoaiSanPhamRepository:ILoaiSanPham
    {
        private VEGEFOOD_DBContext db;

        public LoaiSanPhamRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Loaisanpham> GetLoaisanphams => db.Loaisanpham;

        public void Add(Loaisanpham _LoaiSanPham)
        {
            db.Loaisanpham.Add(_LoaiSanPham);
            db.SaveChanges();
        }

        public Loaisanpham GetLoaisanpham(int? Id)
        {
            Loaisanpham res = db.Loaisanpham.Find(Id);
            return res;
        }

        public void Remove(int? Id)
        {
            Loaisanpham res = db.Loaisanpham.Find(Id);
            db.Loaisanpham.Remove(res);
            db.SaveChanges();
        }

        public void Update(Loaisanpham _LoaiSanPham)
        {
            Loaisanpham res = db.Loaisanpham.Find(_LoaiSanPham.Id);
            res.Ten = _LoaiSanPham.Ten;
            db.SaveChanges();
        }
    }
}
