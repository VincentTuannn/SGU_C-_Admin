using SGU_C__User.BUS;
using SGU_C__User.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace SGU_C__User
{
    public partial class QLViPham : Form
    {
        private ViPhamBUS viPhamBUS = new ViPhamBUS();
        public QLViPham()
        {
            InitializeComponent();
            LoadDataToGridView(); //Tải lên bảng thiết bị
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Chọn 1 thiết bị
            dataGridView1.MultiSelect = false; //Đảm bảo chỉ cho phép chọn 1 dòng
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void QLViPham_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = viPhamBUS.GetAllViPham();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaViPham"].HeaderText = "Mã vi phạm";
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                dataGridView1.Columns["LoaiViPham"].HeaderText = "Loại vi phạm";
                dataGridView1.Columns["NoiDungViPham"].HeaderText = "Nội dung vi phạm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm theo nội dung vi phạm")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = viPhamBUS.GetAllViPhamByNoiDung(searchText);
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaViPham"].HeaderText = "Mã vi phạm";
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                    dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dataGridView1.Columns["LoaiViPham"].HeaderText = "Loại vi phạm";
                    dataGridView1.Columns["NoiDungViPham"].HeaderText = "Nội dung vi phạm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maViPham = Convert.ToInt32(row.Cells["MaViPham"].Value);
                int maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                int maThietBi = Convert.ToInt32(row.Cells["MaThietBi"].Value);
                int maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
                string loaiViPham = row.Cells["LoaiViPham"].Value.ToString();
                string noiDungViPham = row.Cells["NoiDungViPham"].Value.ToString();

                // Mở form sửa vi phạm với dữ liệu đã chọn
                SuaViPham formSua = new SuaViPham(maViPham, maNguoiDung, maThietBi, maPhong, loaiViPham, noiDungViPham);
                this.Hide();
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView(); // Tải lại dữ liệu sau khi sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một vi phạm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maViPham = Convert.ToInt32(row.Cells["MaViPham"].Value);
                string loaiViPham = row.Cells["LoaiViPham"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa vi phạm '{loaiViPham}' không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        viPhamBUS.DeleteViPham(maViPham);
                        LoadDataToGridView(); // Tải lại dữ liệu sau khi xóa
                        MessageBox.Show("Xóa vi phạm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa vi phạm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một vi phạm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
