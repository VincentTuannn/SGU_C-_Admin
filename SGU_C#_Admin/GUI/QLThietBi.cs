using SGU_C__User.BUS;
using SGU_C__User.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGU_C__User
{
    public partial class QLThietBi : Form
    {
        private ThietBiBUS thietBiBUS = new ThietBiBUS();
        public QLThietBi()
        {
            InitializeComponent();
            textBox1.Text = "Tìm kiếm theo tên thiết bị";
            textBox1.ForeColor = Color.Gray;
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            LoadDataToGridView();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Device_Management_Load(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ThemThietBi AddDevice = new ThemThietBi();
            AddDevice.Show(); // Hiển thị form mới
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào textbox
            if (textBox1.Text == "Nhập tên của bạn...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black; // Chuyển về màu chữ bình thường
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời textbox
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Nhập tên của bạn...";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = thietBiBUS.GetAllThietBi();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["LoaiThietBi"].HeaderText = "Loại thiết bị";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["GiaMuon"].HeaderText = "Giá mượn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

    }
}
