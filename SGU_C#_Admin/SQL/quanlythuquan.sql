USE master;
GO

-- Drop database if exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'quanlythuquan')
BEGIN
    ALTER DATABASE quanlythuquan SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE quanlythuquan;
END
GO

-- Create new database
CREATE DATABASE quanlythuquan;
GO

USE quanlythuquan;
GO

-- Drop existing tables in correct order (reverse of creation order)
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vipham]') AND type in (N'U'))
    DROP TABLE [dbo].[vipham];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[thongbao]') AND type in (N'U'))
    DROP TABLE [dbo].[thongbao];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[thanhtoan]') AND type in (N'U'))
    DROP TABLE [dbo].[thanhtoan];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[phieutra]') AND type in (N'U'))
    DROP TABLE [dbo].[phieutra];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[phieumuonthietbi]') AND type in (N'U'))
    DROP TABLE [dbo].[phieumuonthietbi];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[phieumuonphong]') AND type in (N'U'))
    DROP TABLE [dbo].[phieumuonphong];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[checkin]') AND type in (N'U'))
    DROP TABLE [dbo].[checkin];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[thietbi]') AND type in (N'U'))
    DROP TABLE [dbo].[thietbi];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[phong]') AND type in (N'U'))
    DROP TABLE [dbo].[phong];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nguoidung]') AND type in (N'U'))
    DROP TABLE [dbo].[nguoidung];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[quyen]') AND type in (N'U'))
    DROP TABLE [dbo].[quyen];

-- Continue with table creation and data insertion...


CREATE TABLE quyen (
    MaQuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenQuyen NVARCHAR(50) NOT NULL CHECK (TenQuyen IN (N'Admin', N'User'))
);

CREATE TABLE nguoidung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    MaQuyen INT NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    HoVaTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    SoDienThoai NVARCHAR(15) UNIQUE NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động')),
    FOREIGN KEY (MaQuyen) REFERENCES quyen(MaQuyen)
);

CREATE TABLE thietbi (
    MaThietBi INT IDENTITY(1,1) PRIMARY KEY,
    TenThietBi NVARCHAR(100) UNIQUE NOT NULL,
    LoaiThietBi NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL CHECK (TrangThai IN (N'Có sẵn', N'Đang sử dụng', N'Bảo trì')),
    GiaMuon DECIMAL(18,0) NOT NULL
);

CREATE TABLE phong (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(100) UNIQUE NOT NULL,
    LoaiPhong NVARCHAR(50) NOT NULL,
    SucChua INT NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL CHECK (TrangThai IN (N'Trống', N'Đang mượn', N'Bảo trì')),
    GiaMuon DECIMAL(18,0) NOT NULL
);

CREATE TABLE checkin (
    MaCheckIn INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    ThoiGianVao DATETIME NOT NULL,
    ThoiGianRa DATETIME NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL CHECK (TrangThai IN (N'Checked In', N'Checked Out')),
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung)
);

CREATE TABLE phieumuonphong (
    MaPhieuMuonPhong INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT NOT NULL,
    MaNguoiDung INT NOT NULL,
    ThoiGianMuon DATETIME NOT NULL,
    ThoiGianTra DATETIME NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL CHECK (TrangThai IN (N'Đang mượn', N'Đã trả')),
    TongTien DECIMAL(18,0) NOT NULL,
    FOREIGN KEY (MaPhong) REFERENCES phong(MaPhong),
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung)
);

CREATE TABLE phieumuonthietbi (
    MaPhieuMuonThietBi INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    MaThietBi INT NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL CHECK (TrangThai IN (N'Đang mượn', N'Đã trả')),
    ThoiGianMuon DATETIME NOT NULL,
    ThoiGianTra DATETIME NOT NULL,
    TongTien DECIMAL(18,0) NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung),
    FOREIGN KEY (MaThietBi) REFERENCES thietbi(MaThietBi)
);

CREATE TABLE phieutra (
    MaPhieuTra INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    ThoiGianTra DATETIME NOT NULL,
    TongTienPhaiTra DECIMAL(18,0) NOT NULL,
    TienPhat DECIMAL(18,0) NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung)
);

CREATE TABLE thanhtoan (
    MaThanhToan INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuTra INT NOT NULL,
    TongTienPhaiTra DECIMAL(18,0) NOT NULL,
    NgayThanhToan DATETIME NOT NULL,
    HinhThucThanhToan NVARCHAR(50) NOT NULL CHECK (HinhThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản')),
    FOREIGN KEY (MaPhieuTra) REFERENCES phieutra(MaPhieuTra)
);

CREATE TABLE thongbao (
    MaThongBao INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    TieuDe NVARCHAR(100) NOT NULL,
    NoiDung NVARCHAR(500) NOT NULL,
    LoaiThongBao NVARCHAR(20) NOT NULL CHECK (LoaiThongBao IN (N'Chung', N'Vi Phạm', N'Sự Kiện')),
    ThoiGianGui DATETIME NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung)
);

CREATE TABLE vipham (
    MaViPham INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    LoaiViPham NVARCHAR(50) NOT NULL CHECK (LoaiViPham IN (N'Trả trễ', N'Làm hỏng', N'Làm mất', N'Khác')),
    NoiDungViPham NVARCHAR(500) NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES nguoidung(MaNguoiDung)
);

-- Chèn dữ liệu vào bảng quyen
INSERT INTO [dbo].[quyen] ([TenQuyen]) VALUES (N'Admin'), (N'User');

