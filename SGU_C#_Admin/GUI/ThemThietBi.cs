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
using SGU_C__User.GUI;

namespace SGU_C__User.GUI
{
    public partial class ThemThietBi : Form
    {
        private ThietBiBUS thietBiBUS = new ThietBiBUS();
        public ThemThietBi()
        {
            InitializeComponent();
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
                // Lấy dữ liệu từ textbox
                string thongTinThietBi = textBox1.Text.Trim();
                string loaiThietBi = textBox2.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(thongTinThietBi) || string.IsNullOrEmpty(loaiThietBi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin thiết bị và loại thiết bị!",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Tạo object mới để lưu vào database
                ThietBi thietBiMoi = new ThietBi
                {
                    ThongTin = thongTinThietBi,
                    LoaiThietBi = loaiThietBi,
                    NgayTao = DateTime.Now // Thêm ngày tạo nếu cần
                };

                // Thêm vào database
                dbContext.ThietBis.Add(thietBiMoi);
                int result = dbContext.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thiết bị thành công!",
                                  "Thành công",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // Xóa nội dung textbox sau khi lưu thành công
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể thêm thiết bị!",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                              "Lỗi hệ thống",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
