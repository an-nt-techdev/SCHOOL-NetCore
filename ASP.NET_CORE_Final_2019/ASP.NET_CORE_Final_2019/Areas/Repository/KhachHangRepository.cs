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
            Khachhang res = db.Khachhang.Find(email);
            return res;
        }

        public void AddKhachHang(Khachhang KhachHang,int? Id)
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
            //update đơn hàng
            Donhang e = db.Donhang.Where(p => p.Id == Id).FirstOrDefault();
            e.EmailKhachHang = KhachHang.Email;
            db.SaveChanges();
            // update số lượng tiêu thụ chi tiết sản phẩm
            //var ChiTietDonHang = db.Chitietdonhang.Where(p => p.Id == e.Id).ToList();
            //foreach(Chitietdonhang item in ChiTietDonHang)
            //{
            //    if (item.SoLuong != 0)
            //    {
            //        Chitietsanpham up = db.Chitietsanpham.Where(p => p.IdSanPham == item.IdSanPham).FirstOrDefault();
            //        up.SoLuongTieuThu = up.SoLuongTieuThu + item.SoLuong;
            //        db.SaveChanges();
            //        //check bảng thống kê
            //        if (db.Thongkengay.Find(e.Ngay, item.IdSanPham) != null) // update
            //        {
            //            Thongkengay res = db.Thongkengay.Find(e.Ngay, item.IdSanPham);
            //            res.SoLuongTieuThu = res.SoLuongTieuThu + item.SoLuong;
            //            db.SaveChanges();
            //        }
            //        else // insert
            //        {
            //            Thongkengay res = new Thongkengay();
            //            res.Ngay = e.Ngay;
            //            res.IdSanPham = item.IdSanPham;
            //            res.SoLuongTieuThu = item.SoLuong;
            //            db.Thongkengay.Add(res);
            //            db.SaveChanges();
            //        }
            //    }
            //}

        }

        public void UpdateKhachHang(Khachhang KhachHang)
        {
            Khachhang res = db.Khachhang.Where(p => p.Email == KhachHang.Email).FirstOrDefault();
            res.DiaChi = KhachHang.DiaChi;
            res.Sdt = KhachHang.Sdt;
            res.Ten = KhachHang.Ten;
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