-- Chèn dữ liệu vào bảng nguoidung
INSERT INTO [dbo].[nguoidung] ([MaQuyen], [Email], [MatKhau], [HoVaTen], [NgaySinh], [DiaChi], [GioiTinh], [SoDienThoai], [TrangThai])
VALUES
    (1, N'admin@gmail.com', N'admin123', N'Admin', '2004-07-22', N'123 Tân Thới Nhất, HCM', N'Nam', N'0987654001', N'Hoạt động'),
    (1, N'vincenttuan1098@gmail.com', N'nqtuan123', N'Nguyễn Quốc Tuấn', '2004-07-22', N'123 Xuân Thới Đông, HCM', N'Nam', N'0354525657', N'Hoạt động'),
    (2, N'phamthituongvy@gmail.com', N'pttvy123', N'Phạm Thị Tường Vy', '2004-01-03', N'HCM', N'Nữ', N'0354696871', N'Hoạt động'),
    (2, N'dinhlecamtu@gmail.com', N'dlctu123', N'Đinh Lê Cẩm Tú', '2004-11-11', N'HCM', N'Nữ', N'0354525658', N'Hoạt động'),
    (2, N'nguyenleminhthu@gmail.com', N'nlmthu123', N'Nguyễn Lê Minh Thư', '2004-06-08', N'HCM', N'Nữ', N'0968849220', N'Hoạt động'),
    (2, N'tranthithuy@gmail.com', N'ttthuy123', N'Trần Thị Thùy', '1995-08-15', N'TP.HCM', N'Nữ', N'0912345002', N'Hoạt động'),
    (2, N'levanchien@gmail.com', N'lvchien123', N'Lê Văn Chiến', '1992-03-22', N'Đà Nẵng', N'Nam', N'0909123003', N'Hoạt động'),
    (2, N'phamminhduc@gmail.com', N'pmduc123', N'Phạm Minh Đức', '2000-02-20', N'Hải Phòng', N'Nam', N'0988888004', N'Hoạt động'),
    (2, N'dangthihanh@gmail.com', N'dthanh123', N'Đặng Thị Hạnh', '2003-07-12', N'Cần Thơ', N'Nữ', N'0977777005', N'Hoạt động'),
    (2, N'hoangminhphuc@gmail.com', N'hmphuc123', N'Hoàng Minh Phúc', '1988-09-30', N'Huế', N'Nam', N'0922233006', N'Hoạt động'),
    (2, N'ngothithienthanh@gmail.com', N'nttthanh123', N'Ngô Thị Thiên Thanh', '1993-06-18', N'Bắc Ninh', N'Nữ', N'0944455007', N'Hoạt động'),
    (2, N'vuquocanh@gmail.com', N'vqanh123', N'Vũ Quốc Anh', '1997-11-25', N'Hải Dương', N'Nam', N'0933344008', N'Hoạt động'),
    (2, N'dangthingocmai@gmail.com', N'dtnmai123', N'Đặng Thị Ngọc Mai', '1996-12-05', N'Bình Dương', N'Nữ', N'0911122009', N'Không hoạt động'),
    (2, N'trananhduy@gmail.com', N'taduy123', N'Trần Anh Duy', '2005-04-14', N'Hà Giang', N'Nam', N'0966677010', N'Hoạt động'),
    (2, N'nguyenvanlong@gmail.com', N'nvlong123', N'Nguyễn Văn Long', '1991-07-07', N'Phú Thọ', N'Nam', N'0908877111', N'Hoạt động'),
    (2, N'phamthiminh@gmail.com', N'ptminh123', N'Phạm Thị Minh', '1994-02-03', N'Vĩnh Long', N'Nữ', N'0955555012', N'Không hoạt động'),
    (2, N'lethanhnhan@gmail.com', N'ltnhan123', N'Lê Thành Nhân', '1999-05-23', N'Hòa Bình', N'Nam', N'0982222013', N'Hoạt động'),
    (2, N'hoangthian@gmail.com', N'htan123', N'Hoàng Thị An', '2001-01-01', N'Đồng Nai', N'Nữ', N'0920014014', N'Hoạt động'),
    (2, N'dangquocphong@gmail.com', N'dqphong123', N'Đặng Quốc Phong', '2002-09-09', N'Lạng Sơn', N'Nam', N'0911115015', N'Hoạt động'),
    (2, N'vuthihue@gmail.com', N'vthue123', N'Vũ Thị Huệ', '1992-12-12', N'Hà Nam', N'Nữ', N'0909900016', N'Hoạt động'),
    (2, N'nguyenminhtruong@gmail.com', N'nmtruong123', N'Nguyễn Minh Trường', '1996-10-20', N'Bình Thuận', N'Nam', N'0973322017', N'Không hoạt động'),
    (2, N'lethithao@gmail.com', N'ltthao123', N'Lê Thị Thảo', '1993-08-08', N'Quảng Ninh', N'Nữ', N'0934433018', N'Hoạt động'),
    (2, N'nguyenhoangtu@gmail.com', N'nhtu123', N'Nguyễn Hoàng Tú', '1995-05-15', N'Cà Mau', N'Nam', N'0998877019', N'Hoạt động'),
    (2, N'phanthiuyen@gmail.com', N'ptuyen123', N'Phan Thị Uyên', '1998-07-04', N'Nam Định', N'Nữ', N'0956677020', N'Không hoạt động'),
    (2, N'vominhvu@gmail.com', N'vmvu123', N'Võ Minh Vũ', '2002-02-02', N'Hậu Giang', N'Nam', N'0915544021', N'Hoạt động'),
    (2, N'buidieulam@gmail.com', N'bdlam123', N'Bùi Diệu Lâm', '1997-11-11', N'Tây Ninh', N'Nữ', N'0924415022', N'Hoạt động'),
    (2, N'dothianhthu@gmail.com', N'dtathu123', N'Đỗ Thị Anh Thư', '2005-06-06', N'Sơn La', N'Nữ', N'0967776023', N'Hoạt động'),
    (2, N'huynhminhyen@gmail.com', N'hmyen123', N'Huỳnh Minh Yến', '1993-09-19', N'Kon Tum', N'Nam', N'0997766024', N'Không hoạt động'),
    (2, N'dinhngocquyen@gmail.com', N'dnquyen123', N'Đinh Ngọc Quyền', '2000-12-21', N'Yên Bái', N'Nam', N'0904437025', N'Hoạt động'),
    (2, N'phambaotuan@gmail.com', N'pbtuan123', N'Phạm Bảo Tuấn', '1994-03-31', N'Bắc Giang', N'Nam', N'0955548026', N'Hoạt động'),
    (2, N'doankhanhduy@gmail.com', N'dkduy123', N'Đoàn Khánh Duy', '2004-02-29', N'Kiên Giang', N'Nam', N'0913326027', N'Hoạt động'),
    (2, N'hoangnhithu@gmail.com', N'hnthu123', N'Hoàng Nhị Thư', '1996-02-18', N'Gia Lai', N'Nữ', N'0920015028', N'Hoạt động'),
    (2, N'lethidieu@gmail.com', N'ltdieu123', N'Lê Thị Diệu', '1999-07-09', N'Nghệ An', N'Nữ', N'0967767029', N'Hoạt động'),
    (2, N'dangtrongkhoa@gmail.com', N'dtkhoa123', N'Đặng Trọng Khoa', '2001-05-05', N'Thái Bình', N'Nam', N'0939987030', N'Không hoạt động'),
    (1, N'phupham422@gmail.com', N'ptphu123', N'Phạm Thiên Phú', '2004-01-17', N'HCM', N'Nam', N'0886734325', N'Hoạt động');

