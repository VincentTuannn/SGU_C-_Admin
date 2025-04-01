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

        private void button4_Click(object sender, EventArgs e)
        {
            QLThietBi mainForm = new QLThietBi();
            mainForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string tenThietBi = textBox1.Text.Trim();
                string loaiThietBi = textBox2.Text.Trim();
                string giaMuon = textBox3.Text.Trim();
                string trangThai = comboBox1.SelectedItem?.ToString();

                //Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenThietBi) || string.IsNullOrEmpty(loaiThietBi) ||  string.IsNullOrEmpty(giaMuon) || string.IsNullOrEmpty(trangThai))
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
                if (thietBiBUS.AddNewThietBi(thietBi))
                {
                    MessageBox.Show("Thêm thiết bị thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Thêm thiết bị thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Có sẵn");
            comboBox1.Items.Add("Đang sử dụng");
            comboBox1.Items.Add("Bảo trì");
        }
    }
}
