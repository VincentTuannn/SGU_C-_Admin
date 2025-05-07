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
using OfficeOpenXml;
using System.IO;
using SGU_C__User.DTO;

namespace SGU_C__User
{
    public partial class QLThietBi : Form
    {
        private ThietBiBUS thietBiBUS = new ThietBiBUS();
        public QLThietBi()
        {
            InitializeComponent();
            Input_Search.ForeColor = Color.Black;
            Input_Search.Enter += TextBox1_Enter;
            Input_Search.Leave += TextBox1_Leave;
            LoadDataToGridView(); //Tải lên bảng thiết bị
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Chọn 1 thiết bị
            dataGridView1.MultiSelect = true; //Đảm bảo chỉ cho phép chọn 1 dòng
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Device_Management_Load(object sender, EventArgs e)
        {


        }


        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {

            ThemThietBi AddDevice = new ThemThietBi();
            AddDevice.Show(); // Hiển thị form mới
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_Enter(object? sender, EventArgs e)
        {
            if (Input_Search.Text == "Nhập tên của bạn...")
            {
                Input_Search.Text = "";
                Input_Search.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object? sender, EventArgs e)
        {
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
                var danhSach = thietBiBUS.GetAllThietBi();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["LoaiThietBi"].HeaderText = "Loại thiết bị";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["GiaMuon"].HeaderText = "Giá mượn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maThietBi = Convert.ToInt32(row.Cells["MaThietBi"].Value);
                string tenThietBi = row.Cells["TenThietBi"].Value.ToString();
                string loaiThietBi = row.Cells["LoaiThietBi"].Value.ToString();
                string trangThai = row.Cells["TrangThai"].Value.ToString();
                int giaMuon = Convert.ToInt32(row.Cells["GiaMuon"].Value); // Điều chỉnh kiểu dữ liệu nếu cần

                // Mở form sửa thiết bị với dữ liệu đã chọn
                SuaThietBi formSua = new SuaThietBi(maThietBi, tenThietBi, loaiThietBi, trangThai, giaMuon);
                this.Hide();
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView(); // Tải lại dữ liệu sau khi sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maThietBi = Convert.ToInt32(row.Cells["MaThietBi"].Value);
                string tenThietBi = row.Cells["TenThietBi"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thiết bị '{tenThietBi}' không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        thietBiBUS.DeleteThietBi(maThietBi);
                        LoadDataToGridView(); // Tải lại dữ liệu sau khi xóa
                        MessageBox.Show("Xóa thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_Search.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText) || searchText == "Tìm kiếm theo tên thiết bị")
                {
                    LoadDataToGridView();
                }
                else
                {
                    var danhSach = thietBiBUS.GetAllThietBiByName(searchText);
                    dataGridView1.DataSource = danhSach;

                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                    dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                    dataGridView1.Columns["LoaiThietBi"].HeaderText = "Loại thiết bị";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dataGridView1.Columns["GiaMuon"].HeaderText = "Giá mượn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
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
                        using var package = new ExcelPackage(new FileInfo(openFileDialog.FileName));
                        var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                        int rowCount = worksheet.Dimension.Rows;
                        int successCount = 0;
                        int errorCount = 0;
                        StringBuilder errorMessages = new StringBuilder();

                        // Bắt đầu từ dòng 2 (bỏ qua header)
                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                string tenThietBi = worksheet.Cells[row, 1].Text.Trim();
                                string loaiThietBi = worksheet.Cells[row, 2].Text.Trim();
                                string trangThai = worksheet.Cells[row, 3].Text.Trim();
                                string giaMuonText = worksheet.Cells[row, 4].Text.Trim();

                                // Kiểm tra dữ liệu
                                if (string.IsNullOrEmpty(tenThietBi) || string.IsNullOrEmpty(loaiThietBi) ||
                                    string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(giaMuonText))
                                {
                                    errorMessages.AppendLine($"Dòng {row}: Thiếu thông tin bắt buộc");
                                    errorCount++;
                                    continue;
                                }

                                if (!int.TryParse(giaMuonText, out int giaMuon) || giaMuon < 0)
                                {
                                    errorMessages.AppendLine($"Dòng {row}: Giá mượn không hợp lệ");
                                    errorCount++;
                                    continue;
                                }

                                if (!new List<string> { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(trangThai))
                                {
                                    errorMessages.AppendLine($"Dòng {row}: Trạng thái không hợp lệ (phải là: Có sẵn, Đang sử dụng, Bảo trì)");
                                    errorCount++;
                                    continue;
                                }

                                // Tạo đối tượng ThietBiDTO
                                ThietBiDTO thietBi = new ThietBiDTO
                                {
                                    TenThietBi = tenThietBi,
                                    LoaiThietBi = loaiThietBi,
                                    TrangThai = trangThai,
                                    GiaMuon = giaMuon
                                };

                                // Thêm vào database
                                thietBiBUS.AddThietBi(thietBi);
                                successCount++;
                            }
                            catch (Exception ex)
                            {
                                errorMessages.AppendLine($"Dòng {row}: {ex.Message}");
                                errorCount++;
                            }
                        }

                        // Hiển thị kết quả
                        string message = $"Import hoàn tất!\nThành công: {successCount}\nThất bại: {errorCount}";
                        if (errorCount > 0)
                        {
                            message += "\n\nChi tiết lỗi:\n" + errorMessages.ToString();
                        }

                        MessageBox.Show(message, "Kết quả import", MessageBoxButtons.OK,
                            errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                        // Tải lại dữ liệu
                        LoadDataToGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi import Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void BtnMuonThietBi_Click(object sender, EventArgs e)
        {
            // 1. Nhập mã người dùng
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã người dùng:", "Mượn thiết bị", "");
            if (string.IsNullOrWhiteSpace(input)) return;
            if (!int.TryParse(input, out int maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không hợp lệ!");
                return;
            }

            // 2. Lấy danh sách thiết bị đã đặt
            var danhSach = thietBiBUS.GetThietBiDaDatByNguoiDung(maNguoiDung);
            if (danhSach == null || danhSach.Count == 0)
            {
                MessageBox.Show("Không có thiết bị nào đã đặt!");
                return;
            }

            // 3. Tạo dialog chọn thiết bị
            using (Form dialog = new Form())
            {
                dialog.Text = "Chọn thiết bị để mượn";
                dialog.Size = new Size(600, 450);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                // TableLayoutPanel
                var table = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    RowCount = 2,
                    ColumnCount = 1,
                };
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // DataGridView
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Button panel

                // DataGridView
                DataGridView dgv = new DataGridView
                {
                    DataSource = danhSach,
                    Dock = DockStyle.Fill,
                    AllowUserToAddRows = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                // Thêm cột checkbox nếu chưa có
                if (dgv.Columns["Chon"] == null)
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "Chọn";
                    chk.Name = "Chon";
                    dgv.Columns.Insert(0, chk);
                }

                // Panel chứa các nút
                var buttonPanel = new Panel { Dock = DockStyle.Fill, Height = 60 };
                Button btnChonTatCa = new Button { Text = "Chọn tất cả", Location = new Point(20, 15), Width = 100 };
                Button btnXacNhanMuon = new Button { Text = "Xác nhận", Location = new Point(350, 15), Width = 100, DialogResult = DialogResult.OK };
                Button btnHuyMuon = new Button { Text = "Hủy", Location = new Point(470, 15), Width = 80, DialogResult = DialogResult.Cancel };

                btnChonTatCa.Click += (s, ev) =>
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                        row.Cells["Chon"].Value = true;
                };

                buttonPanel.Controls.Add(btnChonTatCa);
                buttonPanel.Controls.Add(btnXacNhanMuon);
                buttonPanel.Controls.Add(btnHuyMuon);

                table.Controls.Add(dgv, 0, 0);
                table.Controls.Add(buttonPanel, 0, 1);

                dialog.Controls.Add(table);

                dialog.AcceptButton = btnXacNhanMuon;
                dialog.CancelButton = btnHuyMuon;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<int> thietBiChon = new List<int>();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                        {
                            int maThietBi = Convert.ToInt32(row.Cells["MaThietBi"].Value);
                            thietBiChon.Add(maThietBi);
                        }
                    }
                    if (thietBiChon.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa chọn thiết bị nào!");
                        return;
                    }
                    // Cập nhật trạng thái thiết bị
                    foreach (var maThietBi in thietBiChon)
                    {
                        thietBiBUS.UpdateTrangThai(maThietBi, "Đang sử dụng");
                    }
                    MessageBox.Show("Đã chuyển trạng thái các thiết bị thành 'Đang mượn'!");
                    LoadDataToGridView();
                }
            }
        }

        private void BtnTraThietBi_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maThietBi = Convert.ToInt32(row.Cells["MaThietBi"].Value);
                string? trangThai = row.Cells["TrangThai"].Value?.ToString();

                if (trangThai == "Đang sử dụng")
                {
                    try
                    {
                        thietBiBUS.UpdateTrangThai(maThietBi, "Có sẵn", DateTime.Now);
                        LoadDataToGridView();
                        MessageBox.Show("Trả thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi trả thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thiết bị này không thể trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
