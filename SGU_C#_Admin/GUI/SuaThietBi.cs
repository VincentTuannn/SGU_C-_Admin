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
    public partial class SuaThietBi : Form
    {
        private ThietBiBUS thietBiBUS;
        private int maThietBi;
        public SuaThietBi(int maThietBi, string tenThietBi, string loaiThietBi, string trangThai, int giaMuon)
        {
            InitializeComponent();
            thietBiBUS = new ThietBiBUS();
            this.maThietBi = maThietBi;
            textBox1.Text = tenThietBi;
            textBox2.Text = loaiThietBi;
            textBox3.Text = giaMuon.ToString();
            comboBox1.SelectedItem = trangThai;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string tenThietBi = textBox1.Text.Trim();
                string loaiThietBi = textBox2.Text.Trim();
                string giaMuon = textBox3.Text.Trim();
                string trangThai = comboBox1.SelectedItem?.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenThietBi) || string.IsNullOrEmpty(loaiThietBi) ||
                    string.IsNullOrEmpty(giaMuon) || string.IsNullOrEmpty(trangThai))
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
                    MaThietBi = maThietBi,
                    TenThietBi = tenThietBi,
                    LoaiThietBi = loaiThietBi,
                    TrangThai = trangThai,
                    GiaMuon = GiaMuon
                };

                // Gọi BUS để cập nhật thiết bị
                thietBiBUS.UpdateThietBi(thietBi);
                MessageBox.Show("Cập nhật thiết bị thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                QLThietBi mainForm = new QLThietBi();
                mainForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLThietBi mainForm = new QLThietBi();
            mainForm.Show();
            this.Close();
        }

        private void SuaThietBi_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Có sẵn");
            comboBox1.Items.Add("Đang sử dụng");
            comboBox1.Items.Add("Bảo trì");
        }
    }
}
