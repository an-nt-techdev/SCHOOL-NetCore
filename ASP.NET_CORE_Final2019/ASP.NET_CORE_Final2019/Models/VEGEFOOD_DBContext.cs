using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP.NET_CORE_Final2019.Models
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
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VEGEFOOD_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.ToTable("CHITIETDONHANG");
            });

            modelBuilder.Entity<Chitietsanpham>(entity =>
            {
                entity.HasKey(e => e.IdSanPham)
                    .HasName("PK__CHITIETS__5FFA2D425855B03D");

                entity.ToTable("CHITIETSANPHAM");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.ToTable("DONHANG");

                entity.Property(e => e.EmailKhachHang).HasMaxLength(50);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__KHACHHAN__A9D1053551B3C4BB");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.ToTable("LOAISANPHAM");

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Diachi).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("SANPHAM");

                entity.Property(e => e.IdLoaiSanPham).HasMaxLength(50);

                entity.Property(e => e.IdNhaCungCap).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Thongkengay>(entity =>
            {
                entity.HasKey(e => new { e.Ngay, e.IdSanPham })
                    .HasName("PK__THONGKEN__5E334566C0811049");

                entity.ToTable("THONGKENGAY");

                entity.Property(e => e.Ngay).HasColumnType("date");
            });
        }
    }
}
