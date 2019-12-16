create database VEGEFOOD_DB
go
use VEGEFOOD_DB
go
--KhachHang
create table KHACHHANG
(get
Email int IDENTITY(1,1) primary key,
Ten nvarchar(50),
Sdt int,
DiaChi nvarchar(50)
)
--LoaiSanPham
create table LOAISANPHAM
(
Id int Identity(1,1) primary key,
Ten nvarchar(50)
)
--NhaCungCap
create table NHACUNGCAP
(
Id int IDENTITY(1,1) primary key,
Ten nvarchar(50),
Diachi nvarchar(50),
Sdt int
)
--SanPham
create table SANPHAM
(
Id int Identity(1,1) primary key,
IdLoaiSanPham nvarchar(50),
Ten nvarchar(50),
IdNhaCungCap nvarchar(50),
TrangThai nvarchar(50),
HinhAnh nvarchar(50)
)
--Chi Tiet San Pham
create table CHITIETSANPHAM
(
IdSanPham int Identity(1,1) primary key,
Gia float,
SoLuongNhap int,
SoLuongTieuThu int,
GiaKhuyenMai float
)

--thongkeNgay
create table THONGKENGAY
(
Ngay date,
IdSanPham int,
SoLuongTieuThu int,
primary key(Ngay,IdSanPham)
)
--DonHang
create table DONHANG
(
Id int Identity(1,1) primary key,
EmailKhachHang nvarchar(50),
TrangThai int
)
--Chi Tiet Don Hang
create table CHITIETDONHANG
(
Id int Identity(1,1) primary key,
IdSanPham int,
SoLuong int,
Gia float
)
--Insert Loai San Pham
insert into LOAISANPHAM(Ten) values
('Rau'),('C?'),('Qu?'),('Trái Cây')
insert into NHACUNGCAP(Ten) values('S?c S?ng Xanh'),('Ngu?n Vi?t'),('Vi?t New'),('Nông S?n Cao Lãm')
insert into SANPHAM(IdLoaiSanPham,Ten,IdNhaCungCap) values(1,'M?ng T?i',1),(1,'??u B?p',1),(2,'Xu Hào',2),(2,'Khoai Tây',2),(3,'Xoài',3),
(3,'D?a H?u',3),(4,'Nhãn',4),(4,'D?a',4)