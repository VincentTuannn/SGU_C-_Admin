using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class PhongDTO
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public int SucChua { get; set; }
        public string TrangThai { get; set; }
        public int GiaMuon { get; set; }

        public PhongDTO() { }

        public PhongDTO(int maPhong, string tenPhong, string loaiPhong, int sucChua, string trangThai, int giaMuon)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            LoaiPhong = loaiPhong;
            SucChua = sucChua;
            TrangThai = trangThai;
            GiaMuon = giaMuon;
        }
    }
}
