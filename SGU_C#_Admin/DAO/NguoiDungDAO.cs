using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class NguoiDungDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True"; 

        public List<NguoiDungDTO> GetAllNguoiDung()
        {
            List<NguoiDungDTO> nguoiDungList = new List<NguoiDungDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM nguoidung";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NguoiDungDTO nguoiDung = new NguoiDungDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        Email = reader["Email"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        HoVaTen = reader["HoVaTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = reader["DiaChi"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    nguoiDungList.Add(nguoiDung);
                }
                conn.Close();
            }
            return nguoiDungList;
        }

        public List<NguoiDungDTO> GetAllNguoiDungByName(string hoVaTen)
        {
            List<NguoiDungDTO> danhSach = new List<NguoiDungDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaNguoiDung, Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai FROM nguoidung WHERE HoVaTen LIKE @HoVaTen";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoVaTen", "%" + hoVaTen + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NguoiDungDTO nguoiDung = new NguoiDungDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        Email = reader["Email"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        HoVaTen = reader["HoVaTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = reader["DiaChi"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(nguoiDung);
                }
                conn.Close();
            }
            return danhSach;
        }

        public List<NguoiDungDTO> GetAllNguoiDungByID(int maNguoiDung)
        {
            List<NguoiDungDTO> danhSach = new List<NguoiDungDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaNguoiDung, Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NguoiDungDTO nguoiDung = new NguoiDungDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        Email = reader["Email"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        HoVaTen = reader["HoVaTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = reader["DiaChi"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(nguoiDung);
                }
                conn.Close();
            }
            return danhSach;
        }

        public void AddNguoiDung(NguoiDungDTO nguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO nguoidung (Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai) " +
                              "VALUES (@Email, @MatKhau, @HoVaTen, @NgaySinh, @DiaChi, @GioiTinh, @SoDienThoai, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", nguoiDung.Email);
                cmd.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
                cmd.Parameters.AddWithValue("@HoVaTen", nguoiDung.HoVaTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nguoiDung.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nguoiDung.DiaChi);
                cmd.Parameters.AddWithValue("@GioiTinh", nguoiDung.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai);
                cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateNguoiDung(NguoiDungDTO nguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE nguoidung SET Email = @Email, MatKhau = @MatKhau, HoVaTen = @HoVaTen, " +
                              "NgaySinh = @NgaySinh, DiaChi = @DiaChi, GioiTinh = @GioiTinh, SoDienThoai = @SoDienThoai, TrangThai = @TrangThai " +
                              "WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", nguoiDung.MaNguoiDung);
                cmd.Parameters.AddWithValue("@Email", nguoiDung.Email);
                cmd.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
                cmd.Parameters.AddWithValue("@HoVaTen", nguoiDung.HoVaTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nguoiDung.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nguoiDung.DiaChi);
                cmd.Parameters.AddWithValue("@GioiTinh", nguoiDung.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai);
                cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteNguoiDung(int maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE nguoidung SET TrangThai = " +
                              "CASE WHEN TrangThai = N'Hoạt động' THEN N'Không hoạt động' " +
                              "ELSE N'Hoạt động' END " +
                              "WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public NguoiDungDTO DangNhap(string email, string matKhau)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM nguoidung WHERE Email = @Email AND MatKhau = @MatKhau AND TrangThai = N'Hoạt động'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new NguoiDungDTO
                        {
                            MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                            Email = reader["Email"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            TrangThai = reader["TrangThai"].ToString()
                        };
                    }
                    else
                    {
                        // Thêm debug để kiểm tra tại sao không có dữ liệu
                        MessageBox.Show($"Không tìm thấy user với Email: {email}, MatKhau: {matKhau}, TrangThai: Hoạt động", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
