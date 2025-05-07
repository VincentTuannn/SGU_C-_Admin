using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGU_C__User.BUS
{
    internal class NguoiDungBUS
    {
        private NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();

        public List<NguoiDungDTO> GetAllNguoiDung()
        {
            return nguoiDungDAO.GetAllNguoiDung();
        }

        public List<NguoiDungDTO> GetAllNguoiDungByName(string hoVaTen)
        {
            try
            {
                return nguoiDungDAO.GetAllNguoiDungByName(hoVaTen);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm người dùng theo tên: " + ex.Message);
            }
        }

        public List<NguoiDungDTO> GetAllNguoiDungByID(int maNguoiDung)
        {
            try
            {
                return nguoiDungDAO.GetAllNguoiDungByID(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm người dùng theo ID: " + ex.Message);
            }
        }

        public void AddNguoiDung(NguoiDungDTO nguoiDung)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(nguoiDung.Email) || !Regex.IsMatch(nguoiDung.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new Exception("Email không hợp lệ!");
            }
            if (nguoiDungDAO.IsEmailExist(nguoiDung.Email))
            {
                throw new Exception("Email đã tồn tại!");
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
            try
            {
                // Kiểm tra logic nghiệp vụ trước khi cập nhật
                if (nguoiDung.MaQuyen <= 0)
                {
                    throw new Exception("Mã quyền không hợp lệ!");
                }
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
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thông tin người dùng: " + ex.Message);
            }
        }

        public void DeleteNguoiDung(int maNguoiDung)
        {
            nguoiDungDAO.DeleteNguoiDung(maNguoiDung);
        }

        public void LockNguoiDung(int maNguoiDung)
        {
            nguoiDungDAO.LockNguoiDung(maNguoiDung);
        }

        // login
        public NguoiDungDTO DangNhap(string email, string matKhau, int maQuyen)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(matKhau))
            {
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");
            }

            return nguoiDungDAO.DangNhap(email, matKhau);
        }

        public NguoiDungDTO DangNhapAdmin(string email, string matKhau, int maQuyen)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(matKhau))
            {
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                // Kiểm tra mã quyền (phải là 1 cho admin)
                if (maQuyen != 1)
                {
                    MessageBox.Show("Tài khoản này không có quyền admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                // Gọi DAO để lấy thông tin người dùng
                NguoiDungDTO nguoiDung = nguoiDungDAO.DangNhap(email, matKhau);
                if (nguoiDung == null)
                {
                    MessageBox.Show("Email hoặc mật khẩu không đúng, hoặc tài khoản không hoạt động!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Kiểm tra lại MaQuyen từ dữ liệu (để chắc chắn)
                if (nguoiDung.MaQuyen != 1)
                {
                    MessageBox.Show("Tài khoản này không có quyền admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return nguoiDung;
            }
        }

        public (bool Success, string Message) DeleteAccountsByBirthYear(int birthYear)
        {
            try
            {
                var task = nguoiDungDAO.DeleteAccountsByBirthYear(birthYear);
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa tài khoản theo năm sinh: " + ex.Message);
            }
        }
    }
}
