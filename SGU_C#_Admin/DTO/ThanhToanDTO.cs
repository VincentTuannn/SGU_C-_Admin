using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class ThanhToanDTO
    {
        public int MaThanhToan { get; set; }
        public int MaPhieuTra { get; set; }
        public int TongTienPhaiTra { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string HinhThucThanhToan { get; set; }

        public ThanhToanDTO() { }

        public ThanhToanDTO(int maThanhToan, int maPhieuTra, int tongTienPhaiTra, DateTime ngayThanhToan, string hinhThucThanhToan)
        {
            MaThanhToan = maThanhToan;
            MaPhieuTra = maPhieuTra;
            TongTienPhaiTra = tongTienPhaiTra;
            NgayThanhToan = ngayThanhToan;
            HinhThucThanhToan = hinhThucThanhToan;
        }
    }
}
