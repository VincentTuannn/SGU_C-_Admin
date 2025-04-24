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
    public partial class Login : Form
    {
        NguoiDungBUS nguoiDungBus = new NguoiDungBUS();
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = Btn_Login;
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ textBox
                string email = textBox_Email.Text;
                string matKhau = textBox_Password.Text;
                int maQuyen = 1; // Quyền admin

                // Gọi phương thức DangNhapAdmin từ NguoiDungBus
                NguoiDungDTO nguoiDung = nguoiDungBus.DangNhapAdmin(email, matKhau, maQuyen);

                // Kiểm tra kết quả đăng nhập
                if (nguoiDung != null)
                {
                    // Đăng nhập thành công, chuyển hướng đến TrangChu_Admin
                    TrangChu_Admin trangChu = new TrangChu_Admin();
                    trangChu.Show();
                    this.Hide(); // Đóng form đăng nhập
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ShowHide_Click(object sender, EventArgs e)
        {
            // Toggle thuộc tính UseSystemPasswordChar
            textBox_Password.UseSystemPasswordChar = !textBox_Password.UseSystemPasswordChar;

            // Thay đổi icon hoặc text của nút nếu muốn
            if (textBox_Password.UseSystemPasswordChar)
            {
                btn_ShowHide.Text = "👁"; // Mật khẩu đang bị ẩn
            }
            else
            {
                btn_ShowHide.Text = "🙈"; // Mật khẩu đang hiển thị
            }
        }
    }
}
