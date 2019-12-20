using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Services
{
    public interface IKhachHang
    {

        // Get All
        IEnumerable<Khachhang> GetKhachhangs { get; }


        // Get One
        Khachhang GetKhachHang(string email);


        // Add One
        void AddKhachHang(Khachhang KhachHang ,int? Id);


        // Update One
        void UpdateKhachHang(Khachhang KhachHang);


        // Remove One
        void RemoveKhachHang(string email);
    }
}
