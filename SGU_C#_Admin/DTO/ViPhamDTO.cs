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
        public string LoaiViPham { get; set; }
        public string NoiDungViPham { get; set; }

        public ViPhamDTO() { }

        public ViPhamDTO(int maViPham, int maNguoiDung, string loaiViPham, string noiDungViPham)
        {
            MaViPham = maViPham;
            MaNguoiDung = maNguoiDung;
            LoaiViPham = loaiViPham;
            NoiDungViPham = noiDungViPham;
        }
    }
}
