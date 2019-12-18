using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class SanPhamRepository : ISanPham
    {
        private VEGEFOOD_DBContext db;

        public SanPhamRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Sanpham> GetSanphams => db.Sanpham;

        public Loaisanpham GetLoaisanphamByIdSanPham(int Id)
        {
            Sanpham a = GetSanpham(Id);
            Loaisanpham res = db.Loaisanpham.Find(a.IdLoaiSanPham);
            return res;
        }

        public Nhacungcap GetNhacungcapByIdSanPham(int Id)
        {
            Sanpham a = GetSanpham(Id);
            Nhacungcap res = db.Nhacungcap.Find(a.IdNhaCungCap);
            return res;
        }

        public Sanpham GetSanpham(int Id)
        {
            Sanpham res = db.Sanpham.Find(Id);
            return res;
        }
    }
}
