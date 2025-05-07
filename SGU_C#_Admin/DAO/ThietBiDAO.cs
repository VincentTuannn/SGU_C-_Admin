using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Diagnostics;



namespace SGU_C__User.DAO
{
    internal class ThietBiDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True";

        public List<ThietBiDTO> GetAllThietBi()
        {
            List<ThietBiDTO> thietBiList = new List<ThietBiDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM thietbi";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                Console.WriteLine("Đã kết nối đến cơ sở dữ liệu");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThietBiDTO thietBi = new ThietBiDTO
                    {
                        MaThietBi = Convert.ToInt32(reader["MaThietBi"]),
                        TenThietBi = reader["TenThietBi"].ToString(),
                        LoaiThietBi = reader["LoaiThietBi"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        GiaMuon = Convert.ToInt32(reader["GiaMuon"])
                    };
                    thietBiList.Add(thietBi);
                }
                conn.Close();
            }
            return thietBiList;
        }

        public List<ThietBiDTO> GetAllThietBiByName(string tenThietBi)
        {
            List<ThietBiDTO> danhSach = new List<ThietBiDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaThietBi, TenThietBi, LoaiThietBi, TrangThai, GiaMuon FROM thietbi WHERE TenThietBi LIKE @TenThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThietBi", "%" + tenThietBi + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThietBiDTO thietBi = new ThietBiDTO
                    {
                        MaThietBi = Convert.ToInt32(reader["MaThietBi"]),
                        TenThietBi = reader["TenThietBi"].ToString(),
                        LoaiThietBi = reader["LoaiThietBi"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        GiaMuon = Convert.ToInt32(reader["GiaMuon"])
                    };
                    danhSach.Add(thietBi);
                }
                conn.Close();
            }
            return danhSach;
        }

        public List<ThietBiDTO> GetAllThietBiByID(int maThietBi)
        {
            List<ThietBiDTO> danhSach = new List<ThietBiDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaThietBi, TenThietBi, LoaiThietBi, TrangThai, GiaMuon FROM thietbi WHERE MaThietBi = @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThietBiDTO thietBi = new ThietBiDTO
                    {
                        MaThietBi = Convert.ToInt32(reader["MaThietBi"]),
                        TenThietBi = reader["TenThietBi"].ToString(),
                        LoaiThietBi = reader["LoaiThietBi"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        GiaMuon = Convert.ToInt32(reader["GiaMuon"])
                    };
                    danhSach.Add(thietBi);
                }
                conn.Close();
            }
            return danhSach;
        }

        public void AddThietBi(ThietBiDTO thietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO thietbi (TenThietBi, LoaiThietBi, TrangThai, GiaMuon) " +
                              "VALUES (@TenThietBi, @LoaiThietBi, @TrangThai, @GiaMuon)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThietBi", thietBi.TenThietBi);
                cmd.Parameters.AddWithValue("@LoaiThietBi", thietBi.LoaiThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", thietBi.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", thietBi.GiaMuon);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateThietBi(ThietBiDTO thietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE thietbi SET TenThietBi = @TenThietBi, LoaiThietBi = @LoaiThietBi, " +
                              "TrangThai = @TrangThai, GiaMuon = @GiaMuon WHERE MaThietBi = @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThietBi", thietBi.MaThietBi);
                cmd.Parameters.AddWithValue("@TenThietBi", thietBi.TenThietBi);
                cmd.Parameters.AddWithValue("@LoaiThietBi", thietBi.LoaiThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", thietBi.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", thietBi.GiaMuon);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteThietBi(int maThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn dữ liệu
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Xóa các bản ghi liên quan trong bảng vpham trước
                        string deleteVPhamQuery = "DELETE FROM vipham WHERE MaThietBi = @MaThietBi";
                        using (SqlCommand cmdVPham = new SqlCommand(deleteVPhamQuery, conn, transaction))
                        {
                            cmdVPham.Parameters.AddWithValue("@MaThietBi", maThietBi);
                            cmdVPham.ExecuteNonQuery();
                        }

                        // Xóa các bản ghi liên quan trong bảng phieumuonthietbi
                        string deletePhieuMuonQuery = "DELETE FROM phieumuonthietbi WHERE MaThietBi = @MaThietBi";
                        using (SqlCommand cmdPhieuMuon = new SqlCommand(deletePhieuMuonQuery, conn, transaction))
                        {
                            cmdPhieuMuon.Parameters.AddWithValue("@MaThietBi", maThietBi);
                            cmdPhieuMuon.ExecuteNonQuery();
                        }

                        // Sau đó xóa thiết bị từ bảng thietbi
                        string deleteThietBiQuery = "DELETE FROM thietbi WHERE MaThietBi = @MaThietBi";
                        using (SqlCommand cmdThietBi = new SqlCommand(deleteThietBiQuery, conn, transaction))
                        {
                            cmdThietBi.Parameters.AddWithValue("@MaThietBi", maThietBi);
                            cmdThietBi.ExecuteNonQuery();
                        }

                        // Nếu mọi thứ thành công, commit giao dịch
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback giao dịch
                        transaction.Rollback();
                        throw new Exception("Lỗi khi xóa thiết bị: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // Phương thức để lấy số lượng thiết bị từ bảng thietbiu
        public int CountSoLuong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM thietbi WHERE TrangThai = N'Đang sử dụng'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số lượng thiết bị từ cơ sở dữ liệu: " + ex.Message);
            }
        }

        public bool IsDeviceExist(string tenThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM thietbi WHERE TenThietBi = @TenThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThietBi", tenThietBi);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public bool IsDeviceExistForOther(string tenThietBi, int maThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM thietbi WHERE TenThietBi = @TenThietBi AND MaThietBi != @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThietBi", tenThietBi);
                cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public async Task<(bool Success, string Message)> DeleteDevicesByType(string loaiThietBi)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaThietBi FROM thietbi WHERE LoaiThietBi = @LoaiThietBi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoaiThietBi", loaiThietBi);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<int> deviceIds = new List<int>();
                    while (reader.Read())
                    {
                        deviceIds.Add(Convert.ToInt32(reader["MaThietBi"]));
                    }
                    conn.Close();

                    if (deviceIds.Count == 0)
                    {
                        return (false, "Không tìm thấy thiết bị nào có loại " + loaiThietBi);
                    }

                    using (SqlConnection deleteConn = new SqlConnection(connectionString))
                    {
                        deleteConn.Open();
                        using (SqlTransaction transaction = deleteConn.BeginTransaction())
                        {
                            try
                            {
                                foreach (int deviceId in deviceIds)
                                {
                                    string deleteVPhamQuery = "DELETE FROM vipham WHERE MaThietBi = @MaThietBi";
                                    string deletePhieuMuonQuery = "DELETE FROM phieumuonthietbi WHERE MaThietBi = @MaThietBi";
                                    string deleteThietBiQuery = "DELETE FROM thietbi WHERE MaThietBi = @MaThietBi";

                                    using (SqlCommand cmdVPham = new SqlCommand(deleteVPhamQuery, deleteConn, transaction))
                                    {
                                        cmdVPham.Parameters.AddWithValue("@MaThietBi", deviceId);
                                        cmdVPham.ExecuteNonQuery();
                                    }

                                    using (SqlCommand cmdPhieuMuon = new SqlCommand(deletePhieuMuonQuery, deleteConn, transaction))
                                    {
                                        cmdPhieuMuon.Parameters.AddWithValue("@MaThietBi", deviceId);
                                        cmdPhieuMuon.ExecuteNonQuery();
                                    }

                                    using (SqlCommand cmdThietBi = new SqlCommand(deleteThietBiQuery, deleteConn, transaction))
                                    {
                                        cmdThietBi.Parameters.AddWithValue("@MaThietBi", deviceId);
                                        cmdThietBi.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                                return (true, "Đã xóa " + deviceIds.Count + " thiết bị có loại " + loaiThietBi);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                Console.WriteLine($"Error deleting devices by type: {ex.Message}");
                                return (false, "Đã xảy ra lỗi khi xóa thiết bị: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting devices by type: {ex.Message}");
                return (false, "Đã xảy ra lỗi khi xóa thiết bị: " + ex.Message);
            }
        }
    }
}