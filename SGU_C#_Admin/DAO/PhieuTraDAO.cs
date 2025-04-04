using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class PhieuTraDAO
    {
        private string connectionString = "Server=DESKTOP-LGO8DG6\\SQLEXPRESS;Database=quanlythuquan;Trusted_Connection=True;";

        public List<PhieuTraDTO> GetAllPhieuTra()
        {
            List<PhieuTraDTO> phieuTraList = new List<PhieuTraDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM phieutra";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuTraDTO phieuTra = new PhieuTraDTO
                    {
                        MaPhieuTra = Convert.ToInt32(reader["MaPhieuTra"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        ThoiGianTra = Convert.ToDateTime(reader["ThoiGianTra"]),
                        TongTienPhaiTra = Convert.ToInt32(reader["TongTienPhaiTra"]),
                        TienPhat = Convert.ToInt32(reader["TienPhat"])
                    };
                    phieuTraList.Add(phieuTra);
                }
                conn.Close();
            }
            return phieuTraList;
        }

        public void AddPhieuTra(PhieuTraDTO phieuTra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO phieutra (MaPhieuTra, MaNguoiDung, ThoiGianTra, TongTienPhaiTra, TienPhat) " +
                              "VALUES (@MaPhieuTra, @MaNguoiDung, @ThoiGianTra, @TongTienPhaiTra, @TienPhat)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuTra", phieuTra.MaPhieuTra);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuTra.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuTra.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TongTienPhaiTra", phieuTra.TongTienPhaiTra);
                cmd.Parameters.AddWithValue("@TienPhat", phieuTra.TienPhat);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdatePhieuTra(PhieuTraDTO phieuTra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE phieutra SET MaNguoiDung = @MaNguoiDung, ThoiGianTra = @ThoiGianTra, " +
                              "TongTienPhaiTra = @TongTienPhaiTra, TienPhat = @TienPhat WHERE MaPhieuTra = @MaPhieuTra";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuTra", phieuTra.MaPhieuTra);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuTra.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuTra.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TongTienPhaiTra", phieuTra.TongTienPhaiTra);
                cmd.Parameters.AddWithValue("@TienPhat", phieuTra.TienPhat);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeletePhieuTra(int maPhieuTra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM phieutra WHERE MaPhieuTra = @MaPhieuTra";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuTra", maPhieuTra);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
