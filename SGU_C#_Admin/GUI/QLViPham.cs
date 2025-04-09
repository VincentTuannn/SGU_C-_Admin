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
using static System.Windows.Forms.DataFormats;

namespace SGU_C__User
{
    public partial class QLViPham : Form
    {
        private ViPhamBUS viPhamBUS = new ViPhamBUS();
        public QLViPham()
        {
            InitializeComponent();
            LoadDataToGridView();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void QLViPham_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = viPhamBUS.GetAllViPham();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaViPham"].HeaderText = "Mã vi phạm";
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                dataGridView1.Columns["LoaiViPham"].HeaderText = "Loại vi phạm";
                dataGridView1.Columns["NoiDungViPham"].HeaderText = "Nội dung vi phạm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm theo nội dung vi phạm")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = viPhamBUS.GetAllViPhamByNoiDung(searchText);
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaViPham"].HeaderText = "Mã vi phạm";
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                    dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dataGridView1.Columns["LoaiViPham"].HeaderText = "Loại vi phạm";
                    dataGridView1.Columns["NoiDungViPham"].HeaderText = "Nội dung vi phạm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