-- Chèn dữ liệu vào bảng thietbi
INSERT INTO [dbo].[thietbi] ([TenThietBi], [LoaiThietBi], [TrangThai], [GiaMuon])
VALUES
    (N'Máy chiếu Epson EB-X05', N'Máy chiếu', N'Có sẵn', 50000),
    (N'Laptop Dell XPS 13', N'Máy tính xách tay', N'Có sẵn', 100000),
    (N'Máy in HP LaserJet Pro', N'Máy in', N'Đang sử dụng', 30000),
    (N'Loa Bluetooth JBL', N'Thiết bị âm thanh', N'Có sẵn', 20000),
    (N'Máy ảnh Canon EOS 80D', N'Máy ảnh', N'Bảo trì', 80000),
    (N'Bảng trắng thông minh', N'Thiết bị trình chiếu', N'Có sẵn', 60000),
    (N'Tai nghe Sony WH-1000XM4', N'Thiết bị âm thanh', N'Có sẵn', 25000),
    (N'Máy scan Brother ADS-2200', N'Máy scan', N'Có sẵn', 35000),
    (N'Máy chiếu Sony VPL-DX220', N'Máy chiếu', N'Có sẵn', 55000),
    (N'Laptop HP Spectre x360', N'Máy tính xách tay', N'Đang sử dụng', 110000),
    (N'Máy in Canon PIXMA', N'Máy in', N'Có sẵn', 32000),
    (N'Loa Bose SoundLink', N'Thiết bị âm thanh', N'Có sẵn', 22000),
    (N'Máy ảnh Nikon D7500', N'Máy ảnh', N'Có sẵn', 85000),
    (N'Bảng tương tác Samsung', N'Thiết bị trình chiếu', N'Có sẵn', 65000),
    (N'Tai nghe Bose QC35', N'Thiết bị âm thanh', N'Đang sử dụng', 27000),
    (N'Máy scan Epson DS-530', N'Máy scan', N'Có sẵn', 37000),
    (N'Máy chiếu BenQ MX550', N'Máy chiếu', N'Có sẵn', 52000),
    (N'Laptop Lenovo ThinkPad', N'Máy tính xách tay', N'Có sẵn', 105000),
    (N'Máy in Brother HL-L2350', N'Máy in', N'Bảo trì', 31000),
    (N'Loa Anker Soundcore', N'Thiết bị âm thanh', N'Có sẵn', 21000),
    (N'Máy ảnh Sony Alpha A6400', N'Máy ảnh', N'Có sẵn', 82000),
    (N'Bảng trắng Panasonic', N'Thiết bị trình chiếu', N'Có sẵn', 62000),
    (N'Tai nghe JBL Live 650', N'Thiết bị âm thanh', N'Có sẵn', 26000),
    (N'Máy scan Fujitsu fi-7160', N'Máy scan', N'Có sẵn', 36000),
    (N'Máy chiếu ViewSonic PA503S', N'Máy chiếu', N'Có sẵn', 53000),
    (N'Laptop Asus ZenBook', N'Máy tính xách tay', N'Đang sử dụng', 108000),
    (N'Máy in Epson L3150', N'Máy in', N'Có sẵn', 33000),
    (N'Loa Harman Kardon', N'Thiết bị âm thanh', N'Có sẵn', 23000),
    (N'Máy ảnh Fujifilm X-T30', N'Máy ảnh', N'Có sẵn', 83000),
    (N'Bảng tương tác LG', N'Thiết bị trình chiếu', N'Có sẵn', 64000);

