create database VEGEFOOD_DB
go
use VEGEFOOD_DB
go
--KhachHang
create table KHACHHANG
(
Email nvarchar(200) primary key,
Ten nvarchar(50),
Sdt int,
DiaChi nvarchar(200)
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
Diachi nvarchar(200),
Sdt nvarchar(20)
)
--SanPham
create table SANPHAM
(
Id int Identity(1,1) primary key,
IdLoaiSanPham int,
Ten nvarchar(50),
IdNhaCungCap int,
TrangThai nvarchar(50),
HinhAnh nvarchar(200)
)
--Chi Tiet San Pham
create table CHITIETSANPHAM
(
IdSanPham int primary key,
Gia float,
GiaKhuyenMai float,
SoLuongNhap int,
SoLuongTieuThu int
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
Id int primary key,
EmailKhachHang nvarchar(200),
TrangThai int,
Ngay DateTime
)
--Chi Tiet Don Hang
create table CHITIETDONHANG
(
Id int,
IdSanPham int,
SoLuong int,
Gia float,
PRIMARY KEY(Id, IdSanPham)
)
-- --Insert Loai San Pham
-- insert into LOAISANPHAM(Ten) values
-- (N'Rau'),(N'Củ'),('Quả'),(N'Trái Cây')
-- insert into NHACUNGCAP(Ten) values(N'Sức Sống Xanh'),(N'Nguồn Việt'),(N'Việt New'),(N'Nông Sản Cao Lãm')
-- insert into SANPHAM(IdLoaiSanPham,Ten,IdNhaCungCap) values(1,N'Mồng Tơi',1),(1,N'Đậu Bắp',1),(2,N'Xu Hào',2),(2,N'Khoai Tây',2),(3,N'Xoài',3),
-- (3,N'Dưa Hấu',3),(4,N'Nhãn',4),(4,N'Dâu',4)