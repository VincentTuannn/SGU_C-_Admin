using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class PhieuMuonPhongDTO
    {
        public int MaPhieuMuonPhong { get; set; }
        public int MaPhong { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime ThoiGianMuon { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public string TrangThai { get; set; }
        public int TongTien { get; set; }

        public PhieuMuonPhongDTO() { }

        public PhieuMuonPhongDTO(int maPhieuMuonPhong, int maPhong, int maNguoiDung, DateTime thoiGianMuon, DateTime thoiGianTra, string trangThai, int tongTien)
        {
            MaPhieuMuonPhong = maPhieuMuonPhong;
            MaPhong = maPhong;
            MaNguoiDung = maNguoiDung;
            ThoiGianMuon = thoiGianMuon;
            ThoiGianTra = thoiGianTra;
            TrangThai = trangThai;
            TongTien = tongTien;
        }
    }
}
