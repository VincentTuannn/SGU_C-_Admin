using SGU_C__User.BUS;
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
    public partial class QLPhong : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        public QLPhong()
        {
            InitializeComponent();
            LoadDataToGridView(); //Tải lên bảng thiết bị
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Chọn 1 thiết bị
            dataGridView1.MultiSelect = false; //Đảm bảo chỉ cho phép chọn 1 dòng
        }

        private void QLPhong_Load(object sender, EventArgs e)
        {

        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm kiếm theo tên phòng")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = phongBUS.GetAllPhongByName(searchText); // Giả định có phương thức GetAllPhongByName
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dataGridView1.Columns["TenPhong"].HeaderText = "Tên phòng";
                    dataGridView1.Columns["LoaiPhong"].HeaderText = "Loại phòng";
                    dataGridView1.Columns["SucChua"].HeaderText = "Sức chứa";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dataGridView1.Columns["GiaMuon"].HeaderText = "Giá mượn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = phongBUS.GetAllPhong();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                dataGridView1.Columns["TenPhong"].HeaderText = "Tên phòng";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
                string tenPhong = row.Cells["TenPhong"].Value.ToString();
                string loaiPhong = row.Cells["LoaiPhong"].Value.ToString();
                int sucChua = Convert.ToInt32(row.Cells["SucChua"].Value);
                string trangThai = row.Cells["TrangThai"].Value.ToString();
                int giaMuon = Convert.ToInt32(row.Cells["GiaMuon"].Value);

                // Mở form sửa phòng với dữ liệu đã chọn
                SuaPhong formSua = new SuaPhong(maPhong, tenPhong, loaiPhong, sucChua, trangThai, giaMuon);
                this.Hide();
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView(); // Tải lại dữ liệu sau khi sửa
                    this.Show(); // Hiển thị lại form hiện tại
                }
                else
                {
                    this.Show(); // Hiển thị lại form nếu người dùng hủy
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
                string tenPhong = row.Cells["TenPhong"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phòng '{tenPhong}' không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        phongBUS.DeletePhong(maPhong); // Gọi phương thức xóa từ PhongBUS
                        LoadDataToGridView(); // Tải lại dữ liệu sau khi xóa
                        MessageBox.Show("Xóa phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThemPhong AddRoom = new ThemPhong();
            AddRoom.Show(); // Hiển thị form mới
            this.Hide();
        }
    }
}