-- Chèn dữ liệu vào bảng phong
INSERT INTO [dbo].[phong] ([TenPhong], [LoaiPhong], [SucChua], [TrangThai], [GiaMuon])
VALUES
    (N'Phòng Hội thảo 1', N'Hội thảo', 50, N'Trống', 500000),
    (N'Phòng Hội thảo 2', N'Hội thảo', 80, N'Đang mượn', 800000),
    (N'Phòng Họp 1', N'Họp', 10, N'Trống', 150000),
    (N'Phòng Họp 2', N'Họp', 15, N'Bảo trì', 200000),
    (N'Phòng Đa năng 1', N'Đa năng', 30, N'Trống', 300000),
    (N'Phòng Đa năng 2', N'Đa năng', 40, N'Đang mượn', 400000),
    (N'Phòng Làm việc nhóm 1', N'Làm việc nhóm', 6, N'Trống', 100000),
    (N'Phòng Làm việc nhóm 2', N'Làm việc nhóm', 8, N'Đang mượn', 120000),
    (N'Phòng Thuyết trình 1', N'Thuyết trình', 20, N'Trống', 250000),
    (N'Phòng Thuyết trình 2', N'Thuyết trình', 25, N'Bảo trì', 280000),
    (N'Phòng Hội thảo 3', N'Hội thảo', 60, N'Trống', 600000),
    (N'Phòng Họp 3', N'Họp', 12, N'Đang mượn', 180000),
    (N'Phòng Đa năng 3', N'Đa năng', 35, N'Trống', 350000),
    (N'Phòng Làm việc nhóm 3', N'Làm việc nhóm', 7, N'Đang mượn', 110000),
    (N'Phòng Thuyết trình 3', N'Thuyết trình', 22, N'Trống', 260000),
    (N'Phòng Hội thảo 4', N'Hội thảo', 70, N'Bảo trì', 700000),
    (N'Phòng Họp 4', N'Họp', 14, N'Trống', 190000),
    (N'Phòng Đa năng 4', N'Đa năng', 45, N'Đang mượn', 450000),
    (N'Phòng Làm việc nhóm 4', N'Làm việc nhóm', 9, N'Trống', 130000),
    (N'Phòng Thuyết trình 4', N'Thuyết trình', 28, N'Đang mượn', 300000),
    (N'Phòng Hội thảo 5', N'Hội thảo', 55, N'Trống', 550000),
    (N'Phòng Họp 5', N'Họp', 16, N'Trống', 170000),
    (N'Phòng Đa năng 5', N'Đa năng', 38, N'Đang mượn', 380000),
    (N'Phòng Làm việc nhóm 5', N'Làm việc nhóm', 10, N'Trống', 140000),
    (N'Phòng Thuyết trình 5', N'Thuyết trình', 30, N'Bảo trì', 310000),
    (N'Phòng Hội thảo 6', N'Hội thảo', 65, N'Trống', 650000),
    (N'Phòng Họp 6', N'Họp', 18, N'Đang mượn', 200000),
    (N'Phòng Đa năng 6', N'Đa năng', 42, N'Trống', 420000),
    (N'Phòng Làm việc nhóm 6', N'Làm việc nhóm', 11, N'Trống', 150000),
    (N'Phòng Thuyết trình 6', N'Thuyết trình', 32, N'Đang mượn', 320000);

-- Chèn dữ liệu vào bảng checkin
INSERT INTO [dbo].[checkin] ([MaNguoiDung], [ThoiGianVao], [ThoiGianRa], [TrangThai])
VALUES
    (1, '2025-04-01 08:00:00', '2025-04-01 10:00:00', N'Checked In'),
    (2, '2025-04-01 09:15:00', '2025-04-01 11:15:00', N'Checked In'),
    (3, '2025-04-01 07:45:00', '2025-04-01 09:45:00', N'Checked In'),
    (4, '2025-04-02 10:00:00', '2025-04-02 12:00:00', N'Checked Out'),
    (5, '2025-04-02 08:30:00', '2025-04-02 10:30:00', N'Checked In'),
    (6, '2025-04-02 09:00:00', '2025-04-02 11:00:00', N'Checked Out'),
    (7, '2025-04-03 07:50:00', '2025-04-03 09:50:00', N'Checked Out'),
    (8, '2025-04-03 08:20:00', '2025-04-03 10:20:00', N'Checked In'),
    (9, '2025-04-03 09:10:00', '2025-04-03 11:10:00', N'Checked In'),
    (10, '2025-04-03 08:05:00', '2025-04-03 10:05:00', N'Checked Out'),
    (11, '2025-04-04 09:00:00', '2025-04-04 11:00:00', N'Checked Out'),
    (12, '2025-04-04 08:40:00', '2025-04-04 10:40:00', N'Checked Out'),
    (13, '2025-04-04 07:55:00', '2025-04-04 09:55:00', N'Checked In'),
    (14, '2025-04-05 10:10:00', '2025-04-05 12:10:00', N'Checked In'),
    (15, '2025-04-05 09:30:00', '2025-04-05 11:30:00', N'Checked In'),
    (16, '2025-04-05 08:15:00', '2025-04-05 10:15:00', N'Checked In'),
    (17, '2025-04-06 07:30:00', '2025-04-06 09:30:00', N'Checked In'),
    (18, '2025-04-06 09:20:00', '2025-04-06 11:20:00', N'Checked In'),
    (19, '2025-04-06 08:50:00', '2025-04-06 10:50:00', N'Checked In'),
    (20, '2025-04-06 07:45:00', '2025-04-06 09:45:00', N'Checked Out'),
    (21, '2025-04-07 08:30:00', '2025-04-07 10:30:00', N'Checked Out'),
    (22, '2025-04-07 09:00:00', '2025-04-07 11:00:00', N'Checked Out'),
    (23, '2025-04-07 10:15:00', '2025-04-07 12:15:00', N'Checked In'),
    (24, '2025-04-08 08:45:00', '2025-04-08 10:45:00', N'Checked In'),
    (25, '2025-04-08 09:30:00', '2025-04-08 11:30:00', N'Checked Out'),
    (26, '2025-04-08 10:00:00', '2025-04-08 12:00:00', N'Checked Out'),
    (27, '2025-04-09 07:50:00', '2025-04-09 09:50:00', N'Checked Out'),
    (28, '2025-04-09 08:20:00', '2025-04-09 10:20:00', N'Checked Out'),
    (29, '2025-04-09 09:10:00', '2025-04-09 11:10:00', N'Checked Out'),
    (30, '2025-04-10 08:05:00', '2025-04-10 10:05:00', N'Checked In');

