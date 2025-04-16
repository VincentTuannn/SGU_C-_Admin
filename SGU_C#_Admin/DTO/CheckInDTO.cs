using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class CheckInDTO
    {
        public int MaCheckin { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime ThoiGianVao { get; set; }
        public DateTime ThoiGianRa { get; set; }
        public string TrangThai { get; set; }

        public CheckInDTO() { }

        public CheckInDTO(int maCheckIn, int maNguoiDung, DateTime thoiGianVao, DateTime thoiGianRa, string trangThai)
        {
            MaCheckin = maCheckIn;
            MaNguoiDung = maNguoiDung;
            ThoiGianVao = thoiGianVao;
            ThoiGianRa = thoiGianRa;
            TrangThai = trangThai;
        }
    }
}
