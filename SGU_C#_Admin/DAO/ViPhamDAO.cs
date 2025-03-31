using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace SGU_C__User.DAO
{
    public class ViPhamDAO
    {
        private string connectionString = "Server=localhost;Database=quanlythuquan;Integrated Security=True;";

        // Lấy danh sách tất cả vi phạm
        public List<ViPhamDTO> GetAllViPham()
        {
            List<ViPhamDTO> viPham = new List<ViPhamDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM vipham";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        viPham.Add(new ViPhamDTO(
                            Convert.ToInt32(reader["MaViPham"]),
                            Convert.ToInt32(reader["MaNguoiDung"]),
                            Convert.ToInt32(reader["MaThietBi"]),
                            Convert.ToInt32(reader["MaPhong"]),
                            reader["LoaiViPham"].ToString(),
                            reader["NoiDungViPham"] != DBNull.Value ? reader["NoiDungViPham"].ToString() : string.Empty
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return viPham;
        }

        // Thêm vi phạm mới
        public bool AddViPham(ViPhamDTO viPham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO vipham (MaNguoiDung, MaThietBi, MaPhong, LoaiViPham, NoiDungViPham) " +
                                  "VALUES (@MaNguoiDung, @MaThietBi, @MaPhong, @LoaiViPham, @NoiDungViPham)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", viPham.MaNguoiDung);
                    cmd.Parameters.AddWithValue("@MaThietBi", viPham.MaThietBi);
                    cmd.Parameters.AddWithValue("@MaPhong", viPham.MaPhong);
                    cmd.Parameters.AddWithValue("@LoaiViPham", viPham.LoaiViPham);
                    cmd.Parameters.AddWithValue("@NoiDungViPham", viPham.NoiDungViPham ?? (object)DBNull.Value);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        // Cập nhật vi phạm
        public bool UpdateViPham(ViPhamDTO viPham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE vipham SET MaNguoiDung = @MaNguoiDung, MaThietBi = @MaThietBi, " +
                                  "MaPhong = @MaPhong, LoaiViPham = @LoaiViPham, NoiDungViPham = @NoiDungViPham " +
                                  "WHERE MaViPham = @MaViPham";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaViPham", viPham.MaViPham);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", viPham.MaNguoiDung);
                    cmd.Parameters.AddWithValue("@MaThietBi", viPham.MaThietBi);
                    cmd.Parameters.AddWithValue("@MaPhong", viPham.MaPhong);
                    cmd.Parameters.AddWithValue("@LoaiViPham", viPham.LoaiViPham);
                    cmd.Parameters.AddWithValue("@NoiDungViPham", viPham.NoiDungViPham ?? (object)DBNull.Value);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        // Xóa vi phạm
        public bool DeleteViPham(int maViPham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM vipham WHERE MaViPham = @MaViPham";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaViPham", maViPham);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}