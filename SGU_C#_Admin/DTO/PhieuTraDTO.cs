using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class PhieuTraDTO
    {
        public int MaPhieuTra { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public int TongTienPhaiTra { get; set; }
        public int TienPhat { get; set; }

        public PhieuTraDTO() { }

        public PhieuTraDTO(int maPhieuTra, int maNguoiDung, DateTime thoiGianTra, int tongTienPhaiTra, int tienPhat)
        {
            MaPhieuTra = maPhieuTra;
            MaNguoiDung = maNguoiDung;
            ThoiGianTra = thoiGianTra;
            TongTienPhaiTra = tongTienPhaiTra;
            TienPhat = tienPhat;
        }
    }
}
