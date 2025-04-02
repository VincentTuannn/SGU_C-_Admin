using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class NguoiDungDTO
    {
        public int MaNguoiDung { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string TrangThai { get; set; }

        public NguoiDungDTO() { }

        public NguoiDungDTO(int maNguoiDung, string email, string matKhau, string hoVaTen, DateTime ngaySinh, string diaChi, string gioiTinh, string soDienThoai, string trangThai)
        {
            MaNguoiDung = maNguoiDung;
            Email = email;
            MatKhau = matKhau;
            HoVaTen = hoVaTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            TrangThai = trangThai;
        }
    }
}
