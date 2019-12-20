using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class DonHangRepository:IDonHang
    {
        private VEGEFOOD_DBContext db;

        public DonHangRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Donhang> GetDonhangs => db.Donhang;

        public IEnumerable<Chitietdonhang> GetChitietdonhangs => db.Chitietdonhang;

        public void ChuaXuLy(int Id)
        {
            Donhang res = db.Donhang.Find(Id);
            res.TrangThai = 0;
            db.SaveChanges();
        }

        public void Clean()
        {
            var listDonHang = db.Donhang.ToList();
            foreach (Donhang item in listDonHang)
            {
                if (item.EmailKhachHang == "not")
                {
                    var listChiTietDonHang = db.Chitietdonhang.Where(p => p.Id == item.Id).ToList();
                    foreach(Chitietdonhang rm in listChiTietDonHang)
                    {
                        db.Chitietdonhang.Remove(rm);
                        db.SaveChanges();
                    }
                    db.Donhang.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Chitietdonhang> GetChitietdonhang(int Id)
        {
            IEnumerable<Chitietdonhang> list = db.Chitietdonhang;
            foreach(Chitietdonhang item in list)
            {
                if (item.Id == Id && item.SoLuong!=0) yield return item;
            }
        }

        public Donhang GetDonhang(int Id)
        {
            Donhang res = db.Donhang.Find(Id);
            return res;
        }

        public void GiaoHang(int Id)
        {
            Donhang res = db.Donhang.Find(Id);
            res.TrangThai = 1;
            db.SaveChanges();
        }

        public void HoanThanh(int Id)
        {
            Donhang res = db.Donhang.Find(Id);
            res.TrangThai = 2;
            db.SaveChanges();
        }
    }
}
