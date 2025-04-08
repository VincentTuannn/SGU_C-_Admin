using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class PhieuMuonThietBiDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True";

        public List<PhieuMuonThietBiDTO> GetAllPhieuMuonThietBi()
        {
            List<PhieuMuonThietBiDTO> phieuMuonThietBiList = new List<PhieuMuonThietBiDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM phieumuonthietbi";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuMuonThietBiDTO phieuMuonThietBi = new PhieuMuonThietBiDTO
                    {
                        MaPhieuMuonThietBi = Convert.ToInt32(reader["MaPhieuMuonThietBi"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        MaThietBi = Convert.ToInt32(reader["MaThietBi"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        ThoiGianMuon = Convert.ToDateTime(reader["ThoiGianMuon"]),
                        ThoiGianTra = Convert.ToDateTime(reader["ThoiGianTra"]),
                        TongTien = Convert.ToInt32(reader["TongTien"])
                    };
                    phieuMuonThietBiList.Add(phieuMuonThietBi);
                }
                conn.Close();
            }
            return phieuMuonThietBiList;
        }

        public void AddPhieuMuonThietBi(PhieuMuonThietBiDTO phieuMuonThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO phieumuonthietbi (MaNguoiDung, MaThietBi, TrangThai, ThoiGianMuon, ThoiGianTra, TongTien) " +
                              "VALUES (@MaNguoiDung, @MaThietBi, @TrangThai, @ThoiGianMuon, @ThoiGianTra, @TongTien)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuMuonThietBi.MaNguoiDung);
                cmd.Parameters.AddWithValue("@MaThietBi", phieuMuonThietBi.MaThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", phieuMuonThietBi.TrangThai);
                cmd.Parameters.AddWithValue("@ThoiGianMuon", phieuMuonThietBi.ThoiGianMuon);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuMuonThietBi.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TongTien", phieuMuonThietBi.TongTien);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdatePhieuMuonThietBi(PhieuMuonThietBiDTO phieuMuonThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE phieumuonthietbi SET MaNguoiDung = @MaNguoiDung, MaThietBi = @MaThietBi, " +
                              "TrangThai = @TrangThai, ThoiGianMuon = @ThoiGianMuon, ThoiGianTra = @ThoiGianTra, TongTien = @TongTien " +
                              "WHERE MaPhieuMuonThietBi = @MaPhieuMuonThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuMuonThietBi", phieuMuonThietBi.MaPhieuMuonThietBi);
                cmd.Parameters.AddWithValue("@MaNguoiDung", phieuMuonThietBi.MaNguoiDung);
                cmd.Parameters.AddWithValue("@MaThietBi", phieuMuonThietBi.MaThietBi);
                cmd.Parameters.AddWithValue("@TrangThai", phieuMuonThietBi.TrangThai);
                cmd.Parameters.AddWithValue("@ThoiGianMuon", phieuMuonThietBi.ThoiGianMuon);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuMuonThietBi.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TongTien", phieuMuonThietBi.TongTien);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeletePhieuMuonThietBi(int maPhieuMuonThietBi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM phieumuonthietbi WHERE MaPhieuMuonThietBi = @MaPhieuMuonThietBi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuMuonThietBi", maPhieuMuonThietBi);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
