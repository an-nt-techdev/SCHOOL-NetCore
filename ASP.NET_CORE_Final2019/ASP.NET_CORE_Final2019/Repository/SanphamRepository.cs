using ASP.NET_CORE_Final2019.Models;
using ASP.NET_CORE_Final2019.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final2019.Repository
{
    public class SanphamRepository : IFSanpham
    {
        private VEGEFOOD_DBContext db;

        public SanphamRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Sanpham> GetSanPhams => db.Sanpham;

        public IEnumerable<Loaisanpham> GetLoaisanphams => db.Loaisanpham;

        public Chitietsanpham GetChitietsanpham(int Id)
        {
            Chitietsanpham res = db.Chitietsanpham.Find(Id);
            return res;
        }

        public void add(Sanpham _Sanpham)
        {
            db.Sanpham.Add(_Sanpham);
            db.SaveChanges();
        }

        public Sanpham GetSanpham(int Id)
        {
            Sanpham res = db.Sanpham.Find(Id);
            return res;
        }

        public void remove(int Id)
        {
            Sanpham res = db.Sanpham.Find(Id);
            db.Sanpham.Remove(res);
            db.SaveChanges();
        }
        public Loaisanpham GetLoaisanpham(int Id)
        {
            Sanpham a = GetSanpham(Id);
            Loaisanpham res = db.Loaisanpham.Find(Int32.Parse(a.IdLoaiSanPham));
            return res;
        }
    }
}
