SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xóa các bảng nếu đã tồn tại
DROP TABLE IF EXISTS [dbo].[vipham];
DROP TABLE IF EXISTS [dbo].[thongbao];
DROP TABLE IF EXISTS [dbo].[thanhtoan];
DROP TABLE IF EXISTS [dbo].[phieutra];
DROP TABLE IF EXISTS [dbo].[phieumuonthietbi];
DROP TABLE IF EXISTS [dbo].[phieumuonphong];
DROP TABLE IF EXISTS [dbo].[checkin];
DROP TABLE IF EXISTS [dbo].[thietbi];
DROP TABLE IF EXISTS [dbo].[phong];
DROP TABLE IF EXISTS [dbo].[nguoidung];
DROP TABLE IF EXISTS [dbo].[quyen];

-- Tạo bảng quyen
CREATE TABLE [dbo].[quyen] (
    [MaQuyen] INT IDENTITY(1,1) NOT NULL,
    [TenQuyen] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_quyen] PRIMARY KEY CLUSTERED ([MaQuyen] ASC),
    CONSTRAINT [CK_quyen_TenQuyen] CHECK ([TenQuyen] IN ('Admin', 'User'))
);

-- Tạo bảng nguoidung
CREATE TABLE [dbo].[nguoidung] (
    [MaNguoiDung] INT IDENTITY(1,1) NOT NULL,
    [MaQuyen] INT NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [MatKhau] NVARCHAR(100) NOT NULL,
    [HoVaTen] NVARCHAR(100) NOT NULL,
    [NgaySinh] DATE NOT NULL,
    [DiaChi] NVARCHAR(200) NOT NULL,
    [GioiTinh] NVARCHAR(10) NOT NULL,
    [SoDienThoai] NVARCHAR(15) NOT NULL,
    [TrangThai] NVARCHAR(20) NOT NULL,
    CONSTRAINT [PK_nguoidung] PRIMARY KEY CLUSTERED ([MaNguoiDung] ASC),
    CONSTRAINT [UQ_nguoidung_Email] UNIQUE ([Email]),
    CONSTRAINT [UQ_nguoidung_SoDienThoai] UNIQUE ([SoDienThoai]),
    CONSTRAINT [CK_nguoidung_GioiTinh] CHECK ([GioiTinh] IN ('Nam', 'Nữ')),
    CONSTRAINT [CK_nguoidung_TrangThai] CHECK ([TrangThai] IN ('Hoạt động', 'Không hoạt động'))
);

-- Tạo bảng thietbi
CREATE TABLE [dbo].[thietbi] (
    [MaThietBi] INT IDENTITY(1,1) NOT NULL,
    [TenThietBi] NVARCHAR(100) NOT NULL,
    [LoaiThietBi] NVARCHAR(50) NOT NULL,
    [TrangThai] NVARCHAR(50) NOT NULL,
    [GiaMuon] DECIMAL(18,0) NOT NULL,
    CONSTRAINT [PK_thietbi] PRIMARY KEY CLUSTERED ([MaThietBi] ASC),
    CONSTRAINT [UQ_thietbi_TenThietBi] UNIQUE ([TenThietBi]),
    CONSTRAINT [CK_thietbi_TrangThai] CHECK ([TrangThai] IN ('Có sẵn', 'Đang sử dụng', 'Bảo trì'))
);

-- Tạo bảng phong
CREATE TABLE [dbo].[phong] (
    [MaPhong] INT IDENTITY(1,1) NOT NULL,
    [TenPhong] NVARCHAR(100) NOT NULL,
    [LoaiPhong] NVARCHAR(50) NOT NULL,
    [SucChua] INT NOT NULL,
    [TrangThai] NVARCHAR(50) NOT NULL,
    [GiaMuon] DECIMAL(18,0) NOT NULL,
    CONSTRAINT [PK_phong] PRIMARY KEY CLUSTERED ([MaPhong] ASC),
    CONSTRAINT [UQ_phong_TenPhong] UNIQUE ([TenPhong]),
    CONSTRAINT [CK_phong_TrangThai] CHECK ([TrangThai] IN ('Trống', 'Đang mượn', 'Bảo trì'))
);

-- Tạo bảng checkin
CREATE TABLE [dbo].[checkin] (
    [MaCheckIn] INT IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianVao] DATETIME NOT NULL,
    [ThoiGianRa] DATETIME NOT NULL,
    [TrangThai] NVARCHAR(20) NOT NULL,
    CONSTRAINT [PK_checkin] PRIMARY KEY CLUSTERED ([MaCheckIn] ASC),
    CONSTRAINT [CK_checkin_TrangThai] CHECK ([TrangThai] IN ('Checked In', 'Checked Out'))
);

-- Tạo bảng phieumuonphong
CREATE TABLE [dbo].[phieumuonphong] (
    [MaPhieuMuonPhong] INT IDENTITY(1,1) NOT NULL,
    [MaPhong] INT NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianMuon] DATETIME NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TrangThai] NVARCHAR(20) NOT NULL,
    [TongTien] DECIMAL(18,0) NOT NULL,
    CONSTRAINT [PK_phieumuonphong] PRIMARY KEY CLUSTERED ([MaPhieuMuonPhong] ASC),
    CONSTRAINT [CK_phieumuonphong_TrangThai] CHECK ([TrangThai] IN ('Đang mượn', 'Đã trả'))
);

-- Tạo bảng phieumuonthietbi
CREATE TABLE [dbo].[phieumuonthietbi] (
    [MaPhieuMuonThietBi] INT IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [MaThietBi] INT NOT NULL,
    [TrangThai] NVARCHAR(20) NOT NULL,
    [ThoiGianMuon] DATETIME NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TongTien] DECIMAL(18,0) NOT NULL,
    CONSTRAINT [PK_phieumuonthietbi] PRIMARY KEY CLUSTERED ([MaPhieuMuonThietBi] ASC),
    CONSTRAINT [CK_phieumuonthietbi_TrangThai] CHECK ([TrangThai] IN ('Đang mượn', 'Đã trả'))
);

