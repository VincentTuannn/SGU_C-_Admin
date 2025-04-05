using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



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
                string query = "DELETE FROM thietbi WHERE MaThietBi = @MaThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


    }
}
