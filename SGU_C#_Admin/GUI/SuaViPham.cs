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
    public partial class SuaViPham : Form
    {
        private ViPhamBUS viPhamBUS;
        private int maViPham;
        private int maNguoiDung;
        private int maThietBi;
        private int maPhong;
        public SuaViPham(int maViPham, int maNguoiDung, int maThietBi, int maPhong, string loaiViPham, string noiDungViPham)
        {
            InitializeComponent();
            viPhamBUS = new ViPhamBUS();
            this.maViPham = maViPham;
            this.maNguoiDung = maNguoiDung;
            this.maThietBi = maThietBi;
            this.maPhong = maPhong;
            comboBox1.SelectedItem = loaiViPham; 
            textBox1.Text = noiDungViPham;
        }

        private void SuaViPham_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Trả trễ");
            comboBox1.Items.Add("Làm hỏng");
            comboBox1.Items.Add("Làm mất");
            comboBox1.Items.Add("Khác");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //if (viPhamBUS == null)
                //{
                //    MessageBox.Show("viPhamBUS chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                string loaiViPham = comboBox1.SelectedItem?.ToString();
                string noiDungViPham = textBox1.Text.Trim();

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
                    MaViPham = maViPham, 
                    MaNguoiDung = maNguoiDung, 
                    MaThietBi = maThietBi, 
                    MaPhong = maPhong, 
                    LoaiViPham = loaiViPham,
                    NoiDungViPham = noiDungViPham
                };

                // Gọi BUS để cập nhật vi phạm
                viPhamBUS.UpdateViPham(viPham);
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

        private void button4_Click(object sender, EventArgs e)
        {
            QLViPham mainForm = new QLViPham();
            mainForm.Show();
            this.Close();
        }
    }
}
