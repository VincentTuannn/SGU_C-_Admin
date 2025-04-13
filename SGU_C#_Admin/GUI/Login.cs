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
using SGU_C__User.DTO;


namespace SGU_C__User.GUI
{
    public partial class Login : Form
    {
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        public Login()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NguoiDungDTO nguoiDung = nguoiDungBUS.DangNhap(email, matKhau);

                if (nguoiDung != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    TrangChu_Admin trangChu = new TrangChu_Admin(nguoiDung);
                    trangChu.Show();
                }
                else
                {
                    MessageBox.Show("Email hoặc mật khẩu không đúng hoặc tài khoản bị khóa.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

