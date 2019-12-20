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

        public Khachhang GetKhachHang(string email)
        {
            return db.Khachhang.Find(email);
            return null;
        }

        public void AddKhachHang(Khachhang KhachHang)
        {
            if (GetKhachHang(KhachHang.Email) == null)
            {
                db.Khachhang.Add(KhachHang);
                db.SaveChanges();
            }
            else
            {
                UpdateKhachHang(KhachHang);
            }
        }

        public void UpdateKhachHang(Khachhang KhachHang)
        {
            db.Khachhang.Update(KhachHang);
            db.SaveChanges();
        }

        public void RemoveKhachHang(string email)
        {
            Khachhang kh = db.Khachhang.Find(email);
            db.Khachhang.Remove(kh);
            db.SaveChanges();
        }
    }
}
