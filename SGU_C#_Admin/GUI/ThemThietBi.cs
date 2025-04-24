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
using SGU_C__User.GUI;

namespace SGU_C__User.GUI
{
    public partial class ThemThietBi : Form
    {
        private ThietBiBUS thietBiBUS;
        public ThemThietBi()
        {
            InitializeComponent();
            thietBiBUS = new ThietBiBUS();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            QLThietBi mainForm = new QLThietBi();
            mainForm.Show();
            this.Close();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                string tenThietBi = textBox_Name.Text.Trim();
                string loaiThietBi = textBox_Type.Text.Trim();
                string giaMuon = textBox_Price.Text.Trim();
                string trangThai = comboBox_Status.SelectedItem?.ToString();

                //Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenThietBi) || string.IsNullOrEmpty(loaiThietBi) || string.IsNullOrEmpty(giaMuon) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(giaMuon, out int GiaMuon) || GiaMuon < 0)
                {
                    MessageBox.Show("Giá mượn phải lớn hơn 0!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng ThietBiDTO
                ThietBiDTO thietBi = new ThietBiDTO
                {
                    TenThietBi = tenThietBi,
                    LoaiThietBi = loaiThietBi,
                    TrangThai = trangThai,
                    GiaMuon = GiaMuon
                };

                // Gọi BUS để thêm thiết bị
                try
                {
                    thietBiBUS.AddThietBi(thietBi);
                    MessageBox.Show("Thêm thiết bị thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thiết bị thất bại: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            QLThietBi mainForm = new QLThietBi();
            mainForm.Show();
            this.Close();
        }



        private void ThemThietBi_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Add("Có sẵn");
            comboBox_Status.Items.Add("Đang sử dụng");
            comboBox_Status.Items.Add("Bảo trì");
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
