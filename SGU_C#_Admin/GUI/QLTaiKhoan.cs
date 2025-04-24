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
    public partial class QLTaiKhoan : Form
    {
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        public QLTaiKhoan()
        {
            InitializeComponent();
            Input_Search.ForeColor = Color.Black;
            Input_Search.Enter += TextBox1_Enter;
            Input_Search.Leave += TextBox1_Leave;
            LoadDataToGridView(); //Tải lên bảng thiết bị
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Chọn 1 thiết bị
            dataGridView1.MultiSelect = false; //Đảm bảo chỉ cho phép chọn 1 dòng
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm kiếm theo tên tài khoản")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = nguoiDungBUS.GetAllNguoiDungByName(searchText);
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["MaQuyen"].HeaderText = "Mã quyền";
                    dataGridView1.Columns["HoVaTen"].HeaderText = "Họ và tên";
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào textbox
            if (Input_Search.Text == "Nhập tên của bạn...")
            {
                Input_Search.Text = "";
                Input_Search.ForeColor = Color.Black; // Chuyển về màu chữ bình thường
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời textbox
            if (string.IsNullOrWhiteSpace(Input_Search.Text))
            {
                Input_Search.Text = "Nhập tên của bạn...";
                Input_Search.ForeColor = Color.Gray;
            }
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = nguoiDungBUS.GetAllNguoiDung();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["MaQuyen"].HeaderText = "Mã quyền";
                dataGridView1.Columns["HoVaTen"].HeaderText = "Họ và tên";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
