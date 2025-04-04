using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class PhongDAO
    {
        private string connectionString = "Server=DESKTOP-LGO8DG6\\SQLEXPRESS;Database=quanlythuquan;Trusted_Connection=True;";  

        public List<PhongDTO> GetAllPhong()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM phong";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhongDTO phong = new PhongDTO
                    {
                        MaPhong = Convert.ToInt32(reader["MaPhong"]),
                        TenPhong = reader["TenPhong"].ToString(),
                        LoaiPhong = reader["LoaiPhong"].ToString(),
                        SucChua = Convert.ToInt32(reader["SucChua"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        GiaMuon = Convert.ToInt32(reader["GiaMuon"])
                    };
                    phongList.Add(phong);
                }
                conn.Close();
            }
            return phongList;
        }

        public void AddPhong(PhongDTO phong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO phong (MaPhong, TenPhong, LoaiPhong, SucChua, TrangThai, GiaMuon) " +
                              "VALUES (@MaPhong, @TenPhong, @LoaiPhong, @SucChua, @TrangThai, @GiaMuon)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);
                cmd.Parameters.AddWithValue("@SucChua", phong.SucChua);
                cmd.Parameters.AddWithValue("@TrangThai", phong.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", phong.GiaMuon);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdatePhong(PhongDTO phong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE phong SET TenPhong = @TenPhong, LoaiPhong = @LoaiPhong, " +
                              "SucChua = @SucChua, TrangThai = @TrangThai, GiaMuon = @GiaMuon WHERE MaPhong = @MaPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);
                cmd.Parameters.AddWithValue("@SucChua", phong.SucChua);
                cmd.Parameters.AddWithValue("@TrangThai", phong.TrangThai);
                cmd.Parameters.AddWithValue("@GiaMuon", phong.GiaMuon);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeletePhong(int maPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM phong WHERE MaPhong = @MaPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
