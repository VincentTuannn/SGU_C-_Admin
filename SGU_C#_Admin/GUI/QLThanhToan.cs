using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGU_C__User.BUS;

namespace SGU_C__User.GUI
{
    public partial class QLThanhToan : Form
    {
        private ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
        public QLThanhToan()
        {
            InitializeComponent();
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = thanhToanBUS.GetAllThanhToan();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaThanhToan"].HeaderText = "Mã thanh toán";
                dataGridView1.Columns["MaPhieuTra"].HeaderText = "Mã phiếu trả";
                dataGridView1.Columns["TongTienPhaiTra"].HeaderText = "Tổng tiền phải trả";
                dataGridView1.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
                dataGridView1.Columns["HinhThucThanhToan"].HeaderText = "Hình thức thanh toán";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close();
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ô tìm kiếm và cố gắng chuyển thành số nguyên
                if (!int.TryParse(Input_Search.Text.Trim(), out int maPhieuTra))
                {
                    if (string.IsNullOrEmpty(Input_Search.Text.Trim()) || Input_Search.Text.Trim() == "Tìm kiếm ở đây")
                    {
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mã phiếu trả là một số nguyên!");
                        return;
                    }
                }
                else
                {
                    // Tìm kiếm thanh toán theo MaPhieuTra
                    var danhSach = thanhToanBUS.GetAllThanhToanByMaPhieuTra(maPhieuTra);

                    // Gán danh sách thanh toán vào DataGridView
                    dataGridView1.DataSource = danhSach;

                    // Tùy chỉnh giao diện của DataGridView
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaThanhToan"].HeaderText = "Mã thanh toán";
                    dataGridView1.Columns["MaPhieuTra"].HeaderText = "Mã phiếu trả";
                    dataGridView1.Columns["TongTienPhaiTra"].HeaderText = "Tổng tiền phải trả";
                    dataGridView1.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
                    dataGridView1.Columns["HinhThucThanhToan"].HeaderText = "Hình thức thanh toán";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
