-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[thietbi] (bảng thiết bị)
INSERT INTO [dbo].[thietbi] (
    [TênThiếtBị],
    [LoạiThiếtBị],
    [TrạngThái],
    [GiáMượn]
) VALUES 
    ('Máy chiếu Epson EB-X05', 'Máy chiếu', 'Có sẵn', 50000),
    ('Laptop Dell XPS 13', 'Máy tính xách tay', 'Có sẵn', 100000),
    ('Máy in HP LaserJet Pro', 'Máy in', 'Đang sử dụng', 30000),
    ('Loa Bluetooth JBL', 'Thiết bị âm thanh', 'Có sẵn', 20000),
    ('Máy ảnh Canon EOS 80D', 'Máy ảnh', 'Bảo trì', 80000),
    ('Bảng trắng thông minh', 'Thiết bị trình chiếu', 'Có sẵn', 60000),
    ('Tai nghe Sony WH-1000XM4', 'Thiết bị âm thanh', 'Có sẵn', 25000),
    ('Máy scan Brother ADS-2200', 'Máy scan', 'Có sẵn', 35000);
  
  
-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[nguoidung] (bảng người dùng)
INSERT INTO NguoiDung (Email, MatKhau, HoTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai)
VALUES 
('nguyenvanbao@gmail.com', 'NVBao@2024#Xyz!', 'Nguyễn Văn Bảo', '1990-05-10', 'Hà Nội', 'Nam', '0987654001', 'Hoạt động'),
('tranthithuy@gmail.com', 'TTThuy!98$Mypass', 'Trần Thị Thùy', '1995-08-15', 'TP.HCM', 'Nữ', '0912345002', 'Hoạt động'),
('levanchien@gmail.com', 'LVChien@Secure99*', 'Lê Văn Chiến', '1992-03-22', 'Đà Nẵng', 'Nam', '0909123003', 'Hoạt động'),
('phamminhduc@gmail.com', 'PMDuc_2024!Secure$', 'Phạm Minh Đức', '2000-02-20', 'Hải Phòng', 'Nam', '0988888004', 'Hoạt động'),
('dangthihanh@gmail.com', 'DTHanh#Pass_77@!', 'Đặng Thị Hạnh', '1998-07-12', 'Cần Thơ', 'Nữ', '0977777005', 'Hoạt động'),
('hoangminhphuc@gmail.com', 'HMP_#88*Pass', 'Hoàng Minh Phúc', '1988-09-30', 'Huế', 'Nam', '0922233006', 'Hoạt động'),
('ngothithanh@gmail.com', 'NTThanh@Mypass123!', 'Ngô Thị Thanh', '1993-06-18', 'Bắc Ninh', 'Nữ', '0944455007', 'Hoạt động'),
('vuquocanh@gmail.com', 'VQA!2024$*Pass', 'Vũ Quốc Anh', '1997-11-25', 'Hải Dương', 'Nam', '0933344008', 'Hoạt động'),
('dangthimai@gmail.com', 'DTMai@Pass_55$', 'Đặng Thị Mai', '1996-12-05', 'Bình Dương', 'Nữ', '0911122009', 'Không hoạt động'),
('trananhduy@gmail.com', 'TADuy@88*#Pass', 'Trần Anh Duy', '1985-04-14', 'Hà Giang', 'Nam', '0966677010', 'Hoạt động'),
('nguyenvanlong@gmail.com', 'NVLong_99#Pass!', 'Nguyễn Văn Long', '1991-07-07', 'Phú Thọ', 'Nam', '0908877111', 'Hoạt động'),
('phamthiminh@gmail.com', 'PTMinh!2024_XX*', 'Phạm Thị Minh', '1994-02-03', 'Vĩnh Long', 'Nữ', '095555512', 'Không hoạt động'),
('lethanhnhan@gmail.com', 'LTNhan@Pass777$', 'Lê Thành Nhân', '1999-05-23', 'Hòa Bình', 'Nam', '098222213', 'Hoạt động'),
('hoangthian@gmail.com', 'HTAn!Mypass66*', 'Hoàng Thị An', '2001-01-01', 'Đồng Nai', 'Nữ', '092001414', 'Hoạt động'),
('dangquocphong@gmail.com', 'DQP@Pass*123$', 'Đặng Quốc Phong', '1989-09-09', 'Lạng Sơn', 'Nam', '091111515', 'Hoạt động'),
('vuthihue@gmail.com', 'VTHue!My99$*Pass', 'Vũ Thị Huệ', '1992-12-12', 'Hà Nam', 'Nữ', '090990016', 'Hoạt động'),
('nguyenminhtruong@gmail.com', 'NMTuong_@88*Secure', 'Nguyễn Minh Trường', '1996-10-20', 'Bình Thuận', 'Nam', '097332217', 'Không hoạt động'),
('lethithao@gmail.com', 'LTThao@Pass2024$*', 'Lê Thị Thảo', '1993-08-08', 'Quảng Ninh', 'Nữ', '093443318', 'Hoạt động'),
('nguyenhoangtu@gmail.com', 'NHTu_2024!Secure*', 'Nguyễn Hoàng Tú', '1995-05-15', 'Cà Mau', 'Nam', '099887719', 'Hoạt động'),
('phanthiut@gmail.com', 'PTUyen!Secure88#$', 'Phan Thị Uyên', '1998-07-04', 'Nam Định', 'Nữ', '095667720', 'Không hoạt động'),
('vominhvu@gmail.com', 'VMVu_2024*Pass!', 'Võ Minh Vũ', '2002-02-02', 'Hậu Giang', 'Nam', '091554421', 'Hoạt động'),
('buidieulam@gmail.com', 'BDLam!Pass99*$', 'Bùi Diệu Lâm', '1997-11-11', 'Tây Ninh', 'Nữ', '092441522', 'Hoạt động'),
('dothianhthu@gmail.com', 'DTAnhThu@Pass*XX2024', 'Đỗ Thị Anh Thư', '1991-06-06', 'Sơn La', 'Nữ', '096777623', 'Hoạt động'),
('huynhminhyen@gmail.com', 'HMYen!Secure_88#$', 'Huỳnh Minh Yến', '1993-09-19', 'Kon Tum', 'Nam', '099776624', 'Không hoạt động'),
('dinhngocquyen@gmail.com', 'DNQuyen_@2024Pass*', 'Đinh Ngọc Quyền', '2000-12-21', 'Yên Bái', 'Nam', '090443725', 'Hoạt động'),
('phambaotuan@gmail.com', 'PBTuan!Pass*99$', 'Phạm Bảo Tuấn', '1994-03-31', 'Bắc Giang', 'Nam', '095554826', 'Hoạt động'),
('trankhanhduy@gmail.com', 'TKDuy@Secure2024$', 'Trần Khánh Duy', '1988-10-10', 'Kiên Giang', 'Nam', '091332627', 'Hoạt động'),
('hoangnhithu@gmail.com', 'HNhThu_88#Mypass!', 'Hoàng Nhị Thư', '1996-02-18', 'Gia Lai', 'Nữ', '092001528', 'Hoạt động'),
('lethidieu@gmail.com', 'LTDieu_99!Pass2024', 'Lê Thị Diệu', '1999-07-09', 'Nghệ An', 'Nữ', '096776729', 'Hoạt động'),
('dangtrongkhoa@gmail.com', 'DTKhoa!SecurePass#', 'Đặng Trọng Khoa', '2001-05-05', 'Thái Bình', 'Nam', '093998730', 'Không hoạt động');


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[checkin] (bảng check in)
INSERT INTO checkin (MaNguoiDung, ThoiGianVao, ThoiGianRa, TrangThai) VALUES
(101, '2024-04-01 08:00:00', '2024-04-01 10:00:00', 'Checked In'),
(102, '2024-04-01 09:15:00', '2024-04-01 11:15:00', 'Checked In'),
(103, '2024-04-01 07:45:00', '2024-04-01 09:45:00', 'Checked In'),
(104, '2024-04-02 10:00:00', '2024-04-02 12:00:00', 'Checked In'),
(105, '2024-04-02 08:30:00', '2024-04-02 10:30:00', 'Checked In'),
(106, '2024-04-02 09:00:00', '2024-04-02 11:00:00', 'Checked In'),
(107, '2024-04-03 07:50:00', '2024-04-03 09:50:00', 'Checked In'),
(108, '2024-04-03 08:20:00', '2024-04-03 10:20:00', 'Checked In'),
(109, '2024-04-03 09:10:00', '2024-04-03 11:10:00', 'Checked In'),
(110, '2024-04-03 08:05:00', '2024-04-03 10:05:00', 'Checked In'),
(108, '2024-04-04 09:00:00', '2024-04-04 12:45:00', 'Checked Out'),
(109, '2024-04-04 08:40:00', '2024-04-04 13:20:00', 'Checked Out'),
(110, '2024-04-04 07:55:00', '2024-04-04 11:55:00', 'Checked Out'),
(104, '2024-04-05 10:10:00', '2024-04-05 14:30:00', 'Checked Out'),
(105, '2024-04-05 09:30:00', '2024-04-05 13:30:00', 'Checked Out'),
(106, '2024-04-05 08:15:00', '2024-04-05 12:00:00', 'Checked Out'),
(101, '2024-04-06 07:30:00', '2024-04-06 11:30:00', 'Checked Out'),
(102, '2024-04-06 09:20:00', '2024-04-06 11:40:00', 'Checked Out'),
(103, '2024-04-06 08:50:00', '2024-04-06 13:10:00', 'Checked Out'),
(107, '2024-04-06 07:45:00', '2024-04-06 10:45:00', 'Checked Out');


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[phong] (bảng phòng)
INSERT INTO phong (TenPhong, LoaiPhong, SucChua, TrangThai, GiaMuon) VALUES
('Phòng Hội thảo 1', 'Hội thảo', 50, 'Trống', 500000),
('Phòng Hội thảo 2', 'Hội thảo', 80, 'Đang mượn', 800000),
('Phòng Họp 1', 'Họp', 10, 'Trống', 150000),
('Phòng Họp 2', 'Họp', 15, 'Bảo trì', 200000),
('Phòng Đa năng 1', 'Đa năng', 30, 'Trống', 300000),
('Phòng Đa năng 2', 'Đa năng', 40, 'Đang mượn', 400000),
('Phòng Làm việc nhóm 1', 'Làm việc nhóm', 6, 'Trống', 100000),
('Phòng Làm việc nhóm 2', 'Làm việc nhóm', 8, 'Đang mượn', 120000),
('Phòng Thuyết trình 1', 'Thuyết trình', 20, 'Trống', 250000),
('Phòng Thuyết trình 2', 'Thuyết trình', 25, 'Bảo trì', 280000),
('Phòng Hội thảo 3', 'Hội thảo', 60, 'Trống', 600000),
('Phòng Họp 3', 'Họp', 12, 'Đang mượn', 180000),
('Phòng Đa năng 3', 'Đa năng', 35, 'Trống', 350000),
('Phòng Làm việc nhóm 3', 'Làm việc nhóm', 7, 'Đang mượn', 110000),
('Phòng Thuyết trình 3', 'Thuyết trình', 22, 'Trống', 260000),
('Phòng Hội thảo 4', 'Hội thảo', 70, 'Bảo trì', 700000),
('Phòng Họp 4', 'Họp', 14, 'Trống', 190000),
('Phòng Đa năng 4', 'Đa năng', 45, 'Đang mượn', 450000),
('Phòng Làm việc nhóm 4', 'Làm việc nhóm', 9, 'Trống', 130000),
('Phòng Thuyết trình 4', 'Thuyết trình', 28, 'Đang mượn', 300000);


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[phieumuonphong] (bảng phiếu mượn phòng)
INSERT INTO phieumuonphong (MaPhong, MaNguoiDung, ThoiGianMuon, ThoiGianTra, TrangThai, TongTien) VALUES
(7, 81, '2025-04-05 10:00:00', '2025-04-07 12:00:00', 'Đang mượn', 200000),
(8, 82, '2025-04-05 14:30:00', '2025-04-06 16:00:00', 'Đã trả', 150000),
(9, 83, '2025-04-06 09:00:00', '2025-04-09 11:00:00', 'Đang mượn', 300000),
(17, 84, '2025-04-06 15:00:00', '2025-04-06 17:00:00', 'Đã trả', 100000),
(18, 85, '2025-04-07 11:30:00', '2025-04-10 13:00:00', 'Đang mượn', 250000),
(19, 86, '2025-04-07 16:00:00', '2025-04-18 10:00:00', 'Đang mượn', 100000),
(20, 87, '2025-04-08 08:00:00', '2025-04-08 10:00:00', 'Đã trả', 100000),
(21, 88, '2025-04-08 13:00:00', '2025-04-11 15:00:00', 'Đang mượn', 350000),
(22, 89, '2025-04-09 10:30:00', '2025-04-09 12:30:00', 'Đã trả', 120000),
(23, 90, '2025-04-09 16:30:00', '2025-04-12 18:00:00', 'Đang mượn', 280000),
(24, 91, '2025-04-10 09:30:00', '2025-04-19 10:00:00', 'Đang mượn', 180000),
(25, 92, '2025-04-10 14:00:00', '2025-04-10 16:00:00', 'Đã trả', 90000),
(26, 93, '2025-04-11 11:00:00', '2025-04-14 13:00:00', 'Đang mượn', 320000),
(27, 94, '2025-04-11 17:00:00', '2025-04-11 19:00:00', 'Đã trả', 110000),
(28, 95, '2025-04-12 10:00:00', '2025-04-15 12:00:00', 'Đang mượn', 260000),
(29, 96, '2025-04-12 15:30:00', '2025-04-20 10:00:00', 'Đang mượn', 190000),
(30, 97, '2025-04-13 08:30:00', '2025-04-13 10:30:00', 'Đã trả', 105000),
(31, 98, '2025-04-13 14:30:00', '2025-04-16 16:30:00', 'Đang mượn', 330000),
(32, 99, '2025-04-14 11:30:00', '2025-04-14 13:30:00', 'Đã trả', 115000),
(33, 100, '2025-04-14 17:30:00', '2025-04-17 19:00:00', 'Đang mượn', 290000);


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[phieumuonthietbi] (bảng phiếu mượn thiết bị)
INSERT INTO phieumuonthietbi (MaNguoiDung, MaThietBi, TrangThai, ThoiGianMuon, ThoiGianTra, TongTien) VALUES
(81, 1, 'Đang mượn', '2025-04-05 10:00:00', '2025-04-07 12:00:00', 200000),
(82, 2, 'Đã trả', '2025-04-05 14:30:00', '2025-04-06 16:00:00', 150000),
(83, 3, 'Đang mượn', '2025-04-06 09:00:00', '2025-04-09 11:00:00', 300000),
(84, 4, 'Đã trả', '2025-04-06 15:00:00', '2025-04-06 17:00:00', 100000),
(85, 5, 'Đang mượn', '2025-04-07 11:30:00', '2025-04-10 13:00:00', 250000),
(86, 6, 'Đang mượn', '2025-04-07 16:00:00', '2025-04-18 10:00:00', 100000),
(87, 7, 'Đã trả', '2025-04-08 08:00:00', '2025-04-08 10:00:00', 100000),
(88, 8, 'Đang mượn', '2025-04-08 13:00:00', '2025-04-11 15:00:00', 350000),
(89, 1, 'Đã trả', '2025-04-09 10:30:00', '2025-04-09 12:30:00', 120000),
(90, 2, 'Đang mượn', '2025-04-09 16:30:00', '2025-04-12 18:00:00', 280000),
(91, 3, 'Đang mượn', '2025-04-10 09:30:00', '2025-04-19 10:00:00', 180000),
(92, 4, 'Đã trả', '2025-04-10 14:00:00', '2025-04-10 16:00:00', 90000),
(93, 5, 'Đang mượn', '2025-04-11 11:00:00', '2025-04-14 13:00:00', 320000),
(94, 6, 'Đã trả', '2025-04-11 17:00:00', '2025-04-11 19:00:00', 110000),
(95, 7, 'Đang mượn', '2025-04-12 10:00:00', '2025-04-15 12:00:00', 260000),
(96, 8, 'Đang mượn', '2025-04-12 15:30:00', '2025-04-20 10:00:00', 190000),
(97, 1, 'Đã trả', '2025-04-13 08:30:00', '2025-04-13 10:30:00', 105000),
(98, 2, 'Đang mượn', '2025-04-13 14:30:00', '2025-04-16 16:30:00', 330000),
(99, 3, 'Đã trả', '2025-04-14 11:30:00', '2025-04-14 13:30:00', 115000),
(100, 4, 'Đang mượn', '2025-04-14 17:30:00', '2025-04-17 19:00:00', 290000);


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[phieutra] (bảng phiếu trả)
INSERT INTO phieutra (MaNguoiDung, ThoiGianTra, TongTienPhaiTra, TienPhat) VALUES
(81, '2025-04-07 12:00:00', 200000, 0),
(82, '2025-04-06 16:00:00', 150000, 0),
(83, '2025-04-09 11:00:00', 300000, 50000),
(84, '2025-04-06 17:00:00', 100000, 0),
(85, '2025-04-10 13:00:00', 250000, 0),
(86, '2025-04-18 10:00:00', 100000, 20000),
(87, '2025-04-08 10:00:00', 100000, 0),
(88, '2025-04-11 15:00:00', 350000, 0),
(89, '2025-04-09 12:30:00', 120000, 0),
(90, '2025-04-12 18:00:00', 280000, 0);


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[thanhtoan] (bảng thanh toán)
INSERT INTO thanhtoan (MaPhieuTra, TongTienPhaiTra, NgayThanhToan, HinhThucThanhToan) VALUES
(1, 200000, '2025-04-07 12:00:00', 'Tiền mặt'),
(2, 150000, '2025-04-06 16:00:00', 'Chuyển khoản'),
(3, 300000, '2025-04-09 11:00:00', 'Tiền mặt'),
(4, 100000, '2025-04-06 17:00:00', 'Chuyển khoản'),
(5, 250000, '2025-04-10 13:00:00', 'Tiền mặt'),
(6, 100000, '2025-04-18 10:00:00', 'Chuyển khoản'),
(7, 100000, '2025-04-08 10:00:00', 'Tiền mặt'),
(8, 350000, '2025-04-11 15:00:00', 'Chuyển khoản'),
(9, 120000, '2025-04-09 12:30:00', 'Tiền mặt'),
(10, 280000, '2025-04-12 18:00:00', 'Chuyển khoản'),
(1, 200000, '2025-04-07 12:00:00', 'Tiền mặt'),
(2, 150000, '2025-04-06 16:00:00', 'Chuyển khoản'),
(3, 300000, '2025-04-09 11:00:00', 'Tiền mặt'),
(4, 100000, '2025-04-06 17:00:00', 'Chuyển khoản'),
(5, 250000, '2025-04-10 13:00:00', 'Tiền mặt'),
(6, 100000, '2025-04-18 10:00:00', 'Chuyển khoản'),
(7, 100000, '2025-04-08 10:00:00', 'Tiền mặt'),
(8, 350000, '2025-04-11 15:00:00', 'Chuyển khoản'),
(9, 120000, '2025-04-09 12:30:00', 'Tiền mặt'),
(10, 280000, '2025-04-12 18:00:00', 'Chuyển khoản'),
(1, 200000, '2025-04-07 12:00:00', 'Tiền mặt'),
(2, 150000, '2025-04-06 16:00:00', 'Chuyển khoản'),
(3, 300000, '2025-04-09 11:00:00', 'Tiền mặt'),
(4, 100000, '2025-04-06 17:00:00', 'Chuyển khoản'),
(5, 250000, '2025-04-10 13:00:00', 'Tiền mặt'),
(6, 100000, '2025-04-18 10:00:00', 'Chuyển khoản'),
(7, 100000, '2025-04-08 10:00:00', 'Tiền mặt'),
(8, 350000, '2025-04-11 15:00:00', 'Chuyển khoản'),
(9, 120000, '2025-04-09 12:30:00', 'Tiền mặt'),
(10, 280000, '2025-04-12 18:00:00', 'Chuyển khoản');


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[thongbao] (bảng thông báo)
INSERT INTO thongbao (MaNguoiDung, TieuDe, NoiDung, LoaiThongBao, ThoiGianGui) VALUES
(81, 'Thông báo chung 1', 'Nội dung thông báo chung 1...', 'Chung', '2025-04-05 10:00:00'),
(82, 'Thông báo vi phạm 1', 'Nội dung thông báo vi phạm 1...', 'Vi Phạm', '2025-04-05 14:30:00'),
(83, 'Sự kiện 1', 'Nội dung sự kiện 1...', 'Sự Kiện', '2025-04-06 09:00:00'),
(84, 'Thông báo chung 2', 'Nội dung thông báo chung 2...', 'Chung', '2025-04-06 15:00:00'),
(85, 'Thông báo vi phạm 2', 'Nội dung thông báo vi phạm 2...', 'Vi Phạm', '2025-04-07 11:30:00'),
(86, 'Sự kiện 2', 'Nội dung sự kiện 2...', 'Sự Kiện', '2025-04-07 16:00:00'),
(87, 'Thông báo chung 3', 'Nội dung thông báo chung 3...', 'Chung', '2025-04-08 08:00:00'),
(88, 'Thông báo vi phạm 3', 'Nội dung thông báo vi phạm 3...', 'Vi Phạm', '2025-04-08 13:00:00'),
(89, 'Sự kiện 3', 'Nội dung sự kiện 3...', 'Sự Kiện', '2025-04-09 10:30:00'),
(90, 'Thông báo chung 4', 'Nội dung thông báo chung 4...', 'Chung', '2025-04-09 16:30:00'),
(91, 'Thông báo vi phạm 4', 'Nội dung thông báo vi phạm 4...', 'Vi Phạm', '2025-04-10 09:30:00'),
(92, 'Sự kiện 4', 'Nội dung sự kiện 4...', 'Sự Kiện', '2025-04-10 14:00:00'),
(93, 'Thông báo chung 5', 'Nội dung thông báo chung 5...', 'Chung', '2025-04-11 11:00:00'),
(94, 'Thông báo vi phạm 5', 'Nội dung thông báo vi phạm 5...', 'Vi Phạm', '2025-04-11 17:00:00'),
(95, 'Sự kiện 5', 'Nội dung sự kiện 5...', 'Sự Kiện', '2025-04-12 10:00:00'),
(96, 'Thông báo chung 6', 'Nội dung thông báo chung 6...', 'Chung', '2025-04-12 15:30:00'),
(97, 'Thông báo vi phạm 6', 'Nội dung thông báo vi phạm 6...', 'Vi Phạm', '2025-04-13 08:30:00'),
(98, 'Sự kiện 6', 'Nội dung sự kiện 6...', 'Sự Kiện', '2025-04-13 14:30:00'),
(99, 'Thông báo chung 7', 'Nội dung thông báo chung 7...', 'Chung', '2025-04-14 11:30:00'),
(100, 'Thông báo vi phạm 7', 'Nội dung thông báo vi phạm 7...', 'Vi Phạm', '2025-04-14 17:30:00');


-- CHÈN DỮ LIỆU VÀO BẢNG [dbo].[vipham] (bảng vi phạm)
INSERT INTO vipham (MaNguoiDung, MaThietBi, MaPhong, LoaiViPham, NoiDungViPham) VALUES
(81, 1, 7, 'Trả trễ', 'Trả thiết bị trễ 2 ngày.'),
(85, 3, 9, 'Làm hỏng', 'Làm hỏng màn hình máy chiếu.'),
(92, 2, 8, 'Làm mất', 'Làm mất micro không dây.'),
(98, 5, 17, 'Khác', 'Sử dụng phòng không đúng quy định.'),
(100, 4, 20, 'Trả trễ', 'Trả phòng trễ 1 ngày.');