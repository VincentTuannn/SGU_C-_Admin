using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class PhieuMuonThietBiDTO
    {
        public int MaPhieuMuonThietBi { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaThietBi { get; set; }
        public string TrangThai { get; set; }
        public DateTime ThoiGianMuon { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public int TongTien { get; set; }

        public PhieuMuonThietBiDTO() { }

        public PhieuMuonThietBiDTO(int maPhieuMuonThietBi, int maNguoiDung, int maThietBi, string trangThai, DateTime thoiGianMuon, DateTime thoiGianTra, int tongTien)
        {
            MaPhieuMuonThietBi = maPhieuMuonThietBi;
            MaNguoiDung = maNguoiDung;
            MaThietBi = maThietBi;
            TrangThai = trangThai;
            ThoiGianMuon = thoiGianMuon;
            ThoiGianTra = thoiGianTra;
            TongTien = tongTien;
        }
    }
}
