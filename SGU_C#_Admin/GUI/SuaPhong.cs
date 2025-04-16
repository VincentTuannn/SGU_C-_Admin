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
    public partial class SuaPhong : Form
    {
        private PhongBUS phongBUS;
        private int maPhong;
        public SuaPhong(int maPhong, string tenPhong, string loaiPhong, int sucChua, string trangThai, int giaMuon)
        {
            InitializeComponent();
            phongBUS = new PhongBUS();
            this.maPhong = maPhong;
            textBox_Name.Text = tenPhong;
            textBox_Type.Text = loaiPhong;
            textBox_Capacity.Text = sucChua.ToString();
            textBox_Price.Text = giaMuon.ToString();
            comboBox_Status.SelectedItem = trangThai;
        }

        private void SuaPhong_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Add("Trống");
            comboBox_Status.Items.Add("Đang mượn");
            comboBox_Status.Items.Add("Bảo trì");
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
                    MaPhong = maPhong, // Giả định maPhong đã được khai báo trước (lấy từ form trước đó)
                    TenPhong = tenPhong,
                    LoaiPhong = loaiPhong,
                    SucChua = SucChua,
                    TrangThai = trangThai,
                    GiaMuon = GiaMuon
                };

                // Gọi BUS để cập nhật phòng
                phongBUS.UpdatePhong(phong); // Giả định có phương thức UpdatePhong trong PhongBUS
                MessageBox.Show("Cập nhật phòng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                QLPhong mainForm = new QLPhong();
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
            QLPhong mainForm = new QLPhong();
            mainForm.Show();
            this.Close();
        }
    }
}
