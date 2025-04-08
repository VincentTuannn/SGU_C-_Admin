using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class PhieuMuonPhongDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True"; 

        public List<PhieuMuonPhongDTO> GetAllPhieuMuonPhong()
        {
            List<PhieuMuonPhongDTO> phieuMuonPhongList = new List<PhieuMuonPhongDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM phieumuonphong";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuMuonPhongDTO phieuMuonPhong = new PhieuMuonPhongDTO
                    {
                        MaPhieuMuonPhong = Convert.ToInt32(reader["MaPhieuMuonPhong"]),
                        MaPhong = Convert.ToInt32(reader["MaPhong"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        ThoiGianMuon = Convert.ToDateTime(reader["ThoiGianMuon"]),
                        ThoiGianTra = Convert.ToDateTime(reader["ThoiGianTra"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        TongTien = Convert.ToInt32(reader["TongTien"])
                    };
                    phieuMuonPhongList.Add(phieuMuonPhong);
                }
                conn.Close();
            }
            return phieuMuonPhongList;
        }

        public void AddPhieuMuonPhong(PhieuMuonPhongDTO phieuMuonPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO phieumuonphong (MaPhong, MaNguoiDung, ThoiGianMuon, ThoiGianTra, TrangThai, TongTien) " +
                              "VALUES (@MaPhieuMuonPhong, @MaPhong, @MaNguoiDung, @ThoiGianMuon, @ThoiGianTra, @TrangThai, @TongTien)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", phieuMuonPhong.MaPhong);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuMuonPhong.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianMuon", phieuMuonPhong.ThoiGianMuon);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuMuonPhong.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TrangThai", phieuMuonPhong.TrangThai);
                cmd.Parameters.AddWithValue("@TongTien", phieuMuonPhong.TongTien);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdatePhieuMuonPhong(PhieuMuonPhongDTO phieuMuonPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE phieumuonphong SET MaPhong = @MaPhong, MaNguoiDung = @MaNguoiDung, " +
                              "ThoiGianMuon = @ThoiGianMuon, ThoiGianTra = @ThoiGianTra, TrangThai = @TrangThai, TongTien = @TongTien " +
                              "WHERE MaPhieuMuonPhong = @MaPhieuMuonPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuMuonPhong", phieuMuonPhong.MaPhieuMuonPhong);
                cmd.Parameters.AddWithValue("@MaPhong", phieuMuonPhong.MaPhong);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuMuonPhong.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianMuon", phieuMuonPhong.ThoiGianMuon);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuMuonPhong.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TrangThai", phieuMuonPhong.TrangThai);
                cmd.Parameters.AddWithValue("@TongTien", phieuMuonPhong.TongTien);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeletePhieuMuonPhong(int maPhieuMuonPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM phieumuonphong WHERE MaPhieuMuonPhong = @MaPhieuMuonPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuMuonPhong", maPhieuMuonPhong);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
