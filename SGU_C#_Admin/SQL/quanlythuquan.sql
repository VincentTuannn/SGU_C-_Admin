-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2025 at 05:49 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quanlythuquan`
--

-- --------------------------------------------------------

--
-- Table structure for table `checkin`
--

CREATE TABLE `checkin` (
  `MaCheckin` int(10) UNSIGNED NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `ThoiGianVao` datetime NOT NULL,
  `ThoiGianRa` datetime DEFAULT NULL,
  `TrangThai` enum('Checked In','Checked Out') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nguoidung`
--

CREATE TABLE `nguoidung` (
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `Email` varchar(255) NOT NULL,
  `MatKhau` varchar(255) NOT NULL,
  `HoVaTen` varchar(255) NOT NULL,
  `NgaySinh` datetime DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL,
  `GioiTinh` enum('Nam','Nữ') DEFAULT 'Nam',
  `SoDienThoai` varchar(10) NOT NULL,
  `TrangThai` enum('Hoạt động','Không hoạt động') NOT NULL DEFAULT 'Hoạt động'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phieumuonphong`
--

CREATE TABLE `phieumuonphong` (
  `MaPhieuMuonPhong` int(10) UNSIGNED NOT NULL,
  `MaPhong` int(10) UNSIGNED NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `ThoiGianMuon` datetime NOT NULL,
  `ThoiGianTra` datetime NOT NULL,
  `TrangThai` enum('Đang mượn','Đã trả','Quá hạn') DEFAULT 'Đang mượn',
  `TongTien` int(10) UNSIGNED NOT NULL CHECK (`TongTien` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phieumuonthietbi`
--

CREATE TABLE `phieumuonthietbi` (
  `MaPhieuMuonThietBi` int(10) UNSIGNED NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `MaThietBi` int(10) UNSIGNED NOT NULL,
  `TrangThai` enum('Đang mượn','Đã trả','Quá hạn') DEFAULT 'Đang mượn',
  `ThoiGianMuon` datetime NOT NULL,
  `ThoiGianTra` datetime NOT NULL,
  `TongTien` int(11) NOT NULL CHECK (`TongTien` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phieutra`
--

CREATE TABLE `phieutra` (
  `MaPhieuTra` int(10) UNSIGNED NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `ThoiGianTra` datetime NOT NULL,
  `TongTienPhaiTra` int(10) UNSIGNED DEFAULT NULL CHECK (`TongTienPhaiTra` >= 0),
  `TienPhat` int(10) UNSIGNED DEFAULT NULL CHECK (`TienPhat` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phong`
--

CREATE TABLE `phong` (
  `MaPhong` int(10) UNSIGNED NOT NULL,
  `TenPhong` varchar(20) NOT NULL,
  `LoaiPhong` varchar(20) DEFAULT NULL,
  `SucChua` int(11) NOT NULL CHECK (`SucChua` > 0),
  `TrangThai` enum('Trống','Đang mượn','Bảo trì') NOT NULL DEFAULT 'Trống',
  `GiaMuon` int(10) UNSIGNED NOT NULL CHECK (`GiaMuon` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `thanhtoan`
--

CREATE TABLE `thanhtoan` (
  `MaThanhToan` int(11) NOT NULL,
  `MaPhieuTra` int(10) UNSIGNED NOT NULL,
  `TongTienPhaiTra` int(10) UNSIGNED NOT NULL CHECK (`TongTienPhaiTra` >= 0),
  `NgayThanhToan` datetime NOT NULL,
  `HinhThucThanhToan` enum('Tiền mặt','Chuyển khoản') DEFAULT 'Tiền mặt'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `thietbi`
--

CREATE TABLE `thietbi` (
  `MaThietBi` int(10) UNSIGNED NOT NULL,
  `TenThietBi` varchar(255) NOT NULL,
  `LoaiThietBi` varchar(255) NOT NULL,
  `TrangThai` enum('Có sẵn','Đang sử dụng','Bảo trì') DEFAULT 'Có sẵn',
  `GiaMuon` int(10) UNSIGNED NOT NULL CHECK (`GiaMuon` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `thongbao`
--

CREATE TABLE `thongbao` (
  `MaThongBao` int(11) NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `TieuDe` varchar(255) NOT NULL,
  `NoiDung` text NOT NULL,
  `LoaiThongBao` enum('Chung','Vi Phạm','Sự Kiện') DEFAULT 'Chung',
  `ThoiGianGui` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `vipham`
--

CREATE TABLE `vipham` (
  `MaViPham` int(11) NOT NULL,
  `MaNguoiDung` int(10) UNSIGNED NOT NULL,
  `MaThietBi` int(10) UNSIGNED DEFAULT NULL,
  `MaPhong` int(10) UNSIGNED DEFAULT NULL,
  `LoaiViPham` enum('Trả trễ','Làm hỏng','Làm mất','Khác') DEFAULT 'Trả trễ',
  `NoiDungViPham` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `checkin`
--
ALTER TABLE `checkin`
  ADD PRIMARY KEY (`MaCheckin`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`);

--
-- Indexes for table `nguoidung`
--
ALTER TABLE `nguoidung`
  ADD PRIMARY KEY (`MaNguoiDung`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD UNIQUE KEY `SoDienThoai` (`SoDienThoai`);

--
-- Indexes for table `phieumuonphong`
--
ALTER TABLE `phieumuonphong`
  ADD PRIMARY KEY (`MaPhieuMuonPhong`),
  ADD KEY `MaPhong` (`MaPhong`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`);

--
-- Indexes for table `phieumuonthietbi`
--
ALTER TABLE `phieumuonthietbi`
  ADD PRIMARY KEY (`MaPhieuMuonThietBi`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`),
  ADD KEY `MaThietBi` (`MaThietBi`);

--
-- Indexes for table `phieutra`
--
ALTER TABLE `phieutra`
  ADD PRIMARY KEY (`MaPhieuTra`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`);

--
-- Indexes for table `phong`
--
ALTER TABLE `phong`
  ADD PRIMARY KEY (`MaPhong`),
  ADD UNIQUE KEY `TenPhong` (`TenPhong`);

--
-- Indexes for table `thanhtoan`
--
ALTER TABLE `thanhtoan`
  ADD PRIMARY KEY (`MaThanhToan`),
  ADD KEY `MaPhieuTra` (`MaPhieuTra`);

--
-- Indexes for table `thietbi`
--
ALTER TABLE `thietbi`
  ADD PRIMARY KEY (`MaThietBi`),
  ADD UNIQUE KEY `TenThietBi` (`TenThietBi`);

--
-- Indexes for table `thongbao`
--
ALTER TABLE `thongbao`
  ADD PRIMARY KEY (`MaThongBao`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`);

--
-- Indexes for table `vipham`
--
ALTER TABLE `vipham`
  ADD PRIMARY KEY (`MaViPham`),
  ADD KEY `MaNguoiDung` (`MaNguoiDung`),
  ADD KEY `MaThietBi` (`MaThietBi`),
  ADD KEY `MaPhong` (`MaPhong`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `checkin`
--
ALTER TABLE `checkin`
  MODIFY `MaCheckin` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nguoidung`
--
ALTER TABLE `nguoidung`
  MODIFY `MaNguoiDung` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phieumuonphong`
--
ALTER TABLE `phieumuonphong`
  MODIFY `MaPhieuMuonPhong` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phieumuonthietbi`
--
ALTER TABLE `phieumuonthietbi`
  MODIFY `MaPhieuMuonThietBi` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phieutra`
--
ALTER TABLE `phieutra`
  MODIFY `MaPhieuTra` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phong`
--
ALTER TABLE `phong`
  MODIFY `MaPhong` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `thanhtoan`
--
ALTER TABLE `thanhtoan`
  MODIFY `MaThanhToan` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `thietbi`
--
ALTER TABLE `thietbi`
  MODIFY `MaThietBi` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `thongbao`
--
ALTER TABLE `thongbao`
  MODIFY `MaThongBao` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `vipham`
--
ALTER TABLE `vipham`
  MODIFY `MaViPham` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `checkin`
--
ALTER TABLE `checkin`
  ADD CONSTRAINT `checkin_ibfk_1` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `phieumuonphong`
--
ALTER TABLE `phieumuonphong`
  ADD CONSTRAINT `phieumuonphong_ibfk_1` FOREIGN KEY (`MaPhong`) REFERENCES `phong` (`MaPhong`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `phieumuonphong_ibfk_2` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `phieumuonthietbi`
--
ALTER TABLE `phieumuonthietbi`
  ADD CONSTRAINT `phieumuonthietbi_ibfk_1` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `phieumuonthietbi_ibfk_2` FOREIGN KEY (`MaThietBi`) REFERENCES `thietbi` (`MaThietBi`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `phieutra`
--
ALTER TABLE `phieutra`
  ADD CONSTRAINT `phieutra_ibfk_1` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `thanhtoan`
--
ALTER TABLE `thanhtoan`
  ADD CONSTRAINT `thanhtoan_ibfk_1` FOREIGN KEY (`MaPhieuTra`) REFERENCES `phieutra` (`MaPhieuTra`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `thongbao`
--
ALTER TABLE `thongbao`
  ADD CONSTRAINT `thongbao_ibfk_1` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `vipham`
--
ALTER TABLE `vipham`
  ADD CONSTRAINT `vipham_ibfk_1` FOREIGN KEY (`MaNguoiDung`) REFERENCES `nguoidung` (`MaNguoiDung`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `vipham_ibfk_2` FOREIGN KEY (`MaThietBi`) REFERENCES `thietbi` (`MaThietBi`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `vipham_ibfk_3` FOREIGN KEY (`MaPhong`) REFERENCES `phong` (`MaPhong`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
