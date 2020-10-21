using System;
using System.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ASP.NET_CORE_Final_2019.Models
{
    public partial class VEGEFOOD_DBContext : DbContext
    {
        public VEGEFOOD_DBContext()
        {
        }

        public VEGEFOOD_DBContext(DbContextOptions<VEGEFOOD_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhang { get; set; }
        public virtual DbSet<Chitietsanpham> Chitietsanpham { get; set; }
        public virtual DbSet<Donhang> Donhang { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanpham { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Thongkengay> Thongkengay { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("VEGEFOOD_DBContext"));
                //optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdSanPham })
                   .HasName("PK__CHITIETD__5E3345661AC86B8C");
                entity.ToTable("CHITIETDONHANG");
            });

            modelBuilder.Entity<Chitietsanpham>(entity =>
            {
                entity.HasKey(e => e.IdSanPham)
                    .HasName("PK__CHITIETS__5FFA2D428197D9C4");

                entity.ToTable("CHITIETSANPHAM");

                entity.Property(e => e.IdSanPham).ValueGeneratedNever();
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.ToTable("DONHANG");

                entity.Property(e => e.EmailKhachHang).HasMaxLength(200);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__KHACHHAN__A9D1053522728711");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(50);
                entity.Property(e => e.Sdt).HasMaxLength(50);
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.ToTable("LOAISANPHAM");

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Diachi).HasMaxLength(200);

                entity.Property(e => e.Sdt).HasMaxLength(20);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("SANPHAM");

                entity.Property(e => e.HinhAnh).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasMaxLength(50);
            });

            modelBuilder.Entity<Thongkengay>(entity =>
            {
                entity.HasKey(e => new { e.Ngay, e.IdSanPham })
                    .HasName("PK__THONGKEN__5E3345661AC86B8C");

                entity.ToTable("THONGKENGAY");

                entity.Property(e => e.Ngay).HasColumnType("date");
            });
        }
    }
}
