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
    public partial class ThemPhong : Form
    {
        private PhongBUS phongBUS;
        public ThemPhong()
        {
            InitializeComponent();
            phongBUS = new PhongBUS();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                string tenPhong = textBox_Name.Text.Trim();
                string loaiPhong = textBox_Type.Text.Trim();
                string sucChua = textBox_Capacity.Text.Trim();
                string giaMuon = textBox_Price.Text.Trim(); // Thêm TextBox cho GiaMuon
                string trangThai = comboBox_Status.SelectedItem?.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(loaiPhong) ||
                    string.IsNullOrEmpty(sucChua) || string.IsNullOrEmpty(giaMuon) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(sucChua, out int SucChua) || SucChua <= 0)
                {
                    MessageBox.Show("Sức chứa phải là số dương!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(giaMuon, out int GiaMuon) || GiaMuon < 0)
                {
                    MessageBox.Show("Giá mượn phải lớn hơn hoặc bằng 0!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng PhongDTO
                PhongDTO phong = new PhongDTO
                {
                    TenPhong = tenPhong,
                    LoaiPhong = loaiPhong,
                    SucChua = SucChua,
                    TrangThai = trangThai,
                    GiaMuon = GiaMuon
                };

                // Gọi BUS để thêm phòng
                try
                {
                    phongBUS.AddPhong(phong); // Giả định có phương thức AddPhong trong PhongBUS
                    MessageBox.Show("Thêm phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm phòng thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLPhong mainForm = new QLPhong();
            mainForm.Show();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            QLPhong mainForm = new QLPhong();
            mainForm.Show();
            this.Close();
        }

        private void ThemPhong_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Add("Trống");
            comboBox_Status.Items.Add("Đang mượn");
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
