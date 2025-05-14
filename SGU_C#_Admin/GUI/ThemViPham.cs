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
    public partial class ThemViPham : Form
    {
        private ViPhamBUS viPhamBUS = new ViPhamBUS();
        private int maViPham;
        private int maNguoiDung;
        public ThemViPham()
        {
            InitializeComponent();
            this.maViPham = maViPham;
            this.maNguoiDung = maNguoiDung;
            //comboBox_Type.SelectedItem = loaiViPham;
            //textBox_Content.Text = noiDungViPham;
        }

        private void ThemViPham_Load(object sender, EventArgs e)
        {
            comboBox_Type.Items.Add("Trả trễ");
            comboBox_Type.Items.Add("Làm hỏng");
            comboBox_Type.Items.Add("Làm mất");
            comboBox_Type.Items.Add("Khác");
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox_UserID.Text.Trim(), out int maNguoiDung))
                {
                    MessageBox.Show("Mã người dùng không hợp lệ!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string loaiViPham = comboBox_Type.SelectedItem?.ToString();
                string noiDungViPham = textBox_Content.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(loaiViPham) || string.IsNullOrEmpty(noiDungViPham))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng ViPhamDTO
                ViPhamDTO viPham = new ViPhamDTO
                {
                    MaViPham = this.maViPham,
                    MaNguoiDung = maNguoiDung,
                    LoaiViPham = loaiViPham,
                    NoiDungViPham = noiDungViPham
                };

                // Gọi BUS để cập nhật vi phạm
                viPhamBUS.AddViPham(viPham);
                MessageBox.Show("Cập nhật vi phạm thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                QLViPham mainForm = new QLViPham();
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
            QLViPham qLViPham = new QLViPham();
            qLViPham.Show();
            this.Close();
        }
    }
}
