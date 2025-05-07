using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class CheckInDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True";

        public List<CheckInDTO> GetAllCheckIn()
        {
            List<CheckInDTO> checkInList = new List<CheckInDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM checkin";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckInDTO checkIn = new CheckInDTO
                    {
                        MaCheckin = Convert.ToInt32(reader["MaCheckin"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        ThoiGianVao = Convert.ToDateTime(reader["ThoiGianVao"]),
                        ThoiGianRa = reader["ThoiGianRa"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ThoiGianRa"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    checkInList.Add(checkIn);
                }
                conn.Close();
            }
            return checkInList;
        }

        public List<CheckInDTO> GetAllCheckInByMaNguoiDung(int maNguoiDung)
        {
            List<CheckInDTO> danhSach = new List<CheckInDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaCheckin, MaNguoiDung, ThoiGianVao, ThoiGianRa, TrangThai FROM checkin WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckInDTO checkIn = new CheckInDTO
                    {
                        MaCheckin = Convert.ToInt32(reader["MaCheckin"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        ThoiGianVao = Convert.ToDateTime(reader["ThoiGianVao"]),
                        ThoiGianRa = reader["ThoiGianRa"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ThoiGianRa"]),
                        TrangThai = reader["TrangThai"].ToString(),
                    };
                    danhSach.Add(checkIn);
                }
                conn.Close();
            }
            return danhSach;
        }


        public void AddCheckIn(CheckInDTO checkIn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO checkin (MaNguoiDung, ThoiGianVao, ThoiGianRa, TrangThai) " +
                              "VALUES (@MaNguoiDung, @ThoiGianVao, @ThoiGianRa, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", checkIn.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianVao", checkIn.ThoiGianVao);
                cmd.Parameters.AddWithValue("@ThoiGianRa", checkIn.ThoiGianRa);
                cmd.Parameters.AddWithValue("@TrangThai", checkIn.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateCheckIn(CheckInDTO checkIn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE checkin SET ThoiGianRa = @ThoiGianRa, TrangThai = @TrangThai WHERE MaCheckin = @MaCheckin";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCheckin", checkIn.MaCheckin);
                cmd.Parameters.AddWithValue("@ThoiGianRa", (object)checkIn.ThoiGianRa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", checkIn.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteCheckIn(int maCheckIn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM checkin WHERE MaCheckin = @MaCheckin";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCheckin", maCheckIn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<CheckInDTO> GetCheckInCountsByDate()
        {
            List<CheckInDTO> checkInList = new List<CheckInDTO>();
            string query = "SELECT MaCheckin, MaNguoiDung, ThoiGianVao, ThoiGianRa, TrangThai " +
                          "FROM checkin WHERE TrangThai = 'Checked In' " +
                          "ORDER BY CONVERT(date, ThoiGianVao)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CheckInDTO checkIn = new CheckInDTO
                                {
                                    MaCheckin = Convert.ToInt32(reader["MaCheckin"]),
                                    MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                    ThoiGianVao = Convert.ToDateTime(reader["ThoiGianVao"]),
                                    ThoiGianRa = reader["ThoiGianRa"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ThoiGianRa"]),
                                    TrangThai = reader["TrangThai"].ToString()
                                };
                                checkInList.Add(checkIn);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy danh sách check-in: " + ex.Message);
                    }
                }
            }
            return checkInList;
        }

        public void AddCheckIn(int maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO checkin (MaNguoiDung, ThoiGianVao, TrangThai) VALUES (@MaNguoiDung, @ThoiGianVao, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianVao", DateTime.Now);
                cmd.Parameters.AddWithValue("@TrangThai", "Checked In");
                cmd.Parameters.AddWithValue("@ThoiGianRa", "NAN");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
