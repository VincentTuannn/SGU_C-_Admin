using Microsoft.VisualBasic.Logging;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Microsoft.Data.SqlClient;



namespace SGU_C__User.DAO
{
    internal class ThietBiDAO
    {
        private string connectionString = "Server=localhost;Database=quanlythuquan;Trusted_Connection=True;";

        // Lấy danh sách thiết bị
        public List<ThietBiDTO> GetAllThietBi()
        {
            List<ThietBiDTO> thietbi = new List<ThietBiDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM thietbi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        thietbi.Add(new ThietBiDTO(
                            Convert.ToInt32(reader["MaThietBi"]),
                            reader["TenThietBi"].ToString(),
                            reader["LoaiThietBi"].ToString(),
                            reader["TrangThai"].ToString(),
                            Convert.ToInt32(reader["GiaMuon"])
                        ));
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            return thietbi;
        }

        //Lấy danh sách thiết bị theo ID
        public ThietBiDTO GetById(int maThietBi)
        {
            ThietBiDTO thietBi = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM thietbi WHERE MaThietBi = @MaThietBi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        thietBi = new ThietBiDTO
                        {
                            MaThietBi = reader.GetInt32(0),
                            TenThietBi = reader.GetString(1),
                            LoaiThietBi = reader.GetString(2),
                            TrangThai = reader.GetString(3),
                            GiaMuon = reader.GetInt32(4)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thiết bị theo ID: " + ex.Message);
            }
            return thietBi;
        }

        // Thêm thiết bị mới
        public bool AddThietBi(ThietBiDTO thietbi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO thietbi (TenThietBi, LoaiThietBi, TrangThai, GiaMuon) VALUES (@TenThietBi, @LoaiThietBi, @TrangThai, @GiaMuon)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThietBi", thietbi.TenThietBi);
                cmd.Parameters.AddWithValue("@LoaiThietBi", thietbi.LoaiThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", thietbi.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", thietbi.GiaMuon);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        // Cập nhật thiết bị
        public bool UpdateThietBi(ThietBiDTO thietbi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE thietbi SET TenThietBi = @TenThietBi, LoaiThietBi = @LoaiThietBi, TrangThai = @TrangThai, GiaMuon = @GiaMuon WHERE MaThietBi = @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThietBi", thietbi.MaThietBi);
                cmd.Parameters.AddWithValue("@TenThietBi", thietbi.TenThietBi);
                cmd.Parameters.AddWithValue("@LoaiThietBi", thietbi.LoaiThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", thietbi.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", thietbi.GiaMuon);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        // Xóa thiết bị
        public bool DeleteThietBi(int maThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM thietbi WHERE MaThietBi = @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

       
    }
}