-- Tạo bảng phieutra
CREATE TABLE [dbo].[phieutra] (
    [MaPhieuTra] INT IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TongTienPhaiTra] DECIMAL(18,0) NOT NULL,
    [TienPhat] DECIMAL(18,0) NOT NULL,
    CONSTRAINT [PK_phieutra] PRIMARY KEY CLUSTERED ([MaPhieuTra] ASC)
);

-- Tạo bảng thanhtoan
CREATE TABLE [dbo].[thanhtoan] (
    [MaThanhToan] INT IDENTITY(1,1) NOT NULL,
    [MaPhieuTra] INT NOT NULL,
    [TongTienPhaiTra] DECIMAL(18,0) NOT NULL,
    [NgayThanhToan] DATETIME NOT NULL,
    [HinhThucThanhToan] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_thanhtoan] PRIMARY KEY CLUSTERED ([MaThanhToan] ASC),
    CONSTRAINT [CK_thanhtoan_HinhThucThanhToan] CHECK ([HinhThucThanhToan] IN ('Tiền mặt', 'Chuyển khoản'))
);

-- Tạo bảng thongbao
CREATE TABLE [dbo].[thongbao] (
    [MaThongBao] INT IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [TieuDe] NVARCHAR(100) NOT NULL,
    [NoiDung] NVARCHAR(500) NOT NULL,
    [LoaiThongBao] NVARCHAR(20) NOT NULL,
    [ThoiGianGui] DATETIME NOT NULL,
    CONSTRAINT [PK_thongbao] PRIMARY KEY CLUSTERED ([MaThongBao] ASC),
    CONSTRAINT [CK_thongbao_LoaiThongBao] CHECK ([LoaiThongBao] IN ('Chung', 'Vi Phạm', 'Sự Kiện'))
);

-- Tạo bảng vipham
CREATE TABLE [dbo].[vipham] (
    [MaViPham] INT IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [MaThietBi] INT NOT NULL,
    [MaPhong] INT NOT NULL,
    [LoaiViPham] NVARCHAR(50) NOT NULL,
    [NoiDungViPham] NVARCHAR(500) NOT NULL,
    CONSTRAINT [PK_vipham] PRIMARY KEY CLUSTERED ([MaViPham] ASC),
    CONSTRAINT [CK_vipham_LoaiViPham] CHECK ([LoaiViPham] IN ('Trả trễ', 'Làm hỏng', 'Làm mất', 'Khác'))
);

-- Chèn dữ liệu vào bảng quyen (2 bản ghi)
INSERT INTO [dbo].[quyen] ([TenQuyen]) VALUES ('Admin'), ('User');

