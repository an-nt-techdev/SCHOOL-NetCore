using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Services
{
    public interface IFDonHang
    {

        // Get One
        Donhang getDonHang(int? Id);
        void UpdatePhuongThuc(int? Id, string phuongthuc);
        void UpdateDescription(int? Id, string description);
        Chitietdonhang getChiTietDonHang(int? Id, int? IdSanPham);

        // Get List
        IEnumerable<Chitietdonhang> getChiTietDonHang(int? Id);

        // Add One
        void addDonHang(Donhang _DonHang);
        void addChiTietDonHang(Chitietdonhang _ChiTietDonHang);

        // Update One
        void updateDonHang(Donhang _DonHang);
        void updateChiTietDonHang(Chitietdonhang _ChiTietDonHang);

        // Remove One
        void removeDonHang(int Id);
        void removeChiTietDonHang(int Id);
        void removeChiTietDonHang(int? Id, int? IdSanPham);
    }
}
