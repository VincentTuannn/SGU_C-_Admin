using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class NguoiDungBUS
    {
        private NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();

        public List<NguoiDungDTO> GetAllNguoiDung()
        {
            return nguoiDungDAO.GetAllNguoiDung();
        }

        public void AddNguoiDung(NguoiDungDTO nguoiDung)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(nguoiDung.Email) || !Regex.IsMatch(nguoiDung.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new Exception("Email không hợp lệ!");
            }
            if (string.IsNullOrEmpty(nguoiDung.MatKhau) || nguoiDung.MatKhau.Length < 6)
            {
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự!");
            }
            if (string.IsNullOrEmpty(nguoiDung.HoVaTen))
            {
                throw new Exception("Họ và tên không được để trống!");
            }
            if (nguoiDung.NgaySinh > DateTime.Now)
            {
                throw new Exception("Ngày sinh không được lớn hơn thời gian hiện tại!");
            }
            if (string.IsNullOrEmpty(nguoiDung.DiaChi))
            {
                throw new Exception("Địa chỉ không được để trống!");
            }
            if (!new List<string> { "Nam", "Nữ" }.Contains(nguoiDung.GioiTinh))
            {
                throw new Exception("Giới tính không hợp lệ!");
            }
            if (string.IsNullOrEmpty(nguoiDung.SoDienThoai) || !Regex.IsMatch(nguoiDung.SoDienThoai, @"^\d{10}$"))
            {
                throw new Exception("Số điện thoại phải có đúng 10 chữ số!");
            }
            if (!new List<string> { "Hoạt động", "Không hoạt động" }.Contains(nguoiDung.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            nguoiDungDAO.AddNguoiDung(nguoiDung);
        }

        public void UpdateNguoiDung(NguoiDungDTO nguoiDung)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (string.IsNullOrEmpty(nguoiDung.Email) || !Regex.IsMatch(nguoiDung.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new Exception("Email không hợp lệ!");
            }
            if (string.IsNullOrEmpty(nguoiDung.MatKhau) || nguoiDung.MatKhau.Length < 6)
            {
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự!");
            }
            if (string.IsNullOrEmpty(nguoiDung.HoVaTen))
            {
                throw new Exception("Họ và tên không được để trống!");
            }
            if (nguoiDung.NgaySinh > DateTime.Now)
            {
                throw new Exception("Ngày sinh không được lớn hơn thời gian hiện tại!");
            }
            if (string.IsNullOrEmpty(nguoiDung.DiaChi))
            {
                throw new Exception("Địa chỉ không được để trống!");
            }
            if (!new List<string> { "Nam", "Nữ" }.Contains(nguoiDung.GioiTinh))
            {
                throw new Exception("Giới tính không hợp lệ!");
            }
            if (string.IsNullOrEmpty(nguoiDung.SoDienThoai) || !Regex.IsMatch(nguoiDung.SoDienThoai, @"^\d{10}$"))
            {
                throw new Exception("Số điện thoại phải có đúng 10 chữ số!");
            }
            if (!new List<string> { "Hoạt động", "Không hoạt động" }.Contains(nguoiDung.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            nguoiDungDAO.UpdateNguoiDung(nguoiDung);
        }

        public void DeleteNguoiDung(int maNguoiDung)
        {
            nguoiDungDAO.DeleteNguoiDung(maNguoiDung);
        }

        // login
        public NguoiDungDTO DangNhap(string email, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(matKhau))
            {
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");
            }

            return nguoiDungDAO.DangNhap(email, matKhau);
        }

    }
}