-- Chèn 30 bản ghi vào bảng nguoidung
INSERT INTO [dbo].[nguoidung] ([MaQuyen], [Email], [MatKhau], [HoVaTen], [NgaySinh], [DiaChi], [GioiTinh], [SoDienThoai], [TrangThai])
VALUES
    (1, 'admin@gmail.com', 'Admin@2024#Secure!', 'Admin', '1980-01-01', '123 Nguyen Hue, HCM', 'Nam', '0987654001', 'Hoạt động'),
    (2, 'tranthithuy@gmail.com', 'TTThuy!98$Mypass', 'Trần Thị Thùy', '1995-08-15', 'TP.HCM', 'Nữ', '0912345002', 'Hoạt động'),
    (2, 'levanchien@gmail.com', 'LVChien@Secure99*', 'Lê Văn Chiến', '1992-03-22', 'Đà Nẵng', 'Nam', '0909123003', 'Hoạt động'),
    (2, 'phamminhduc@gmail.com', 'PMDuc_2024!Secure$', 'Phạm Minh Đức', '2000-02-20', 'Hải Phòng', 'Nam', '0988888004', 'Hoạt động'),
    (2, 'dangthihanh@gmail.com', 'DTHanh#Pass_77@!', 'Đặng Thị Hạnh', '1998-07-12', 'Cần Thơ', 'Nữ', '0977777005', 'Hoạt động'),
    (2, 'hoangminhphuc@gmail.com', 'HMP_#88*Pass', 'Hoàng Minh Phúc', '1988-09-30', 'Huế', 'Nam', '0922233006', 'Hoạt động'),
    (2, 'ngothithanh@gmail.com', 'NTThanh@Mypass123!', 'Ngô Thị Thanh', '1993-06-18', 'Bắc Ninh', 'Nữ', '0944455007', 'Hoạt động'),
    (2, 'vuquocanh@gmail.com', 'VQA!2024$*Pass', 'Vũ Quốc Anh', '1997-11-25', 'Hải Dương', 'Nam', '0933344008', 'Hoạt động'),
    (2, 'dangthimai@gmail.com', 'DTMai@Pass_55$', 'Đặng Thị Mai', '1996-12-05', 'Bình Dương', 'Nữ', '0911122009', 'Không hoạt động'),
    (2, 'trananhduy@gmail.com', 'TADuy@88*#Pass', 'Trần Anh Duy', '1985-04-14', 'Hà Giang', 'Nam', '0966677010', 'Hoạt động'),
    (2, 'nguyenvanlong@gmail.com', 'NVLong_99#Pass!', 'Nguyễn Văn Long', '1991-07-07', 'Phú Thọ', 'Nam', '0908877111', 'Hoạt động'),
    (2, 'phamthiminh@gmail.com', 'PTMinh!2024_XX*', 'Phạm Thị Minh', '1994-02-03', 'Vĩnh Long', 'Nữ', '0955555012', 'Không hoạt động'),
    (2, 'lethanhnhan@gmail.com', 'LTNhan@Pass777$', 'Lê Thành Nhân', '1999-05-23', 'Hòa Bình', 'Nam', '0982222013', 'Hoạt động'),
    (2, 'hoangthian@gmail.com', 'HTAn!Mypass66*', 'Hoàng Thị An', '2001-01-01', 'Đồng Nai', 'Nữ', '0920014014', 'Hoạt động'),
    (2, 'dangquocphong@gmail.com', 'DQP@Pass*123$', 'Đặng Quốc Phong', '1989-09-09', 'Lạng Sơn', 'Nam', '0911115015', 'Hoạt động'),
    (2, 'vuthihue@gmail.com', 'VTHue!My99$*Pass', 'Vũ Thị Huệ', '1992-12-12', 'Hà Nam', 'Nữ', '0909900016', 'Hoạt động'),
    (2, 'nguyenminhtruong@gmail.com', 'NMTuong_@88*Secure', 'Nguyễn Minh Trường', '1996-10-20', 'Bình Thuận', 'Nam', '0973322017', 'Không hoạt động'),
    (2, 'lethithao@gmail.com', 'LTThao@Pass2024$*', 'Lê Thị Thảo', '1993-08-08', 'Quảng Ninh', 'Nữ', '0934433018', 'Hoạt động'),
    (2, 'nguyenhoangtu@gmail.com', 'NHTu_2024!Secure*', 'Nguyễn Hoàng Tú', '1995-05-15', 'Cà Mau', 'Nam', '0998877019', 'Hoạt động'),
    (2, 'phanthiuyen@gmail.com', 'PTUyen!Secure88#$', 'Phan Thị Uyên', '1998-07-04', 'Nam Định', 'Nữ', '0956677020', 'Không hoạt động'),
    (2, 'vominhvu@gmail.com', 'VMVu_2024*Pass!', 'Võ Minh Vũ', '2002-02-02', 'Hậu Giang', 'Nam', '0915544021', 'Hoạt động'),
    (2, 'buidieulam@gmail.com', 'BDLam!Pass99*$', 'Bùi Diệu Lâm', '1997-11-11', 'Tây Ninh', 'Nữ', '0924415022', 'Hoạt động'),
    (2, 'dothianhthu@gmail.com', 'DTAnhThu@Pass*XX2024', 'Đỗ Thị Anh Thư', '1991-06-06', 'Sơn La', 'Nữ', '0967776023', 'Hoạt động'),
    (2, 'huynhminhyen@gmail.com', 'HMYen!Secure_88#$', 'Huỳnh Minh Yến', '1993-09-19', 'Kon Tum', 'Nam', '0997766024', 'Không hoạt động'),
    (2, 'dinhngocquyen@gmail.com', 'DNQuyen_@2024Pass*', 'Đinh Ngọc Quyền', '2000-12-21', 'Yên Bái', 'Nam', '0904437025', 'Hoạt động'),
    (2, 'phambaotuan@gmail.com', 'PBTuan!Pass*99$', 'Phạm Bảo Tuấn', '1994-03-31', 'Bắc Giang', 'Nam', '0955548026', 'Hoạt động'),
    (2, 'trankhanhduy@gmail.com', 'TKDuy@Secure2024$', 'Trần Khánh Duy', '1988-10-10', 'Kiên Giang', 'Nam', '0913326027', 'Hoạt động'),
    (2, 'hoangnhithu@gmail.com', 'HNhThu_88#Mypass!', 'Hoàng Nhị Thư', '1996-02-18', 'Gia Lai', 'Nữ', '0920015028', 'Hoạt động'),
    (2, 'lethidieu@gmail.com', 'LTDieu_99!Pass2024', 'Lê Thị Diệu', '1999-07-09', 'Nghệ An', 'Nữ', '0967767029', 'Hoạt động'),
    (2, 'dangtrongkhoa@gmail.com', 'DTKhoa!SecurePass#', 'Đặng Trọng Khoa', '2001-05-05', 'Thái Bình', 'Nam', '0939987030', 'Không hoạt động');

-- Chèn 30 bản ghi vào bảng thietbi
INSERT INTO [dbo].[thietbi] ([TenThietBi], [LoaiThietBi], [TrangThai], [GiaMuon])
VALUES
    ('Máy chiếu Epson EB-X05', 'Máy chiếu', 'Có sẵn', 50000),
    ('Laptop Dell XPS 13', 'Máy tính xách tay', 'Có sẵn', 100000),
    ('Máy in HP LaserJet Pro', 'Máy in', 'Đang sử dụng', 30000),
    ('Loa Bluetooth JBL', 'Thiết bị âm thanh', 'Có sẵn', 20000),
    ('Máy ảnh Canon EOS 80D', 'Máy ảnh', 'Bảo trì', 80000),
    ('Bảng trắng thông minh', 'Thiết bị trình chiếu', 'Có sẵn', 60000),
    ('Tai nghe Sony WH-1000XM4', 'Thiết bị âm thanh', 'Có sẵn', 25000),
    ('Máy scan Brother ADS-2200', 'Máy scan', 'Có sẵn', 35000),
    ('Máy chiếu Sony VPL-DX220', 'Máy chiếu', 'Có sẵn', 55000),
    ('Laptop HP Spectre x360', 'Máy tính xách tay', 'Đang sử dụng', 110000),
    ('Máy in Canon PIXMA', 'Máy in', 'Có sẵn', 32000),
    ('Loa Bose SoundLink', 'Thiết bị âm thanh', 'Có sẵn', 22000),
    ('Máy ảnh Nikon D7500', 'Máy ảnh', 'Có sẵn', 85000),
    ('Bảng tương tác Samsung', 'Thiết bị trình chiếu', 'Có sẵn', 65000),
    ('Tai nghe Bose QC35', 'Thiết bị âm thanh', 'Đang sử dụng', 27000),
    ('Máy scan Epson DS-530', 'Máy scan', 'Có sẵn', 37000),
    ('Máy chiếu BenQ MX550', 'Máy chiếu', 'Có sẵn', 52000),
    ('Laptop Lenovo ThinkPad', 'Máy tính xách tay', 'Có sẵn', 105000),
    ('Máy in Brother HL-L2350', 'Máy in', 'Bảo trì', 31000),
    ('Loa Anker Soundcore', 'Thiết bị âm thanh', 'Có sẵn', 21000),
    ('Máy ảnh Sony Alpha A6400', 'Máy ảnh', 'Có sẵn', 82000),
    ('Bảng trắng Panasonic', 'Thiết bị trình chiếu', 'Có sẵn', 62000),
    ('Tai nghe JBL Live 650', 'Thiết bị âm thanh', 'Có sẵn', 26000),
    ('Máy scan Fujitsu fi-7160', 'Máy scan', 'Có sẵn', 36000),
    ('Máy chiếu ViewSonic PA503S', 'Máy chiếu', 'Có sẵn', 53000),
    ('Laptop Asus ZenBook', 'Máy tính xách tay', 'Đang sử dụng', 108000),
    ('Máy in Epson L3150', 'Máy in', 'Có sẵn', 33000),
    ('Loa Harman Kardon', 'Thiết bị âm thanh', 'Có sẵn', 23000),
    ('Máy ảnh Fujifilm X-T30', 'Máy ảnh', 'Có sẵn', 83000),
    ('Bảng tương tác LG', 'Thiết bị trình chiếu', 'Có sẵn', 64000);

