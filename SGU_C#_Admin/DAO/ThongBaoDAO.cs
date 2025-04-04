using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class ThongBaoDAO
    {
        private string connectionString = "Server=DESKTOP-LGO8DG6\\SQLEXPRESS;Database=quanlythuquan;Trusted_Connection=True;";

        public List<ThongBaoDTO> GetAllThongBao()
        {
            List<ThongBaoDTO> thongBaoList = new List<ThongBaoDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM thongbao";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThongBaoDTO thongBao = new ThongBaoDTO
                    {
                        MaThongBao = Convert.ToInt32(reader["MaThongBao"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        TieuDe = reader["TieuDe"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        LoaiThongBao = reader["LoaiThongBao"].ToString(),
                        ThoiGianGui = Convert.ToDateTime(reader["ThoiGianGui"])
                    };
                    thongBaoList.Add(thongBao);
                }
                conn.Close();
            }
            return thongBaoList;
        }

        public void AddThongBao(ThongBaoDTO thongBao)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO thongbao (MaThongBao, MaNguoiDung, TieuDe, NoiDung, LoaiThongBao, ThoiGianGui) " +
                              "VALUES (@MaThongBao, @MaNguoiDung, @TieuDe, @NoiDung, @LoaiThongBao, @ThoiGianGui)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", thongBao.MaThongBao);
                cmd.Parameters.AddWithValue("@MaNguoiDung", thongBao.MaNguoiDung);
                cmd.Parameters.AddWithValue("@TieuDe", thongBao.TieuDe);
                cmd.Parameters.AddWithValue("@NoiDung", thongBao.NoiDung);
                cmd.Parameters.AddWithValue("@LoaiThongBao", thongBao.LoaiThongBao);
                cmd.Parameters.AddWithValue("@ThoiGianGui", thongBao.ThoiGianGui);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateThongBao(ThongBaoDTO thongBao)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE thongbao SET MaNguoiDung = @MaNguoiDung, TieuDe = @TieuDe, " +
                              "NoiDung = @NoiDung, LoaiThongBao = @LoaiThongBao, ThoiGianGui = @ThoiGianGui " +
                              "WHERE MaThongBao = @MaThongBao";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", thongBao.MaThongBao);
                cmd.Parameters.AddWithValue("@MaNguoiDung", thongBao.MaNguoiDung);
                cmd.Parameters.AddWithValue("@TieuDe", thongBao.TieuDe);
                cmd.Parameters.AddWithValue("@NoiDung", thongBao.NoiDung);
                cmd.Parameters.AddWithValue("@LoaiThongBao", thongBao.LoaiThongBao);
                cmd.Parameters.AddWithValue("@ThoiGianGui", thongBao.ThoiGianGui);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteThongBao(int maThongBao)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM thongbao WHERE MaThongBao = @MaThongBao";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", maThongBao);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
