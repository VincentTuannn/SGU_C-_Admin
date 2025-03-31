using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    public class ViPhamDTO
    {
        public  int MaViPham { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaThietBi { get; set; }
        public int MaPhong { get; set; }
        public string LoaiViPham { get; set; }
        public string NoiDungViPham { get; set; }

        public ViPhamDTO() { }

        public ViPhamDTO(int maViPham, int maNguoiDung, int maThietBi, int maPhong, string loaiViPham, string noiDungViPham)
        {
            MaViPham = maViPham;
            MaNguoiDung = maNguoiDung;
            MaThietBi = maThietBi;
            MaPhong = maPhong;
            LoaiViPham = loaiViPham;
            NoiDungViPham = noiDungViPham;
        }
    }
}