-- Chèn 30 bản ghi vào bảng phong
INSERT INTO [dbo].[phong] ([TenPhong], [LoaiPhong], [SucChua], [TrangThai], [GiaMuon])
VALUES
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
    ('Phòng Thuyết trình 4', 'Thuyết trình', 28, 'Đang mượn', 300000),
    ('Phòng Hội thảo 5', 'Hội thảo', 55, 'Trống', 550000),
    ('Phòng Họp 5', 'Họp', 16, 'Trống', 170000),
    ('Phòng Đa năng 5', 'Đa năng', 38, 'Đang mượn', 380000),
    ('Phòng Làm việc nhóm 5', 'Làm việc nhóm', 10, 'Trống', 140000),
    ('Phòng Thuyết trình 5', 'Thuyết trình', 30, 'Bảo trì', 310000),
    ('Phòng Hội thảo 6', 'Hội thảo', 65, 'Trống', 650000),
    ('Phòng Họp 6', 'Họp', 18, 'Đang mượn', 200000),
    ('Phòng Đa năng 6', 'Đa năng', 42, 'Trống', 420000),
    ('Phòng Làm việc nhóm 6', 'Làm việc nhóm', 11, 'Trống', 150000),
    ('Phòng Thuyết trình 6', 'Thuyết trình', 32, 'Đang mượn', 320000);

-- Chèn 30 bản ghi vào bảng checkin
INSERT INTO [dbo].[checkin] ([MaNguoiDung], [ThoiGianVao], [ThoiGianRa], [TrangThai])
VALUES
    (1, '2025-04-01 08:00:00', '2025-04-01 10:00:00', 'Checked In'),
    (2, '2025-04-01 09:15:00', '2025-04-01 11:15:00', 'Checked In'),
    (3, '2025-04-01 07:45:00', '2025-04-01 09:45:00', 'Checked In'),
    (4, '2025-04-02 10:00:00', '2025-04-02 12:00:00', 'Checked Out'),
    (5, '2025-04-02 08:30:00', '2025-04-02 10:30:00', 'Checked In'),
    (6, '2025-04-02 09:00:00', '2025-04-02 11:00:00', 'Checked Out'),
    (7, '2025-04-03 07:50:00', '2025-04-03 09:50:00', 'Checked Out'),
    (8, '2025-04-03 08:20:00', '2025-04-03 10:20:00', 'Checked In'),
    (9, '2025-04-03 09:10:00', '2025-04-03 11:10:00', 'Checked In'),
    (10, '2025-04-03 08:05:00', '2025-04-03 10:05:00', 'Checked Out'),
    (11, '2025-04-04 09:00:00', '2025-04-04 11:00:00', 'Checked Out'),
    (12, '2025-04-04 08:40:00', '2025-04-04 10:40:00', 'Checked Out'),
    (13, '2025-04-04 07:55:00', '2025-04-04 09:55:00', 'Checked In'),
    (14, '2025-04-05 10:10:00', '2025-04-05 12:10:00', 'Checked In'),
    (15, '2025-04-05 09:30:00', '2025-04-05 11:30:00', 'Checked In'),
    (16, '2025-04-05 08:15:00', '2025-04-05 10:15:00', 'Checked In'),
    (17, '2025-04-06 07:30:00', '2025-04-06 09:30:00', 'Checked In'),
    (18, '2025-04-06 09:20:00', '2025-04-06 11:20:00', 'Checked In'),
    (19, '2025-04-06 08:50:00', '2025-04-06 10:50:00', 'Checked In'),
    (20, '2025-04-06 07:45:00', '2025-04-06 09:45:00', 'Checked Out'),
    (21, '2025-04-07 08:30:00', '2025-04-07 10:30:00', 'Checked Out'),
    (22, '2025-04-07 09:00:00', '2025-04-07 11:00:00', 'Checked Out'),
    (23, '2025-04-07 10:15:00', '2025-04-07 12:15:00', 'Checked In'),
    (24, '2025-04-08 08:45:00', '2025-04-08 10:45:00', 'Checked In'),
    (25, '2025-04-08 09:30:00', '2025-04-08 11:30:00', 'Checked Out'),
    (26, '2025-04-08 10:00:00', '2025-04-08 12:00:00', 'Checked Out'),
    (27, '2025-04-09 07:50:00', '2025-04-09 09:50:00', 'Checked Out'),
    (28, '2025-04-09 08:20:00', '2025-04-09 10:20:00', 'Checked Out'),
    (29, '2025-04-09 09:10:00', '2025-04-09 11:10:00', 'Checked Out'),
    (30, '2025-04-10 08:05:00', '2025-04-10 10:05:00', 'Checked In');

