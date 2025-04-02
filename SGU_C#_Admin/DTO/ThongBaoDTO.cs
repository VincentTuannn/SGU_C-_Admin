using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class ThongBaoDTO
    {
        public int MaThongBao { get; set; }
        public int MaNguoiDung { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string LoaiThongBao { get; set; }
        public DateTime ThoiGianGui { get; set; }

        public ThongBaoDTO() { }

        public ThongBaoDTO(int maThongBao, int maNguoiDung, string tieuDe, string noiDung, string loaiThongBao, DateTime thoiGianGui)
        {
            MaThongBao = maThongBao;
            MaNguoiDung = maNguoiDung;
            TieuDe = tieuDe;
            NoiDung = noiDung;
            LoaiThongBao = loaiThongBao;
            ThoiGianGui = thoiGianGui;
        }
    }
}
