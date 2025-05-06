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
    public partial class SuaTaiKhoan : Form
    {
        private NguoiDungBUS nguoiDungBUS;
        private int maNguoiDung;
        public SuaTaiKhoan(int maNguoiDung, int maQuyen, string email, string matKhau, string hoVaTen, DateTime ngaySinh, string diaChi, string gioiTinh, string soDienThoai, string trangThai)
        {
            InitializeComponent();
            nguoiDungBUS = new NguoiDungBUS();
            this.maNguoiDung = maNguoiDung;
            textBox_Email.Text = email;
            textBox_Password.Text = matKhau;
            textBox_Name.Text = hoVaTen;
            textBox_Birthday.Text = ngaySinh.ToString("dd/MM/yyyy");
            textBox_Address.Text = diaChi;
            textBox_PhoneNumber.Text = soDienThoai;
            comboBox_Gender.SelectedItem = gioiTinh;
            comboBox_Status.SelectedItem = trangThai;
            comboBox_Role.SelectedItem = maQuyen.ToString();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các TextBox và ComboBox
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
                if (!int.TryParse(maQuyenText, out int maQuyen))
                {
                    MessageBox.Show("Mã quyền không hợp lệ. Vui lòng chọn mã quyền hợp lệ!", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra định dạng ngày sinh
                if (!DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng (ví dụ: dd/MM/yyyy)", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra định dạng số điện thoại (ví dụ: phải là số và độ dài hợp lệ)
                if (!long.TryParse(soDienThoai, out long phoneNumber) || soDienThoai.Length < 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại hợp lệ!", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng NguoiDungDTO
                NguoiDungDTO taiKhoan = new NguoiDungDTO
                {
                    MaQuyen = maQuyen,
                    Email = email,
                    MatKhau = matKhau,
                    HoVaTen = hoVaTen,
                    NgaySinh = ngaySinh,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai,
                    GioiTinh = gioiTinh,
                    TrangThai = trangThai
                };

                // Gọi BUS để cập nhật tài khoản
                nguoiDungBUS.UpdateNguoiDung(taiKhoan);
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            QLTaiKhoan mainForm = new QLTaiKhoan();
            mainForm.Show();
            this.Close();
        }

        private void SuaTaiKhoan_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Add("Hoạt động");
            comboBox_Status.Items.Add("Không hoạt động");
            comboBox_Gender.Items.Add("Nam");
            comboBox_Gender.Items.Add("Nữ");
            comboBox_Role.Items.Add(1);
            comboBox_Role.Items.Add(2);
        }
    }
}