-- Chèn 30 bản ghi vào bảng phieumuonphong
INSERT INTO [dbo].[phieumuonphong] ([MaPhong], [MaNguoiDung], [ThoiGianMuon], [ThoiGianTra], [TrangThai], [TongTien])
VALUES
    (1, 1, '2025-04-05 10:00:00', '2025-04-05 12:00:00', 'Đã trả', 500000),
    (2, 2, '2025-04-05 14:30:00', '2025-04-06 16:00:00', 'Đã trả', 800000),
    (3, 3, '2025-04-06 09:00:00', '2025-04-06 11:00:00', 'Đã trả', 150000),
    (4, 4, '2025-04-06 15:00:00', '2025-04-07 17:00:00', 'Đã trả', 200000),
    (5, 5, '2025-04-07 11:30:00', '2025-04-07 13:00:00', 'Đã trả', 300000),
    (6, 6, '2025-04-07 16:00:00', '2025-04-08 10:00:00', 'Đã trả', 400000),
    (7, 7, '2025-04-08 08:00:00', '2025-04-08 10:00:00', 'Đã trả', 100000),
    (8, 8, '2025-04-08 13:00:00', '2025-04-09 15:00:00', 'Đã trả', 120000),
    (9, 9, '2025-04-09 10:30:00', '2025-04-09 12:30:00', 'Đã trả', 250000),
    (10, 10, '2025-04-09 16:30:00', '2025-04-10 18:00:00', 'Đã trả', 280000),
    (11, 11, '2025-04-10 09:30:00', '2025-04-10 11:30:00', 'Đã trả', 600000),
    (12, 12, '2025-04-10 14:00:00', '2025-04-11 16:00:00', 'Đã trả', 180000),
    (13, 13, '2025-04-11 11:00:00', '2025-04-11 13:00:00', 'Đã trả', 350000),
    (14, 14, '2025-04-11 17:00:00', '2025-04-12 19:00:00', 'Đã trả', 110000),
    (15, 15, '2025-04-12 10:00:00', '2025-04-12 12:00:00', 'Đã trả', 260000),
    (16, 16, '2025-04-12 15:30:00', '2025-04-13 17:30:00', 'Đã trả', 700000),
    (17, 17, '2025-04-13 08:30:00', '2025-04-13 10:30:00', 'Đã trả', 190000),
    (18, 18, '2025-04-13 14:30:00', '2025-04-14 16:30:00', 'Đã trả', 450000),
    (19, 19, '2025-04-14 11:30:00', '2025-04-14 13:30:00', 'Đã trả', 130000),
    (20, 20, '2025-04-14 17:30:00', '2025-04-15 19:00:00', 'Đã trả', 300000),
    (21, 21, '2025-04-15 09:00:00', '2025-04-15 11:00:00', 'Đã trả', 550000),
    (22, 22, '2025-04-15 14:00:00', '2025-04-16 16:00:00', 'Đã trả', 170000),
    (23, 23, '2025-04-16 10:30:00', '2025-04-16 12:30:00', 'Đã trả', 380000),
    (24, 24, '2025-04-16 15:30:00', '2025-04-17 17:30:00', 'Đã trả', 140000),
    (25, 25, '2025-04-17 08:00:00', '2025-04-17 10:00:00', 'Đã trả', 310000),
    (26, 26, '2025-04-17 13:00:00', '2025-04-18 15:00:00', 'Đã trả', 650000),
    (27, 27, '2025-04-18 09:30:00', '2025-04-18 11:30:00', 'Đã trả', 200000),
    (28, 28, '2025-04-18 14:30:00', '2025-04-19 16:30:00', 'Đã trả', 420000),
    (29, 29, '2025-04-19 11:00:00', '2025-04-19 13:00:00', 'Đã trả', 150000),
    (30, 30, '2025-04-19 16:00:00', '2025-04-20 18:00:00', 'Đã trả', 320000);

