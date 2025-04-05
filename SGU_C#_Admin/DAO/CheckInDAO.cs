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
        private string connectionString = "Data Source=DESKTOP-LGO8DG6\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True";

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
                        MaCheck = Convert.ToInt32(reader["MaCheck"]),
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        ThoiGianVao = Convert.ToDateTime(reader["ThoiGianVao"]),
                        ThoiGianRa = Convert.ToDateTime(reader["ThoiGianRa"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    checkInList.Add(checkIn);
                }
                conn.Close();
            }
            return checkInList;
        }

        public void AddCheckIn(CheckInDTO checkIn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO checkin (ThoiGianVao, ThoiGianRa, TrangThai) " +
                              "VALUES (@ThoiGianVao, @ThoiGianRa, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
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
                string query = "UPDATE checkin SET ThoiGianVao = @ThoiGianVao, " +
                              "ThoiGianRa = @ThoiGianRa, TrangThai = @TrangThai WHERE MaCheck = @MaCheck";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCheck", checkIn.MaCheck);
                cmd.Parameters.AddWithValue("@MaNguoiDung", checkIn.MaNguoiDung);
                cmd.Parameters.AddWithValue("@ThoiGianVao", checkIn.ThoiGianVao);
                cmd.Parameters.AddWithValue("@ThoiGianRa", checkIn.ThoiGianRa);
                cmd.Parameters.AddWithValue("@TrangThai", checkIn.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteCheckIn(int maCheck)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM checkin WHERE MaCheck = @MaCheck";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCheck", maCheck);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