-- Chèn dữ liệu vào bảng phieumuonphong
INSERT INTO [dbo].[phieumuonphong] ([MaPhong], [MaNguoiDung], [ThoiGianMuon], [ThoiGianTra], [TrangThai], [TongTien])
VALUES
    (1, 1, '2025-04-05 10:00:00', '2025-04-05 12:00:00', N'Đã trả', 500000),
    (2, 2, '2025-04-05 14:30:00', '2025-04-06 16:00:00', N'Đã trả', 800000),
    (3, 3, '2025-04-06 09:00:00', '2025-04-06 11:00:00', N'Đã trả', 150000),
    (4, 4, '2025-04-06 15:00:00', '2025-04-07 17:00:00', N'Đã trả', 200000),
    (5, 5, '2025-04-07 11:30:00', '2025-04-07 13:00:00', N'Đã trả', 300000),
    (6, 6, '2025-04-07 16:00:00', '2025-04-08 10:00:00', N'Đã trả', 400000),
    (7, 7, '2025-04-08 08:00:00', '2025-04-08 10:00:00', N'Đã trả', 100000),
    (8, 8, '2025-04-08 13:00:00', '2025-04-09 15:00:00', N'Đã trả', 120000),
    (9, 9, '2025-04-09 10:30:00', '2025-04-09 12:30:00', N'Đã trả', 250000),
    (10, 10, '2025-04-09 16:30:00', '2025-04-10 18:00:00', N'Đã trả', 280000),
    (11, 11, '2025-04-10 09:30:00', '2025-04-10 11:30:00', N'Đã trả', 600000),
    (12, 12, '2025-04-10 14:00:00', '2025-04-11 16:00:00', N'Đã trả', 180000),
    (13, 13, '2025-04-11 11:00:00', '2025-04-11 13:00:00', N'Đã trả', 350000),
    (14, 14, '2025-04-11 17:00:00', '2025-04-12 19:00:00', N'Đã trả', 110000),
    (15, 15, '2025-04-12 10:00:00', '2025-04-12 12:00:00', N'Đã trả', 260000),
    (16, 16, '2025-04-12 15:30:00', '2025-04-13 17:30:00', N'Đã trả', 700000),
    (17, 17, '2025-04-13 08:30:00', '2025-04-13 10:30:00', N'Đã trả', 190000),
    (18, 18, '2025-04-13 14:30:00', '2025-04-14 16:30:00', N'Đã trả', 450000),
    (19, 19, '2025-04-14 11:30:00', '2025-04-14 13:30:00', N'Đã trả', 130000),
    (20, 20, '2025-04-14 17:30:00', '2025-04-15 19:00:00', N'Đã trả', 300000),
    (21, 21, '2025-04-15 09:00:00', '2025-04-15 11:00:00', N'Đã trả', 550000),
    (22, 22, '2025-04-15 14:00:00', '2025-04-16 16:00:00', N'Đã trả', 170000),
    (23, 23, '2025-04-16 10:30:00', '2025-04-16 12:30:00', N'Đã trả', 380000),
    (24, 24, '2025-04-16 15:30:00', '2025-04-17 17:30:00', N'Đã trả', 140000),
    (25, 25, '2025-04-17 08:00:00', '2025-04-17 10:00:00', N'Đã trả', 310000),
    (26, 26, '2025-04-17 13:00:00', '2025-04-18 15:00:00', N'Đã trả', 650000),
    (27, 27, '2025-04-18 09:30:00', '2025-04-18 11:30:00', N'Đã trả', 200000),
    (28, 28, '2025-04-18 14:30:00', '2025-04-19 16:30:00', N'Đã trả', 420000),
    (29, 29, '2025-04-19 11:00:00', '2025-04-19 13:00:00', N'Đã trả', 150000),
    (30, 30, '2025-04-19 16:00:00', '2025-04-20 18:00:00', N'Đã trả', 320000);