-- Chèn 30 bản ghi vào bảng phieumuonthietbi
INSERT INTO [dbo].[phieumuonthietbi] ([MaNguoiDung], [MaThietBi], [TrangThai], [ThoiGianMuon], [ThoiGianTra], [TongTien])
VALUES
    (1, 1, 'Đã trả', '2025-04-05 10:00:00', '2025-04-05 12:00:00', 50000),
    (2, 2, 'Đã trả', '2025-04-05 14:30:00', '2025-04-06 16:00:00', 100000),
    (3, 3, 'Đã trả', '2025-04-06 09:00:00', '2025-04-06 11:00:00', 30000),
    (4, 4, 'Đã trả', '2025-04-06 15:00:00', '2025-04-07 17:00:00', 20000),
    (5, 5, 'Đã trả', '2025-04-07 11:30:00', '2025-04-07 13:00:00', 80000),
    (6, 6, 'Đã trả', '2025-04-07 16:00:00', '2025-04-08 10:00:00', 60000),
    (7, 7, 'Đã trả', '2025-04-08 08:00:00', '2025-04-08 10:00:00', 25000),
    (8, 8, 'Đã trả', '2025-04-08 13:00:00', '2025-04-09 15:00:00', 35000),
    (9, 9, 'Đã trả', '2025-04-09 10:30:00', '2025-04-09 12:30:00', 55000),
    (10, 10, 'Đã trả', '2025-04-09 16:30:00', '2025-04-10 18:00:00', 110000),
    (11, 11, 'Đã trả', '2025-04-10 09:30:00', '2025-04-10 11:30:00', 32000),
    (12, 12, 'Đã trả', '2025-04-10 14:00:00', '2025-04-11 16:00:00', 22000),
    (13, 13, 'Đã trả', '2025-04-11 11:00:00', '2025-04-11 13:00:00', 85000),
    (14, 14, 'Đã trả', '2025-04-11 17:00:00', '2025-04-12 19:00:00', 65000),
    (15, 15, 'Đã trả', '2025-04-12 10:00:00', '2025-04-12 12:00:00', 27000),
    (16, 16, 'Đã trả', '2025-04-12 15:30:00', '2025-04-13 17:30:00', 37000),
    (17, 17, 'Đã trả', '2025-04-13 08:30:00', '2025-04-13 10:30:00', 52000),
    (18, 18, 'Đã trả', '2025-04-13 14:30:00', '2025-04-14 16:30:00', 105000),
    (19, 19, 'Đã trả', '2025-04-14 11:30:00', '2025-04-14 13:30:00', 31000),
    (20, 20, 'Đã trả', '2025-04-14 17:30:00', '2025-04-15 19:00:00', 21000),
    (21, 21, 'Đã trả', '2025-04-15 09:00:00', '2025-04-15 11:00:00', 82000),
    (22, 22, 'Đã trả', '2025-04-15 14:00:00', '2025-04-16 16:00:00', 62000),
    (23, 23, 'Đã trả', '2025-04-16 10:30:00', '2025-04-16 12:30:00', 26000),
    (24, 24, 'Đã trả', '2025-04-16 15:30:00', '2025-04-17 17:30:00', 36000),
    (25, 25, 'Đã trả', '2025-04-17 08:00:00', '2025-04-17 10:00:00', 53000),
    (26, 26, 'Đã trả', '2025-04-17 13:00:00', '2025-04-18 15:00:00', 108000),
    (27, 27, 'Đã trả', '2025-04-18 09:30:00', '2025-04-18 11:30:00', 33000),
    (28, 28, 'Đã trả', '2025-04-18 14:30:00', '2025-04-19 16:30:00', 23000),
    (29, 29, 'Đã trả', '2025-04-19 11:00:00', '2025-04-19 13:00:00', 83000),
    (30, 30, 'Đã trả', '2025-04-19 16:00:00', '2025-04-20 18:00:00', 64000);

-- Chèn 30 bản ghi vào bảng phieutra (đồng bộ với phieumuonphong và phieumuonthietbi)
INSERT INTO [dbo].[phieutra] ([MaNguoiDung], [ThoiGianTra], [TongTienPhaiTra], [TienPhat])
VALUES
    (1, '2025-04-05 12:00:00', 550000, 10000), -- 500000 (phòng) + 50000 (thiết bị)
    (2, '2025-04-06 16:00:00', 900000, 20000), -- 800000 (phòng) + 100000 (thiết bị)
    (3, '2025-04-06 11:00:00', 180000, 0),    -- 150000 (phòng) + 30000 (thiết bị)
    (4, '2025-04-07 17:00:00', 220000, 10000), -- 200000 (phòng) + 20000 (thiết bị)
    (5, '2025-04-07 13:00:00', 380000, 0),    -- 300000 (phòng) + 80000 (thiết bị)
    (6, '2025-04-08 10:00:00', 460000, 0),    -- 400000 (phòng) + 60000 (thiết bị)
    (7, '2025-04-08 10:00:00', 125000, 0),    -- 100000 (phòng) + 25000 (thiết bị)
    (8, '2025-04-09 15:00:00', 155000, 5000), -- 120000 (phòng) + 35000 (thiết bị)
    (9, '2025-04-09 12:30:00', 305000, 0),    -- 250000 (phòng) + 55000 (thiết bị)
    (10, '2025-04-10 18:00:00', 390000, 10000),-- 280000 (phòng) + 110000 (thiết bị)
    (11, '2025-04-10 11:30:00', 632000, 0),   -- 600000 (phòng) + 32000 (thiết bị)
    (12, '2025-04-11 16:00:00', 202000, 5000),-- 180000 (phòng) + 22000 (thiết bị)
    (13, '2025-04-11 13:00:00', 435000, 0),   -- 350000 (phòng) + 85000 (thiết bị)
    (14, '2025-04-12 19:00:00', 175000, 10000),-- 110000 (phòng) + 65000 (thiết bị)
    (15, '2025-04-12 12:00:00', 287000, 0),   -- 260000 (phòng) + 27000 (thiết bị)
    (16, '2025-04-13 17:30:00', 737000, 20000),-- 700000 (phòng) + 37000 (thiết bị)
    (17, '2025-04-13 10:30:00', 242000, 0),   -- 190000 (phòng) + 52000 (thiết bị)
    (18, '2025-04-14 16:30:00', 555000, 10000),-- 450000 (phòng) + 105000 (thiết bị)
    (19, '2025-04-14 13:30:00', 161000, 0),   -- 130000 (phòng) + 31000 (thiết bị)
    (20, '2025-04-15 19:00:00', 321000, 5000),-- 300000 (phòng) + 21000 (thiết bị)
    (21, '2025-04-15 11:00:00', 632000, 0),   -- 550000 (phòng) + 82000 (thiết bị)
    (22, '2025-04-16 16:00:00', 232000, 10000),-- 170000 (phòng) + 62000 (thiết bị)
    (23, '2025-04-16 12:30:00', 406000, 0),   -- 380000 (phòng) + 26000 (thiết bị)
    (24, '2025-04-17 17:30:00', 176000, 5000),-- 140000 (phòng) + 36000 (thiết bị)
    (25, '2025-04-17 10:00:00', 363000, 0),   -- 310000 (phòng) + 53000 (thiết bị)
    (26, '2025-04-18 15:00:00', 758000, 10000),-- 650000 (phòng) + 108000 (thiết bị)
    (27, '2025-04-18 11:30:00', 233000, 0),   -- 200000 (phòng) + 33000 (thiết bị)
    (28, '2025-04-19 16:30:00', 443000, 5000),-- 420000 (phòng) + 23000 (thiết bị)
    (29, '2025-04-19 13:00:00', 233000, 0),   -- 150000 (phòng) + 83000 (thiết bị)
    (30, '2025-04-20 18:00:00', 384000, 10000);-- 320000 (phòng) + 64000 (thiết bị)

