using OfficeOpenXml;
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
    public partial class QLTaiKhoan : Form
    {
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        public QLTaiKhoan()
        {
            InitializeComponent();
            Input_Search.ForeColor = Color.Black;
            Input_Search.Enter += TextBox1_Enter;
            Input_Search.Leave += TextBox1_Leave;
            LoadDataToGridView(); //Tải lên bảng thiết bị
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Chọn 1 thiết bị
            dataGridView1.MultiSelect = false; //Đảm bảo chỉ cho phép chọn 1 dòng
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm kiếm theo tên tài khoản")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = nguoiDungBUS.GetAllNguoiDungByName(searchText);
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["MaQuyen"].HeaderText = "Mã quyền";
                    dataGridView1.Columns["HoVaTen"].HeaderText = "Họ và tên";
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào textbox
            if (Input_Search.Text == "Nhập tên của bạn...")
            {
                Input_Search.Text = "";
                Input_Search.ForeColor = Color.Black; // Chuyển về màu chữ bình thường
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời textbox
            if (string.IsNullOrWhiteSpace(Input_Search.Text))
            {
                Input_Search.Text = "Nhập tên của bạn...";
                Input_Search.ForeColor = Color.Gray;
            }
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = nguoiDungBUS.GetAllNguoiDung();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["MaQuyen"].HeaderText = "Mã quyền";
                dataGridView1.Columns["HoVaTen"].HeaderText = "Họ và tên";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan AddAccount = new ThemTaiKhoan();
            AddAccount.Show(); // Hiển thị form mới
            this.Hide();
        }

        private void importExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                    openFileDialog.Title = "Chọn file Excel";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                        {
                            var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                            int rowCount = worksheet.Dimension.Rows;
                            int successCount = 0;
                            int errorCount = 0;
                            StringBuilder errorMessages = new StringBuilder();

                            for (int row = 2; row <= rowCount; row++)
                            {
                                try
                                {
                                    string email = worksheet.Cells[row, 1].Text.Trim();
                                    string matKhau = worksheet.Cells[row, 2].Text.Trim();
                                    string hoVaTen = worksheet.Cells[row, 3].Text.Trim();
                                    string ngaySinhText = worksheet.Cells[row, 4].Text.Trim();
                                    string diaChi = worksheet.Cells[row, 5].Text.Trim();
                                    string trangThai = worksheet.Cells[row, 6].Text.Trim();

                                    // Kiểm tra dữ liệu bắt buộc
                                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) ||
                                        string.IsNullOrEmpty(hoVaTen) || string.IsNullOrEmpty(ngaySinhText) ||
                                        string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(trangThai))
                                    {
                                        errorMessages.AppendLine($"Dòng {row}: Thiếu thông tin bắt buộc");
                                        errorCount++;
                                        continue;
                                    }

                                    // Kiểm tra ngày sinh hợp lệ
                                    if (!DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
                                    {
                                        errorMessages.AppendLine($"Dòng {row}: Ngày sinh không hợp lệ");
                                        errorCount++;
                                        continue;
                                    }

                                    // (Tuỳ chọn) Kiểm tra trạng thái hợp lệ
                                    var trangThaiChoPhep = new List<string> { "Hoạt động", "Tạm khóa", "Đã xóa" };
                                    if (!trangThaiChoPhep.Contains(trangThai))
                                    {
                                        errorMessages.AppendLine($"Dòng {row}: Trạng thái không hợp lệ (phải là: {string.Join(", ", trangThaiChoPhep)})");
                                        errorCount++;
                                        continue;
                                    }

                                    // Tạo đối tượng người dùng
                                    NguoiDungDTO taiKhoan = new NguoiDungDTO
                                    {
                                        Email = email,
                                        MatKhau = matKhau,
                                        HoVaTen = hoVaTen,
                                        NgaySinh = ngaySinh,
                                        DiaChi = diaChi,
                                        TrangThai = trangThai
                                    };

                                    // Gọi BUS để thêm người dùng
                                    nguoiDungBUS.AddNguoiDung(taiKhoan);
                                    successCount++;
                                }
                                catch (Exception ex)
                                {
                                    errorMessages.AppendLine($"Dòng {row}: {ex.Message}");
                                    errorCount++;
                                }
                            }

                            // Thông báo kết quả
                            string message = $"Import hoàn tất!\nThành công: {successCount}\nThất bại: {errorCount}";
                            if (errorCount > 0)
                            {
                                message += "\n\nChi tiết lỗi:\n" + errorMessages.ToString();
                            }

                            MessageBox.Show(message, "Kết quả import", MessageBoxButtons.OK,
                                errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                            // Load lại dữ liệu
                            LoadDataToGridView(); // Giả sử bạn có hàm này để refresh lưới
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi import Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                string hoVaTen = row.Cells["HoVaTen"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa người dùng '{hoVaTen}' không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        nguoiDungBUS.DeleteNguoiDung(maNguoiDung);
                        LoadDataToGridView(); // Tải lại dữ liệu sau khi xóa
                        MessageBox.Show("Xóa người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                int maQuyen = Convert.ToInt32(row.Cells["MaQuyen"].Value);
                string email = row.Cells["Email"].Value.ToString();
                string matKhau = row.Cells["MatKhau"].Value.ToString();
                string hoVaTen = row.Cells["HoVaTen"].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                string diaChi = row.Cells["DiaChi"].Value.ToString();
                string soDienThoai = row.Cells["SoDienThoai"].Value.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                string trangThai = row.Cells["TrangThai"].Value.ToString();

                // Mở form sửa tài khoản với dữ liệu đã chọn
                SuaTaiKhoan formSua = new SuaTaiKhoan(maNguoiDung, maQuyen, email, matKhau, hoVaTen, ngaySinh, diaChi, soDienThoai, gioiTinh, trangThai);
                this.Hide();
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView(); // Tải lại dữ liệu sau khi sửa
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
