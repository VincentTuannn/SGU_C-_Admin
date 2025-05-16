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
                        MaQuyen = Convert.ToInt32(reader["MaQuyen"]),
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
                string query = "SELECT MaNguoiDung, MaQuyen, Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai FROM nguoidung WHERE HoVaTen LIKE @HoVaTen";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoVaTen", "%" + hoVaTen + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NguoiDungDTO nguoiDung = new NguoiDungDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        MaQuyen = Convert.ToInt32(reader["MaQuyen"]),
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
                string query = "SELECT MaNguoiDung, MaQuyen, Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NguoiDungDTO nguoiDung = new NguoiDungDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        MaQuyen = Convert.ToInt32(reader["MaQuyen"]),
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
                string query = "INSERT INTO nguoidung (MaQuyen, Email, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, TrangThai) " +
                              "VALUES (@MaQuyen, @Email, @MatKhau, @HoVaTen, @NgaySinh, @DiaChi, @GioiTinh, @SoDienThoai, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaQuyen", nguoiDung.MaQuyen);
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
            if (!IsExist(nguoiDung.MaNguoiDung))
            {
                throw new Exception("Người dùng không tồn tại!");
            }

            if (IsEmailExistForOther(nguoiDung.Email, nguoiDung.MaNguoiDung))
            {
                throw new Exception("Email đã tồn tại cho người dùng khác!");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE nguoidung SET MaQuyen = @MaQuyen, Email = @Email, MatKhau = @MatKhau, HoVaTen = @HoVaTen, " +
                                  "NgaySinh = @NgaySinh, DiaChi = @DiaChi, GioiTinh = @GioiTinh, SoDienThoai = @SoDienThoai, TrangThai = @TrangThai " +
                                  "WHERE MaNguoiDung = @MaNguoiDung";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", nguoiDung.MaNguoiDung);
                    cmd.Parameters.AddWithValue("@MaQuyen", nguoiDung.MaQuyen);
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
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật thông tin người dùng: " + ex.Message);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void DeleteNguoiDung(int maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public NguoiDungDTO DangNhap(string email, string matKhau)
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
                            MaQuyen = Convert.ToInt32(reader["MaQuyen"]),
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
                    return null;
                }
        }

        public void LockNguoiDung(int maNguoiDung)
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

        public bool IsEmailExist(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM nguoidung WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public bool IsExist(int maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public bool IsEmailExistForOther(string email, int maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM nguoidung WHERE Email = @Email AND MaNguoiDung != @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public int CountUserLocked()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM nguoidung WHERE TrangThai = N'Không hoạt động'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count;
            }
        }

        public int CountUserUnlocked()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM nguoidung WHERE TrangThai = N'Hoạt động'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count;
            }
        }

        public async Task<(bool Success, string Message)> DeleteAccountsByBirthYear(int birthYear)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaNguoiDung FROM nguoidung WHERE YEAR(NgaySinh) = @BirthYear";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BirthYear", birthYear);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<int> userIds = new List<int>();
                    while (reader.Read())
                    {
                        userIds.Add(Convert.ToInt32(reader["MaNguoiDung"]));
                    }
                    conn.Close();

                    if (userIds.Count == 0)
                    {
                        return (false, "Không tìm thấy tài khoản nào có năm sinh " + birthYear);
                    }

                    using (SqlConnection deleteConn = new SqlConnection(connectionString))
                    {
                        deleteConn.Open();
                        using (SqlTransaction transaction = deleteConn.BeginTransaction())
                        {
                            try
                            {
                                foreach (int userId in userIds)
                                {
                                    string deleteQuery = "DELETE FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, deleteConn, transaction))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@MaNguoiDung", userId);
                                        deleteCmd.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                                return (true, "Đã xóa " + userIds.Count + " tài khoản có năm sinh " + birthYear);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                Console.WriteLine($"Error deleting accounts by birth year: {ex.Message}");
                                return (false, "Đã xảy ra lỗi khi xóa tài khoản: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting accounts by birth year: {ex.Message}");
                return (false, "Đã xảy ra lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        public int CountUserLockedByDate(DateTime date)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM NguoiDung 
                               WHERE TrangThai = 0 
                               AND CONVERT(date, NgayCapNhat) = @NgayCapNhat";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayCapNhat", date.Date)
                };
                return (int)DataProvider.Instance.ExecuteScalar(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm số người dùng bị khóa theo ngày: " + ex.Message);
            }
        }

        public int CountUserUnlockedByDate(DateTime date)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM NguoiDung 
                               WHERE TrangThai = 1 
                               AND CONVERT(date, NgayCapNhat) = @NgayCapNhat";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayCapNhat", date.Date)
                };
                return (int)DataProvider.Instance.ExecuteScalar(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm số người dùng đang hoạt động theo ngày: " + ex.Message);
            }
        }
    }
}