-- Chèn 30 bản ghi vào bảng thanhtoan
INSERT INTO [dbo].[thanhtoan] ([MaPhieuTra], [TongTienPhaiTra], [NgayThanhToan], [HinhThucThanhToan])
VALUES
    (1, 550000, '2025-04-05 12:00:00', 'Tiền mặt'),
    (2, 900000, '2025-04-06 16:00:00', 'Chuyển khoản'),
    (3, 180000, '2025-04-06 11:00:00', 'Tiền mặt'),
    (4, 220000, '2025-04-07 17:00:00', 'Chuyển khoản'),
    (5, 380000, '2025-04-07 13:00:00', 'Tiền mặt'),
    (6, 460000, '2025-04-08 10:00:00', 'Chuyển khoản'),
    (7, 125000, '2025-04-08 10:00:00', 'Tiền mặt'),
    (8, 155000, '2025-04-09 15:00:00', 'Chuyển khoản'),
    (9, 305000, '2025-04-09 12:30:00', 'Tiền mặt'),
    (10, 390000, '2025-04-10 18:00:00', 'Chuyển khoản'),
    (11, 632000, '2025-04-10 11:30:00', 'Tiền mặt'),
    (12, 202000, '2025-04-11 16:00:00', 'Chuyển khoản'),
    (13, 435000, '2025-04-11 13:00:00', 'Tiền mặt'),
    (14, 175000, '2025-04-12 19:00:00', 'Chuyển khoản'),
    (15, 287000, '2025-04-12 12:00:00', 'Tiền mặt'),
    (16, 737000, '2025-04-13 17:30:00', 'Chuyển khoản'),
    (17, 242000, '2025-04-13 10:30:00', 'Tiền mặt'),
    (18, 555000, '2025-04-14 16:30:00', 'Chuyển khoản'),
    (19, 161000, '2025-04-14 13:30:00', 'Tiền mặt'),
    (20, 321000, '2025-04-15 19:00:00', 'Chuyển khoản'),
    (21, 632000, '2025-04-15 11:00:00', 'Tiền mặt'),
    (22, 232000, '2025-04-16 16:00:00', 'Chuyển khoản'),
    (23, 406000, '2025-04-16 12:30:00', 'Tiền mặt'),
    (24, 176000, '2025-04-17 17:30:00', 'Chuyển khoản'),
    (25, 363000, '2025-04-17 10:00:00', 'Tiền mặt'),
    (26, 758000, '2025-04-18 15:00:00', 'Chuyển khoản'),
    (27, 233000, '2025-04-18 11:30:00', 'Tiền mặt'),
    (28, 443000, '2025-04-19 16:30:00', 'Chuyển khoản'),
    (29, 233000, '2025-04-19 13:00:00', 'Tiền mặt'),
    (30, 384000, '2025-04-20 18:00:00', 'Chuyển khoản');

-- Chèn 30 bản ghi vào bảng thongbao
INSERT INTO [dbo].[thongbao] ([MaNguoiDung], [TieuDe], [NoiDung], [LoaiThongBao], [ThoiGianGui])
VALUES
    (1, 'Thông báo chung 1', 'Nội dung thông báo chung 1...', 'Chung', '2025-04-05 10:00:00'),
    (2, 'Thông báo vi phạm 1', 'Nội dung thông báo vi phạm 1...', 'Vi Phạm', '2025-04-05 14:30:00'),
    (3, 'Sự kiện 1', 'Nội dung sự kiện 1...', 'Sự Kiện', '2025-04-06 09:00:00'),
    (4, 'Thông báo chung 2', 'Nội dung thông báo chung 2...', 'Chung', '2025-04-06 15:00:00'),
    (5, 'Thông báo vi phạm 2', 'Nội dung thông báo vi phạm 2...', 'Vi Phạm', '2025-04-07 11:30:00'),
    (6, 'Sự kiện 2', 'Nội dung sự kiện 2...', 'Sự Kiện', '2025-04-07 16:00:00'),
    (7, 'Thông báo chung 3', 'Nội dung thông báo chung 3...', 'Chung', '2025-04-08 08:00:00'),
    (8, 'Thông báo vi phạm 3', 'Nội dung thông báo vi phạm 3...', 'Vi Phạm', '2025-04-08 13:00:00'),
    (9, 'Sự kiện 3', 'Nội dung sự kiện 3...', 'Sự Kiện', '2025-04-09 10:30:00'),
    (10, 'Thông báo chung 4', 'Nội dung thông báo chung 4...', 'Chung', '2025-04-09 16:30:00'),
    (11, 'Thông báo vi phạm 4', 'Nội dung thông báo vi phạm 4...', 'Vi Phạm', '2025-04-10 09:30:00'),
    (12, 'Sự kiện 4', 'Nội dung sự kiện 4...', 'Sự Kiện', '2025-04-10 14:00:00'),
    (13, 'Thông báo chung 5', 'Nội dung thông báo chung 5...', 'Chung', '2025-04-11 11:00:00'),
    (14, 'Thông báo vi phạm 5', 'Nội dung thông báo vi phạm 5...', 'Vi Phạm', '2025-04-11 17:00:00'),
    (15, 'Sự kiện 5', 'Nội dung sự kiện 5...', 'Sự Kiện', '2025-04-12 10:00:00'),
    (16, 'Thông báo chung 6', 'Nội dung thông báo chung 6...', 'Chung', '2025-04-12 15:30:00'),
    (17, 'Thông báo vi phạm 6', 'Nội dung thông báo vi phạm 6...', 'Vi Phạm', '2025-04-13 08:30:00'),
    (18, 'Sự kiện 6', 'Nội dung sự kiện 6...', 'Sự Kiện', '2025-04-13 14:30:00'),
    (19, 'Thông báo chung 7', 'Nội dung thông báo chung 7...', 'Chung', '2025-04-14 11:30:00'),
    (20, 'Thông báo vi phạm 7', 'Nội dung thông báo vi phạm 7...', 'Vi Phạm', '2025-04-14 17:30:00'),
    (21, 'Sự kiện 7', 'Nội dung sự kiện 7...', 'Sự Kiện', '2025-04-15 09:00:00'),
    (22, 'Thông báo chung 8', 'Nội dung thông báo chung 8...', 'Chung', '2025-04-15 14:00:00'),
    (23, 'Thông báo vi phạm 8', 'Nội dung thông báo vi phạm 8...', 'Vi Phạm', '2025-04-16 10:30:00'),
    (24, 'Sự kiện 8', 'Nội dung sự kiện 8...', 'Sự Kiện', '2025-04-16 15:30:00'),
    (25, 'Thông báo chung 9', 'Nội dung thông báo chung 9...', 'Chung', '2025-04-17 08:00:00'),
    (26, 'Thông báo vi phạm 9', 'Nội dung thông báo vi phạm 9...', 'Vi Phạm', '2025-04-17 13:00:00'),
    (27, 'Sự kiện 9', 'Nội dung sự kiện 9...', 'Sự Kiện', '2025-04-18 09:30:00'),
    (28, 'Thông báo chung 10', 'Nội dung thông báo chung 10...', 'Chung', '2025-04-18 14:30:00'),
    (29, 'Thông báo vi phạm 10', 'Nội dung thông báo vi phạm 10...', 'Vi Phạm', '2025-04-19 11:00:00'),
    (30, 'Sự kiện 10', 'Nội dung sự kiện 10...', 'Sự Kiện', '2025-04-19 16:00:00');

