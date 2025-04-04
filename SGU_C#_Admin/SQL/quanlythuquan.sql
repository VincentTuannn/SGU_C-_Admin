SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Database creation (you'll need to create this separately in SQL Server)
-- CREATE DATABASE quanlythuquan;
-- USE quanlythuquan;

-- Table: checkin
CREATE TABLE [dbo].[checkin] (
    [MaCheckin] INT NOT NULL IDENTITY(1,1),
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianVao] DATETIME NOT NULL,
    [ThoiGianRa] DATETIME NULL,
    [TrangThai] VARCHAR(20) NOT NULL CHECK ([TrangThai] IN ('Checked In', 'Checked Out')),
    CONSTRAINT [PK_checkin] PRIMARY KEY ([MaCheckin]),
    CONSTRAINT [FK_checkin_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: nguoidung
CREATE TABLE [dbo].[nguoidung] (
    [MaNguoiDung] INT NOT NULL IDENTITY(1,1),
    [Email] VARCHAR(255) NOT NULL UNIQUE,
    [MatKhau] VARCHAR(255) NOT NULL,
    [HoVaTen] VARCHAR(255) NOT NULL,
    [NgaySinh] DATETIME NULL,
    [DiaChi] VARCHAR(255) NULL,
    [GioiTinh] VARCHAR(3) NOT NULL CHECK ([GioiTinh] IN ('Nam', N'Nữ')) DEFAULT 'Nam',
    [SoDienThoai] VARCHAR(10) NOT NULL UNIQUE,
    [TrangThai] VARCHAR(20) NOT NULL CHECK ([TrangThai] IN ('Hoạt động', 'Không hoạt động')) DEFAULT 'Hoạt động',
    CONSTRAINT [PK_nguoidung] PRIMARY KEY ([MaNguoiDung])
);

-- Table: phieumuonphong
CREATE TABLE [dbo].[phieumuonphong] (
    [MaPhieuMuonPhong] INT NOT NULL IDENTITY(1,1),
    [MaPhong] INT NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianMuon] DATETIME NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TrangThai] VARCHAR(20) NULL CHECK ([TrangThai] IN ('Đang mượn', 'Đã trả', 'Quá hạn')) DEFAULT 'Đang mượn',
    [TongTien] INT NOT NULL CHECK ([TongTien] >= 0),
    CONSTRAINT [PK_phieumuonphong] PRIMARY KEY ([MaPhieuMuonPhong]),
    CONSTRAINT [FK_phieumuonphong_phong] FOREIGN KEY ([MaPhong]) REFERENCES [dbo].[phong]([MaPhong]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_phieumuonphong_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: phieumuonthietbi
CREATE TABLE [dbo].[phieumuonthietbi] (
    [MaPhieuMuonThietBi] INT NOT NULL IDENTITY(1,1),
    [MaNguoiDung] INT NOT NULL,
    [MaThietBi] INT NOT NULL,
    [TrangThai] VARCHAR(20) NULL CHECK ([TrangThai] IN ('Đang mượn', 'Đã trả', 'Quá hạn')) DEFAULT 'Đang mượn',
    [ThoiGianMuon] DATETIME NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TongTien] INT NOT NULL CHECK ([TongTien] >= 0),
    CONSTRAINT [PK_phieumuonthietbi] PRIMARY KEY ([MaPhieuMuonThietBi]),
    CONSTRAINT [FK_phieumuonthietbi_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_phieumuonthietbi_thietbi] FOREIGN KEY ([MaThietBi]) REFERENCES [dbo].[thietbi]([MaThietBi]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: phieutra
CREATE TABLE [dbo].[phieutra] (
    [MaPhieuTra] INT NOT NULL IDENTITY(1,1),
    [MaNguoiDung] INT NOT NULL,
    [ThoiGianTra] DATETIME NOT NULL,
    [TongTienPhaiTra] INT NULL CHECK ([TongTienPhaiTra] >= 0),
    [TienPhat] INT NULL CHECK ([TienPhat] >= 0),
    CONSTRAINT [PK_phieutra] PRIMARY KEY ([MaPhieuTra]),
    CONSTRAINT [FK_phieutra_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: phong
CREATE TABLE [dbo].[phong] (
    [MaPhong] INT NOT NULL IDENTITY(1,1),
    [TenPhong] VARCHAR(20) NOT NULL UNIQUE,
    [LoaiPhong] VARCHAR(20) NULL,
    [SucChua] INT NOT NULL CHECK ([SucChua] > 0),
    [TrangThai] VARCHAR(20) NOT NULL CHECK ([TrangThai] IN ('Trống', 'Đang mượn', 'Bảo trì')) DEFAULT 'Trống',
    [GiaMuon] INT NOT NULL CHECK ([GiaMuon] > 0),
    CONSTRAINT [PK_phong] PRIMARY KEY ([MaPhong])
);

-- Table: thanhtoan
CREATE TABLE [dbo].[thanhtoan] (
    [MaThanhToan] INT NOT NULL IDENTITY(1,1),
    [MaPhieuTra] INT NOT NULL,
    [TongTienPhaiTra] INT NOT NULL CHECK ([TongTienPhaiTra] >= 0),
    [NgayThanhToan] DATETIME NOT NULL,
    [HinhThucThanhToan] VARCHAR(20) NULL CHECK ([HinhThucThanhToan] IN ('Tiền mặt', 'Chuyển khoản')) DEFAULT 'Tiền mặt',
    CONSTRAINT [PK_thanhtoan] PRIMARY KEY ([MaThanhToan]),
    CONSTRAINT [FK_thanhtoan_phieutra] FOREIGN KEY ([MaPhieuTra]) REFERENCES [dbo].[phieutra]([MaPhieuTra]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: thietbi
CREATE TABLE [dbo].[thietbi] (
    [MaThietBi] INT NOT NULL IDENTITY(1,1),
    [TenThietBi] VARCHAR(255) NOT NULL UNIQUE,
    [LoaiThietBi] VARCHAR(255) NOT NULL,
    [TrangThai] VARCHAR(20) NULL CHECK ([TrangThai] IN ('Có sẵn', 'Đang sử dụng', 'Bảo trì')) DEFAULT 'Có sẵn',
    [GiaMuon] INT NOT NULL CHECK ([GiaMuon] > 0),
    CONSTRAINT [PK_thietbi] PRIMARY KEY ([MaThietBi])
);

-- Table: thongbao
CREATE TABLE [dbo].[thongbao] (
    [MaThongBao] INT NOT NULL IDENTITY(1,1),
    [MaNguoiDung] INT NOT NULL,
    [TieuDe] VARCHAR(255) NOT NULL,
    [NoiDung] TEXT NOT NULL,
    [LoaiThongBao] VARCHAR(20) NULL CHECK ([LoaiThongBao] IN ('Chung', 'Vi Phạm', 'Sự Kiện')) DEFAULT 'Chung',
    [ThoiGianGui] DATETIME NOT NULL,
    CONSTRAINT [PK_thongbao] PRIMARY KEY ([MaThongBao]),
    CONSTRAINT [FK_thongbao_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: vipham
CREATE TABLE [dbo].[vipham] (
    [MaViPham] INT NOT NULL IDENTITY(1,1),
    [MaNguoiDung] INT NOT NULL,
    [MaThietBi] INT NULL,
    [MaPhong] INT NULL,
    [LoaiViPham] VARCHAR(20) NULL CHECK ([LoaiViPham] IN ('Trả trễ', 'Làm hỏng', 'Làm mất', 'Khác')) DEFAULT 'Trả trễ',
    [NoiDungViPham] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_vipham] PRIMARY KEY ([MaViPham]),
    CONSTRAINT [FK_vipham_nguoidung] FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[nguoidung]([MaNguoiDung]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_vipham_thietbi] FOREIGN KEY ([MaThietBi]) REFERENCES [dbo].[thietbi]([MaThietBi]) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT [FK_vipham_phong] FOREIGN KEY ([MaPhong]) REFERENCES [dbo].[phong]([MaPhong]) ON DELETE SET NULL ON UPDATE CASCADE
);
