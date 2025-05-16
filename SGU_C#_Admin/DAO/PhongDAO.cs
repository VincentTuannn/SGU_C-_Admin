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
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True";  

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

        public List<PhongDTO> GetAllPhongByName(string tenPhong)
        {
            List<PhongDTO> danhSach = new List<PhongDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhong, TenPhong, LoaiPhong, SucChua, TrangThai, GiaMuon FROM Phong WHERE TenPhong LIKE @TenPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenPhong", "%" + tenPhong + "%");
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
                    danhSach.Add(phong);
                }
                conn.Close();
            }
            return danhSach;
        }

        public List<PhongDTO> GetAllPhongByID(int maPhong)
        {
            List<PhongDTO> danhSach = new List<PhongDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhong, TenPhong, LoaiPhong, SucChua, TrangThai, GiaMuon FROM Phong WHERE MaPhong = @MaPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
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
                    danhSach.Add(phong);
                }
                conn.Close();
            }
            return danhSach;
        }

        public void AddPhong(PhongDTO phong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO phong (TenPhong, LoaiPhong, SucChua, TrangThai, GiaMuon) " +
                              "VALUES (@TenPhong, @LoaiPhong, @SucChua, @TrangThai, @GiaMuon)";
                SqlCommand cmd = new SqlCommand(query, conn);
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

        public int CountPhongMuon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM phong WHERE TrangThai = N'Đang mượn'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tổng số phòng đã mượn từ cơ sở dữ liệu: " + ex.Message);
            }
        }

        public bool IsRoomExist(string tenPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM thietbi WHERE TenPhong = @TenPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public int CountPhongMuonByDate(DateTime date)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM PhieuMuonPhong 
                               WHERE CONVERT(date, ThoiGianMuon) = @NgayMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayMuon", date.Date)
                };
                return (int)DataProvider.Instance.ExecuteScalar(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm số phòng mượn theo ngày: " + ex.Message);
            }
        }

    }
}