-- Chèn 30 bản ghi vào bảng vipham
INSERT INTO [dbo].[vipham] ([MaNguoiDung], [MaThietBi], [MaPhong], [LoaiViPham], [NoiDungViPham])
VALUES
    (1, 1, 1, 'Trả trễ', 'Trả thiết bị trễ 2 ngày.'),
    (2, 2, 2, 'Làm hỏng', 'Làm hỏng màn hình máy chiếu.'),
    (3, 3, 3, 'Làm mất', 'Làm mất micro không dây.'),
    (4, 4, 4, 'Khác', 'Sử dụng phòng không đúng quy định.'),
    (5, 5, 5, 'Trả trễ', 'Trả phòng trễ 1 ngày.'),
    (6, 6, 6, 'Làm hỏng', 'Làm hỏng bảng trắng thông minh.'),
    (7, 7, 7, 'Trả trễ', 'Trả tai nghe trễ 3 ngày.'),
    (8, 8, 8, 'Làm mất', 'Làm mất dây cáp máy scan.'),
    (9, 9, 9, 'Khác', 'Sử dụng thiết bị không đúng mục đích.'),
    (10, 10, 10, 'Trả trễ', 'Trả laptop trễ 2 ngày.'),
    (11, 11, 11, 'Làm hỏng', 'Làm hỏng máy in.'),
    (12, 12, 12, 'Làm mất', 'Làm mất loa Bluetooth.'),
    (13, 13, 13, 'Khác', 'Sử dụng phòng họp sai quy định.'),
    (14, 14, 14, 'Trả trễ', 'Trả bảng tương tác trễ 1 ngày.'),
    (15, 15, 15, 'Làm hỏng', 'Làm hỏng tai nghe.'),
    (16, 16, 16, 'Làm mất', 'Làm mất máy scan.'),
    (17, 17, 17, 'Trả trễ', 'Trả máy chiếu trễ 2 ngày.'),
    (18, 18, 18, 'Khác', 'Sử dụng thiết bị không được phép.'),
    (19, 19, 19, 'Làm hỏng', 'Làm hỏng máy in.'),
    (20, 20, 20, 'Trả trễ', 'Trả loa trễ 1 ngày.'),
    (21, 21, 21, 'Làm mất', 'Làm mất máy ảnh.'),
    (22, 22, 22, 'Khác', 'Sử dụng phòng không đúng giờ.'),
    (23, 23, 23, 'Trả trễ', 'Trả tai nghe trễ 2 ngày.'),
    (24, 24, 24, 'Làm hỏng', 'Làm hỏng máy scan.'),
    (25, 25, 25, 'Làm mất', 'Làm mất máy chiếu.'),
    (26, 26, 26, 'Trả trễ', 'Trả laptop trễ 1 ngày.'),
    (27, 27, 27, 'Khác', 'Sử dụng phòng không đúng quy định.'),
    (28, 28, 28, 'Làm hỏng', 'Làm hỏng máy in.'),
    (29, 29, 29, 'Trả trễ', 'Trả loa trễ 2 ngày.'),
    (30, 30, 30, 'Làm mất', 'Làm mất bảng tương tác.');

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
ADD CONSTRAINT [FK_vipham_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung] ([MaNguoiDung]),
    CONSTRAINT [FK_vipham_thietbi] FOREIGN KEY ([MaThietBi]) REFERENCES [dbo].[thietbi] ([MaThietBi]),
    CONSTRAINT [FK_vipham_phong] FOREIGN KEY ([MaPhong]) REFERENCES [dbo].[phong] ([MaPhong]);