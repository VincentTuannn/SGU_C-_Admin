using SGU_C__User.BUS;
using SGU_C__User.DTO;
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
    public partial class ThemTaiKhoan : Form
    {
        private NguoiDungBUS nguoiDungBus;
        public ThemTaiKhoan()
        {
            InitializeComponent();
            nguoiDungBus = new NguoiDungBUS();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                string maQuyenText = comboBox_Role.SelectedItem?.ToString();
                string email = textBox_Email.Text.Trim();
                string matKhau = textBox_Password.Text.Trim();
                string hoVaTen = textBox_Name.Text.Trim();
                string ngaySinhText = textBox_Birthday.Text.Trim();
                string diaChi = textBox_Address.Text.Trim();
                string soDienThoai = textBox_PhoneNumber.Text.Trim();
                string gioiTinh = comboBox_Gender.SelectedItem?.ToString();
                string trangThai = comboBox_Status.SelectedItem?.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) ||
                    string.IsNullOrEmpty(hoVaTen) || string.IsNullOrEmpty(ngaySinhText) ||
                    string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(gioiTinh) ||
                    string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(maQuyenText) ||
                    string.IsNullOrEmpty(soDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và chuyển đổi MaQuyen sang int
                int maQuyen;
                if (!int.TryParse(maQuyenText, out maQuyen))
                {
                    MessageBox.Show("Mã quyền không hợp lệ. Vui lòng chọn mã quyền hợp lệ!", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra định dạng ngày sinh
                DateTime ngaySinh;
                if (!DateTime.TryParse(ngaySinhText, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng (ví dụ: dd/MM/yyyy)", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng TaiKhoanDTO
                NguoiDungDTO taiKhoan = new NguoiDungDTO
                {
                    MaQuyen = maQuyen, // Gán giá trị int
                    Email = email,
                    MatKhau = matKhau,
                    HoVaTen = hoVaTen,
                    NgaySinh = ngaySinh,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai,
                    GioiTinh = gioiTinh,
                    TrangThai = trangThai
                };

                // Gọi BUS để thêm tài khoản
                try
                {
                    nguoiDungBus.AddNguoiDung(taiKhoan);
                    MessageBox.Show("Thêm tài khoản thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm tài khoản thất bại: " + ex.Message);
                }

                // Mở lại form quản lý tài khoản
                QLTaiKhoan mainForm = new QLTaiKhoan();
                mainForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            QLTaiKhoan mainForm = new QLTaiKhoan();
            mainForm.Show();
            this.Close();
        }

        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Add("Hoạt động");
            comboBox_Status.Items.Add("Không hoạt động");
            comboBox_Gender.Items.Add("Nam");
            comboBox_Gender.Items.Add("Nữ");
            comboBox_Role.Items.Add(1);
            comboBox_Role.Items.Add(2);
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