-- Chèn dữ liệu vào bảng phieumuonthietbi
INSERT INTO [dbo].[phieumuonthietbi] ([MaNguoiDung], [MaThietBi], [TrangThai], [ThoiGianMuon], [ThoiGianTra], [TongTien])
VALUES
    (1, 1, N'Đã trả', '2025-04-05 10:00:00', '2025-04-05 12:00:00', 50000),
    (2, 2, N'Đã trả', '2025-04-05 14:30:00', '2025-04-06 16:00:00', 100000),
    (3, 3, N'Đã trả', '2025-04-06 09:00:00', '2025-04-06 11:00:00', 30000),
    (4, 4, N'Đã trả', '2025-04-06 15:00:00', '2025-04-07 17:00:00', 20000),
    (5, 5, N'Đã trả', '2025-04-07 11:30:00', '2025-04-07 13:00:00', 80000),
    (6, 6, N'Đã trả', '2025-04-07 16:00:00', '2025-04-08 10:00:00', 60000),
    (7, 7, N'Đã trả', '2025-04-08 08:00:00', '2025-04-08 10:00:00', 25000),
    (8, 8, N'Đã trả', '2025-04-08 13:00:00', '2025-04-09 15:00:00', 35000),
    (9, 9, N'Đã trả', '2025-04-09 10:30:00', '2025-04-09 12:30:00', 55000),
    (10, 10, N'Đã trả', '2025-04-09 16:30:00', '2025-04-10 18:00:00', 110000),
    (11, 11, N'Đã trả', '2025-04-10 09:30:00', '2025-04-10 11:30:00', 32000),
    (12, 12, N'Đã trả', '2025-04-10 14:00:00', '2025-04-11 16:00:00', 22000),
    (13, 13, N'Đã trả', '2025-04-11 11:00:00', '2025-04-11 13:00:00', 85000),
    (14, 14, N'Đã trả', '2025-04-11 17:00:00', '2025-04-12 19:00:00', 65000),
    (15, 15, N'Đã trả', '2025-04-12 10:00:00', '2025-04-12 12:00:00', 27000),
    (16, 16, N'Đã trả', '2025-04-12 15:30:00', '2025-04-13 17:30:00', 37000),
    (17, 17, N'Đã trả', '2025-04-13 08:30:00', '2025-04-13 10:30:00', 52000),
    (18, 18, N'Đã trả', '2025-04-13 14:30:00', '2025-04-14 16:30:00', 105000),
    (19, 19, N'Đã trả', '2025-04-14 11:30:00', '2025-04-14 13:30:00', 31000),
    (20, 20, N'Đã trả', '2025-04-14 17:30:00', '2025-04-15 19:00:00', 21000),
    (21, 21, N'Đã trả', '2025-04-15 09:00:00', '2025-04-15 11:00:00', 82000),
    (22, 22, N'Đã trả', '2025-04-15 14:00:00', '2025-04-16 16:00:00', 62000),
    (23, 23, N'Đã trả', '2025-04-16 10:30:00', '2025-04-16 12:30:00', 26000),
    (24, 24, N'Đã trả', '2025-04-16 15:30:00', '2025-04-17 17:30:00', 36000),
    (25, 25, N'Đã trả', '2025-04-17 08:00:00', '2025-04-17 10:00:00', 53000),
    (26, 26, N'Đã trả', '2025-04-17 13:00:00', '2025-04-18 15:00:00', 108000),
    (27, 27, N'Đã trả', '2025-04-18 09:30:00', '2025-04-18 11:30:00', 33000),
    (28, 28, N'Đã trả', '2025-04-18 14:30:00', '2025-04-19 16:30:00', 23000),
    (29, 29, N'Đã trả', '2025-04-19 11:00:00', '2025-04-19 13:00:00', 83000),
    (30, 30, N'Đã trả', '2025-04-19 16:00:00', '2025-04-20 18:00:00', 64000);

-- Chèn dữ liệu vào bảng phieutra
INSERT INTO [dbo].[phieutra] ([MaNguoiDung], [ThoiGianTra], [TongTienPhaiTra], [TienPhat])
VALUES
    (1, '2025-04-05 12:00:00', 550000, 10000),
    (2, '2025-04-06 16:00:00', 900000, 20000),
    (3, '2025-04-06 11:00:00', 180000, 0),
    (4, '2025-04-07 17:00:00', 220000, 10000),
    (5, '2025-04-07 13:00:00', 380000, 0),
    (6, '2025-04-08 10:00:00', 460000, 0),
    (7, '2025-04-08 10:00:00', 125000, 0),
    (8, '2025-04-09 15:00:00', 155000, 5000),
    (9, '2025-04-09 12:30:00', 305000, 0),
    (10, '2025-04-10 18:00:00', 390000, 10000),
    (11, '2025-04-10 11:30:00', 632000, 0),
    (12, '2025-04-11 16:00:00', 202000, 5000),
    (13, '2025-04-11 13:00:00', 435000, 0),
    (14, '2025-04-12 19:00:00', 175000, 10000),
    (15, '2025-04-12 12:00:00', 287000, 0),
    (16, '2025-04-13 17:30:00', 737000, 20000),
    (17, '2025-04-13 10:30:00', 242000, 0),
    (18, '2025-04-14 16:30:00', 555000, 10000),
    (19, '2025-04-14 13:30:00', 161000, 0),
    (20, '2025-04-15 19:00:00', 321000, 5000),
    (21, '2025-04-15 11:00:00', 632000, 0),
    (22, '2025-04-16 16:00:00', 232000, 10000),
    (23, '2025-04-16 12:30:00', 406000, 0),
    (24, '2025-04-17 17:30:00', 176000, 5000),
    (25, '2025-04-17 10:00:00', 363000, 0),
    (26, '2025-04-18 15:00:00', 758000, 10000),
    (27, '2025-04-18 11:30:00', 233000, 0),
    (28, '2025-04-19 16:30:00', 443000, 5000),
    (29, '2025-04-19 13:00:00', 233000, 0),
    (30, '2025-04-20 18:00:00', 384000, 10000);

