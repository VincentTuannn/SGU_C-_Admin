using SGU_C__User.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGU_C__User.GUI
{
    public partial class QLCheckIn : Form
    {
        CheckInBUS checkInBUS = new CheckInBUS();
        public QLCheckIn()
        {
            InitializeComponent();
            LoadDataToGridView();

        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close();
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = checkInBUS.GetAllCheckIn();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaCheckin"].HeaderText = "Mã checkin";
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                dataGridView1.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ô tìm kiếm và cố gắng chuyển thành số nguyên
                if (!int.TryParse(Input_Search.Text.Trim(), out int maNguoiDung))
                {
                    if (string.IsNullOrEmpty(Input_Search.Text.Trim()) || Input_Search.Text.Trim() == "Tìm kiếm ở đây")
                    {
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mã người dùng là một số nguyên!");
                        return;
                    }
                }
                else
                {
                    // Tìm kiếm phiếu mượn phòng theo MaNguoiDung
                    var danhSach = checkInBUS.GetAllCheckInByMaNguoiDung(maNguoiDung);

                    // Gán danh sách phiếu mượn phòng vào DataGridView
                    dataGridView1.DataSource = danhSach;

                    // Tùy chỉnh giao diện của DataGridView
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaCheckin"].HeaderText = "Mã checkin";
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                    dataGridView1.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
