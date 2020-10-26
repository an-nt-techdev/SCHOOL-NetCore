using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Services
{
    public interface IFSanpham
    {
        // Get List
        IEnumerable<Loaisanpham> GetLoaiSanPhams { get; }
        IEnumerable<Sanpham> GetSanPhams { get; }
        IEnumerable<Sanpham> GetSanPhamMoiNhat();
        IEnumerable<Sanpham> GetSanPhamBanChayNhat();
        IEnumerable<Sanpham> GetSanPhamsByIdLoaiSanPham(int Id);
        IEnumerable<Sanpham> Get8SanPhams();
        IEnumerable<Chitietsanpham> GetChiTietSanPhams { get; }

        // Get One
        Sanpham GetSanPham(int? Id);
        Sanpham GetSanPhamByMetaTitle(string metatitle);
        Chitietsanpham GetChiTietSanPham(int? Id);
        Loaisanpham GetLoaiSanPham(int Id);
        
        // Add One
        void addSanPham(Sanpham _Sanpham);
        void addLoaiSanPham(Loaisanpham _Loaisanpham);
        void addChiTietSanPham(Chitietsanpham _Chitietsanpham);

        // Update One
        void updateSanPham(Sanpham _Sanpham);
        void updateMetatitle(int? Id, string metatitle);
        void updateLoaiSanPham(Loaisanpham _Loaisanpham);
        void updateChiTietSanPham(Chitietsanpham _Chitietsanpham);

        // Remove One
        void removeSanPham(int Id);
        void removeLoaiSanPham(int Id);
        void removeChiTietSanPham(int Id);

        Loaisanpham getLoaiSanPhamByMetatitle(string metatitle);

    }
}