-- Chèn dữ liệu vào bảng thanhtoan
INSERT INTO [dbo].[thanhtoan] ([MaPhieuTra], [TongTienPhaiTra], [NgayThanhToan], [HinhThucThanhToan])
VALUES
    (1, 550000, '2025-04-05 12:00:00', N'Tiền mặt'),
    (2, 900000, '2025-04-06 16:00:00', N'Chuyển khoản'),
    (3, 180000, '2025-04-06 11:00:00', N'Tiền mặt'),
    (4, 220000, '2025-04-07 17:00:00', N'Chuyển khoản'),
    (5, 380000, '2025-04-07 13:00:00', N'Tiền mặt'),
    (6, 460000, '2025-04-08 10:00:00', N'Chuyển khoản'),
    (7, 125000, '2025-04-08 10:00:00', N'Tiền mặt'),
    (8, 155000, '2025-04-09 15:00:00', N'Chuyển khoản'),
    (9, 305000, '2025-04-09 12:30:00', N'Tiền mặt'),
    (10, 390000, '2025-04-10 18:00:00', N'Chuyển khoản'),
    (11, 632000, '2025-04-10 11:30:00', N'Tiền mặt'),
    (12, 202000, '2025-04-11 16:00:00', N'Chuyển khoản'),
    (13, 435000, '2025-04-11 13:00:00', N'Tiền mặt'),
    (14, 175000, '2025-04-12 19:00:00', N'Chuyển khoản'),
    (15, 287000, '2025-04-12 12:00:00', N'Tiền mặt'),
    (16, 737000, '2025-04-13 17:30:00', N'Chuyển khoản'),
    (17, 242000, '2025-04-13 10:30:00', N'Tiền mặt'),
    (18, 555000, '2025-04-14 16:30:00', N'Chuyển khoản'),
    (19, 161000, '2025-04-14 13:30:00', N'Tiền mặt'),
    (20, 321000, '2025-04-15 19:00:00', N'Chuyển khoản'),
    (21, 632000, '2025-04-15 11:00:00', N'Tiền mặt'),
    (22, 232000, '2025-04-16 16:00:00', N'Chuyển khoản'),
    (23, 406000, '2025-04-16 12:30:00', N'Tiền mặt'),
    (24, 176000, '2025-04-17 17:30:00', N'Chuyển khoản'),
    (25, 363000, '2025-04-17 10:00:00', N'Tiền mặt'),
    (26, 758000, '2025-04-18 15:00:00', N'Chuyển khoản'),
    (27, 233000, '2025-04-18 11:30:00', N'Tiền mặt'),
    (28, 443000, '2025-04-19 16:30:00', N'Chuyển khoản'),
    (29, 233000, '2025-04-19 13:00:00', N'Tiền mặt'),
    (30, 384000, '2025-04-20 18:00:00', N'Chuyển khoản');

-- Chèn dữ liệu vào bảng thongbao
INSERT INTO [dbo].[thongbao] ([MaNguoiDung], [TieuDe], [NoiDung], [LoaiThongBao], [ThoiGianGui])
VALUES
    (1, N'Thông báo chung 1', N'Nội dung thông báo chung 1...', N'Chung', '2025-04-05 10:00:00'),
    (2, N'Thông báo vi phạm 1', N'Nội dung thông báo vi phạm 1...', N'Vi Phạm', '2025-04-05 14:30:00'),
    (3, N'Sự kiện 1', N'Nội dung sự kiện 1...', N'Sự Kiện', '2025-04-06 09:00:00'),
    (4, N'Thông báo chung 2', N'Nội dung thông báo chung 2...', N'Chung', '2025-04-06 15:00:00'),
    (5, N'Thông báo vi phạm 2', N'Nội dung thông báo vi phạm 2...', N'Vi Phạm', '2025-04-07 11:30:00'),
    (6, N'Sự kiện 2', N'Nội dung sự kiện 2...', N'Sự Kiện', '2025-04-07 16:00:00'),
    (7, N'Thông báo chung 3', N'Nội dung thông báo chung 3...', N'Chung', '2025-04-08 08:00:00'),
    (8, N'Thông báo vi phạm 3', N'Nội dung thông báo vi phạm 3...', N'Vi Phạm', '2025-04-08 13:00:00'),
    (9, N'Sự kiện 3', N'Nội dung sự kiện 3...', N'Sự Kiện', '2025-04-09 10:30:00'),
    (10, N'Thông báo chung 4', N'Nội dung thông báo chung 4...', N'Chung', '2025-04-09 16:30:00'),
    (11, N'Thông báo vi phạm 4', N'Nội dung thông báo vi phạm 4...', N'Vi Phạm', '2025-04-10 09:30:00'),
    (12, N'Sự kiện 4', N'Nội dung sự kiện 4...', N'Sự Kiện', '2025-04-10 14:00:00'),
    (13, N'Thông báo chung 5', N'Nội dung thông báo chung 5...', N'Chung', '2025-04-11 11:00:00'),
    (14, N'Thông báo vi phạm 5', N'Nội dung thông báo vi phạm 5...', N'Vi Phạm', '2025-04-11 17:00:00'),
    (15, N'Sự kiện 5', N'Nội dung sự kiện 5...', N'Sự Kiện', '2025-04-12 10:00:00'),
    (16, N'Thông báo chung 6', N'Nội dung thông báo chung 6...', N'Chung', '2025-04-12 15:30:00'),
    (17, N'Thông báo vi phạm 6', N'Nội dung thông báo vi phạm 6...', N'Vi Phạm', '2025-04-13 08:30:00'),
    (18, N'Sự kiện 6', N'Nội dung sự kiện 6...', N'Sự Kiện', '2025-04-13 14:30:00'),
    (19, N'Thông báo chung 7', N'Nội dung thông báo chung 7...', N'Chung', '2025-04-14 11:30:00'),
    (20, N'Thông báo vi phạm 7', N'Nội dung thông báo vi phạm 7...', N'Vi Phạm', '2025-04-14 17:30:00'),
    (21, N'Sự kiện 7', N'Nội dung sự kiện 7...', N'Sự Kiện', '2025-04-15 09:00:00'),
    (22, N'Thông báo chung 8', N'Nội dung thông báo chung 8...', N'Chung', '2025-04-15 14:00:00'),
    (23, N'Thông báo vi phạm 8', N'Nội dung thông báo vi phạm 8...', N'Vi Phạm', '2025-04-16 10:30:00'),
    (24, N'Sự kiện 8', N'Nội dung sự kiện 8...', N'Sự Kiện', '2025-04-16 15:30:00'),
    (25, N'Thông báo chung 9', N'Nội dung thông báo chung 9...', N'Chung', '2025-04-17 08:00:00'),
    (26, N'Thông báo vi phạm 9', N'Nội dung thông báo vi phạm 9...', N'Vi Phạm', '2025-04-17 13:00:00'),
    (27, N'Sự kiện 9', N'Nội dung sự kiện 9...', N'Sự Kiện', '2025-04-18 09:30:00'),
    (28, N'Thông báo chung 10', N'Nội dung thông báo chung 10...', N'Chung', '2025-04-18 14:30:00'),
    (29, N'Thông báo vi phạm 10', N'Nội dung thông báo vi phạm 10...', N'Vi Phạm', '2025-04-19 11:00:00'),
    (30, N'Sự kiện 10', N'Nội dung sự kiện 10...', N'Sự Kiện', '2025-04-19 16:00:00');

