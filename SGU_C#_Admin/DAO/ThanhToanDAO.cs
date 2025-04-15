using Microsoft.Data.SqlClient;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DAO
{
    internal class ThanhToanDAO
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True"; 
        public List<ThanhToanDTO> GetAllThanhToan()
        {
            List<ThanhToanDTO> thanhToanList = new List<ThanhToanDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM thanhtoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThanhToanDTO thanhToan = new ThanhToanDTO
                    {
                        MaThanhToan = Convert.ToInt32(reader["MaThanhToan"]),
                        MaPhieuTra = Convert.ToInt32(reader["MaPhieuTra"]),
                        TongTienPhaiTra = Convert.ToInt32(reader["TongTienPhaiTra"]),
                        NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"]),
                        HinhThucThanhToan = reader["HinhThucThanhToan"].ToString()
                    };
                    thanhToanList.Add(thanhToan);
                }
                conn.Close();
            }
            return thanhToanList;
        }

        public List<ThanhToanDTO> GetAllThanhToanByMaPhieuTra(int maPhieuTra)
        {
            List<ThanhToanDTO> danhSach = new List<ThanhToanDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaThanhToan, MaPhieuTra, TongTienPhaiTra, NgayThanhToan, HinhThucThanhToan FROM thanhtoan WHERE MaPhieuTra = @MaPhieuTra";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuTra", maPhieuTra);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThanhToanDTO thanhToan = new ThanhToanDTO
                    {
                        MaThanhToan = Convert.ToInt32(reader["MaThanhToan"]),
                        MaPhieuTra = Convert.ToInt32(reader["MaPhieuTra"]),
                        TongTienPhaiTra = Convert.ToInt32(reader["TongTienPhaiTra"]),
                        NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"]),
                        HinhThucThanhToan = reader["HinhThucThanhToan"].ToString()
                    };
                    danhSach.Add(thanhToan);
                }
                conn.Close();
            }
            return danhSach;
        }

        public List<ThanhToanDTO> GetAllThanhToanByMaThanhToan(int maThanhToan)
        {
            List<ThanhToanDTO> danhSach = new List<ThanhToanDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaThanhToan, MaPhieuTra, TongTienPhaiTra, NgayThanhToan, HinhThucThanhToan FROM thanhtoan WHERE MaThanhToan = @MaThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThanhToan", maThanhToan);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThanhToanDTO thanhToan = new ThanhToanDTO
                    {
                        MaThanhToan = Convert.ToInt32(reader["MaThanhToan"]),
                        MaPhieuTra = Convert.ToInt32(reader["MaPhieuTra"]),
                        TongTienPhaiTra = Convert.ToInt32(reader["TongTienPhaiTra"]),
                        NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"]),
                        HinhThucThanhToan = reader["HinhThucThanhToan"].ToString()
                    };
                    danhSach.Add(thanhToan);
                }
                conn.Close();
            }
            return danhSach;
        }

        public void AddThanhToan(ThanhToanDTO thanhToan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO thanhtoan (MaPhieuTra, TongTienPhaiTra, NgayThanhToan, HinhThucThanhToan) " +
                              "VALUES (@MaThanhToan, @MaPhieuTra, @TongTienPhaiTra, @NgayThanhToan, @HinhThucThanhToan)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuTra", thanhToan.MaPhieuTra);
                cmd.Parameters.AddWithValue("@TongTienPhaiTra", thanhToan.TongTienPhaiTra);
                cmd.Parameters.AddWithValue("@NgayThanhToan", thanhToan.NgayThanhToan);
                cmd.Parameters.AddWithValue("@HinhThucThanhToan", thanhToan.HinhThucThanhToan);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateThanhToan(ThanhToanDTO thanhToan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE thanhtoan SET MaPhieuTra = @MaPhieuTra, TongTienPhaiTra = @TongTienPhaiTra, " +
                              "NgayThanhToan = @NgayThanhToan, HinhThucThanhToan = @HinhThucThanhToan WHERE MaThanhToan = @MaThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThanhToan", thanhToan.MaThanhToan);
                cmd.Parameters.AddWithValue("@MaPhieuTra", thanhToan.MaPhieuTra);
                cmd.Parameters.AddWithValue("@TongTienPhaiTra", thanhToan.TongTienPhaiTra);
                cmd.Parameters.AddWithValue("@NgayThanhToan", thanhToan.NgayThanhToan);
                cmd.Parameters.AddWithValue("@HinhThucThanhToan", thanhToan.HinhThucThanhToan);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteThanhToan(int maThanhToan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM thanhtoan WHERE MaThanhToan = @MaThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThanhToan", maThanhToan);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
