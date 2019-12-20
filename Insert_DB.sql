INSERT INTO LOAISANPHAM(Ten) VALUES
(N'Rau củ'),
(N'Trái cây'),
(N'Đậu'),
(N'Nước ép')

INSERT INTO NHACUNGCAP(Ten, Diachi, Sdt) VALUES
(N'Quốc Tuấn Company', N'8 Trần Văn Quang, Phường 10, Tân Bình, TP.HCM', N'0903787904'),
(N'Tấn Tài Food', N'165 Nguyễn Thái Bình, Phường Cầu Kho, Quận 1, TP.HCM', N'02862724496'),
(N'CS Food', N'34Q Đường 43B, Phường 10, Quận 6, TP.HCM', N'0903624449'),
(N'Thiên Ân Drink', N'240 Dương Quảng Hàm, Phường 5, Gò Vấp, TP.HCM', N'0974384921')

INSERT INTO SANPHAM(IdLoaiSanPham, Ten, IdNhaCungCap, TrangThai, HinhAnh) VALUES
(1, N'Bắp cải trắng', 1, N'Đang bán', N'/Images/p1.jpg'),
(1, N'Bắp cải tím', 1, N'Đang bán', N'/Images/p2.jpg'),
(1, N'Bông cải', 1, N'Đang bán', N'/Images/p3.jpg'),
(1, N'Cà rốt', 1, N'Đang bán', N'/Images/p4.jpg'),
(1, N'Hành tím củ', 1, N'Đang bán', N'/Images/p5.jpg'),
(1, N'Tỏi củ', 2, N'Đang bán', N'/Images/p6.jpg'),
(1, N'Cải chua', 2, N'Đang bán', N'/Images/p7.jpg'),
(1, N'Rau muống', 2, N'Đang bán', N'/Images/p8.jpg'),
(1, N'Rau đay', 3, N'Đang bán', N'/Images/p9.jpg'),
(1, N'Củ cải', 3, N'Đang bán', N'/Images/p10.jpg'),

(2, N'Ớt chuông', 1, N'Đang bán', N'/Images/p11.jpg'),
(2, N'Bí xanh', 1, N'Đang bán', N'/Images/p12.jpg'),
(2, N'Bầu', 1, N'Đang bán', N'/Images/p13.jpg'),
(2, N'Cà chua', 2, N'Đang bán', N'/Images/p14.jpg'),
(2, N'Dâu Đà Lạt', 2, N'Đang bán', N'/Images/p15.jpg'),
(2, N'Táo đỏ', 3, N'Đang bán', N'/Images/p16.jpg'),
(2, N'Ớt hiểm', 2, N'Đang bán', N'/Images/p17.jpg'),
(2, N'Cam', 3, N'Đang bán', N'/Images/p18.jpg'),
(2, N'Mận đỏ', 3, N'Đang bán', N'/Images/p19.jpg'),
(2, N'Dưa hấu', 3, N'Đang bán', N'/Images/p20.jpg'),

(3, N'Đậu bắp', 1, N'Đang bán', N'/Images/p21.jpg'),
(3, N'Đậu Hà Lan', 1, N'Đang bán', N'/Images/p22.jpg'),
(3, N'Đậu xanh', 1, N'Đang bán', N'/Images/p23.jpg'),
(3, N'Đậu phộng', 1, N'Đang bán', N'/Images/p24.jpg'),
(3, N'Đậu trắng', 1, N'Đang bán', N'/Images/p25.jpg'),
(3, N'Đậu đen', 2, N'Đang bán', N'/Images/p26.jpg'),
(3, N'Đậu đỏ', 2, N'Đang bán', N'/Images/p27.jpg'),
(3, N'Đậu ngự', 2, N'Đang bán', N'/Images/p28.jpg'),

(4, N'Nước ép tổng hợp', 4, N'Đang bán', N'/Images/p29.jpg'),
(4, N'Nước ép dâu', 4, N'Đang bán', N'/Images/p30.jpg'),
(4, N'Nước ép cam', 4, N'Đang bán', N'/Images/p31.jpg'),
(4, N'Nước ép dưa hấu', 4, N'Đang bán', N'/Images/p32.jpg'),
(4, N'Nước ép táo', 4, N'Đang bán', N'/Images/p33.jpg'),
(4, N'Nước ép cà rốt', 4, N'Đang bán', N'/Images/p34.jpg'),
(4, N'Nước ép thơm', 4, N'Đang bán', N'/Images/p35.jpg'),
(4, N'Nước ép nho', 4, N'Đang bán', N'/Images/p36.jpg'),
(4, N'Nước ép xoài', 4, N'Đang bán', N'/Images/p37.jpg'),
(4, N'Nước ép đào', 4, N'Đang bán', N'/Images/p38.jpg')


INSERT INTO CHITIETSANPHAM(IdSanPham, Gia, GiaKhuyenMai, SoLuongNhap, SoLuongTieuThu) VALUES
(1, 9000, 90, 100000, 0),
(2, 18000, 90, 100000, 0),
(3, 32000, 90, 100000, 0),
(4, 11000, 90, 100000, 0),
(5, 28000, 90, 100000, 0),
(6, 22000, 90, 100000, 0),
(7, 11000, 90, 100000, 0),
(8, 8000, 90, 100000, 0),
(9, 11000, 90, 100000, 0),
(10, 9000, 90, 100000, 0),

(11, 33000, 100, 100000, 0),
(12, 10000, 100, 100000, 0),
(13, 7000, 100, 100000, 0),
(14, 12000, 100, 100000, 0),
(15, 170000, 100, 100000, 0),
(16, 18000, 100, 100000, 0),
(17, 28000, 100, 100000, 0),
(18, 99000, 100, 100000, 0),
(19, 65000, 100, 100000, 0),
(20, 12000, 100, 100000, 0),

(21, 13000, 100, 100000, 0),
(22, 100000, 100, 100000, 0),
(23, 50000, 100, 100000, 0),
(24, 55000, 100, 100000, 0),
(25, 30000, 100, 100000, 0),
(26, 60000, 100, 100000, 0),
(27, 55000, 100, 100000, 0),
(28, 66000, 100, 100000, 0),

(29, 40000, 100, 100, 0),
(30, 50000, 100, 100, 0),
(31, 50000, 100, 100, 0),
(32, 45000, 100, 100, 0),
(33, 45000, 100, 100, 0),
(34, 40000, 100, 100, 0),
(35, 40000, 100, 100, 0),
(36, 50000, 100, 100, 0),
(37, 45000, 100, 100, 0),
(38, 50000, 100, 100, 0)
Insert into KHACHHANG values
(N'nguyenthienan@gmail.com',N'Nguyễn Thiên Ân','09172912',N'123 Dương Công Hàm'),
(N'vuongduytai@gmail.com',N'Vương Duy Tài','0926101',N'107/11 Dương Tiễn'),
(N'tranbakhoa@gmail.com',N'Trần Bá Khoa','098671201',N'119Ca2 Thạnh Lộc'),
(N'nguyenphuocnha@gmail.com',N'Nguyễn Phước Nhã','09172912',N'109 Bùi Tuấn Dũng')
insert into DONHANG values
(1,N'nguyenthienan@gmail.com',0,'2019-12-20'),
(2,N'nguyenphuocnha@gmail.com',0,'2019-12-20'),
(3,N'tranbakhoa@gmail.com',0,'2019-11-19'),
(4,N'vuongduytai@gmail.com',0,'2019-11-19')

insert into CHITIETDONHANG values (3,1,5,14000),(3,2,7,15000),(4,2,3,5000)