-- Chèn dữ liệu vào bảng vipham
INSERT INTO [dbo].[vipham] ([MaNguoiDung], [LoaiViPham], [NoiDungViPham])
VALUES
    (1, N'Trả trễ', N'Trả thiết bị trễ 2 ngày.'),
    (2, N'Làm hỏng', N'Làm hỏng màn hình máy chiếu.'),
    (3, N'Làm mất', N'Làm mất micro không dây.'),
    (4, N'Khác', N'Sử dụng phòng không đúng quy định.'),
    (5, N'Trả trễ', N'Trả phòng trễ 1 ngày.'),
    (6, N'Làm hỏng', N'Làm hỏng bảng trắng thông minh.'),
    (7, N'Trả trễ', N'Trả tai nghe trễ 3 ngày.'),
    (8, N'Làm mất', N'Làm mất dây cáp máy scan.'),
    (9, N'Khác', N'Sử dụng thiết bị không đúng mục đích.'),
    (10, N'Trả trễ', N'Trả laptop trễ 2 ngày.'),
    (11, N'Làm hỏng', N'Làm hỏng máy in.'),
    (12, N'Làm mất', N'Làm mất loa Bluetooth.'),
    (13, N'Khác', N'Sử dụng phòng họp sai quy định.'),
    (14, N'Trả trễ', N'Trả bảng tương tác trễ 1 ngày.'),
    (15, N'Làm hỏng', N'Làm hỏng tai nghe.'),
    (16, N'Làm mất', N'Làm mất máy scan.'),
    (17, N'Trả trễ', N'Trả máy chiếu trễ 2 ngày.'),
    (18, N'Khác', N'Sử dụng thiết bị không được phép.'),
    (19, N'Làm hỏng', N'Làm hỏng máy in.'),
    (20, N'Trả trễ', N'Trả loa trễ 1 ngày.'),
    (21, N'Làm mất', N'Làm mất máy ảnh.'),
    (22, N'Khác', N'Sử dụng phòng không đúng giờ.'),
    (23, N'Trả trễ', N'Trả tai nghe trễ 2 ngày.'),
    (24, N'Làm hỏng', N'Làm hỏng máy scan.'),
    (25, N'Làm mất', N'Làm mất máy chiếu.'),
    (26, N'Trả trễ', N'Trả laptop trễ 1 ngày.'),
    (27, N'Khác', N'Sử dụng phòng không đúng quy định.'),
    (28, N'Làm hỏng', N'Làm hỏng máy in.'),
    (29, N'Trả trễ', N'Trả loa trễ 2 ngày.'),
    (30, N'Làm mất', N'Làm mất bảng tương tác.');

-- Thêm ràng buộc khóa ngoại sau khi chèn dữ liệu
ALTER TABLE [dbo].[nguoidung]
ADD CONSTRAINT [FK_nguoidung_quyen] FOREIGN KEY ([MaQuyen]) REFERENCES [dbo].[quyen] ([MaQuyen]);

ALTER TABLE [dbo].[checkin]
ADD CONSTRAINT [FK_checkin_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]);

ALTER TABLE [dbo].[phieumuonphong]
ADD CONSTRAINT [FK_phieumuonphong_phong] FOREIGN KEY ([MaPhong]) REFERENCES [dbo].[phong] ([MaPhong]),
    CONSTRAINT [FK_phieumuonphong_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]);

ALTER TABLE [dbo].[phieumuonthietbi]
ADD CONSTRAINT [FK_phieumuonthietbi_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]),
    CONSTRAINT [FK_phieumuonthietbi_thietbi] FOREIGN KEY ([MaThietBi]) REFERENCES [dbo].[thietbi] ([MaThietBi]);

ALTER TABLE [dbo].[phieutra]
ADD CONSTRAINT [FK_phieutra_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]);

ALTER TABLE [dbo].[thanhtoan]
ADD CONSTRAINT [FK_thanhtoan_phieutra] FOREIGN KEY ([MaPhieuTra]) REFERENCES [dbo].[phieutra] ([MaPhieuTra]);

ALTER TABLE [dbo].[thongbao]
ADD CONSTRAINT [FK_thongbao_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]);

ALTER TABLE [dbo].[vipham]
ADD CONSTRAINT [FK_vipham_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]);