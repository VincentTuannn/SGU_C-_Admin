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
    public partial class QLMuonThietBi : Form
    {
        private PhieuMuonThietBiBUS phieuMuonThietBiBUS = new PhieuMuonThietBiBUS();
        private Button btnMuonThietBi;
        private Button btnTraThietBi;
        public QLMuonThietBi()
        {
            InitializeComponent();
            LoadDataToGridView();
            // Thêm nút Mượn thiết bị
            btnMuonThietBi = new Button();
            btnMuonThietBi.Text = "Mượn thiết bị";
            btnMuonThietBi.Size = new Size(120, 30);
            btnMuonThietBi.Location = new Point(650, 20);
            btnMuonThietBi.Click += BtnMuonThietBi_Click;
            panel2.Controls.Add(btnMuonThietBi);

            // Thêm nút Trả thiết bị
            btnTraThietBi = new Button();
            btnTraThietBi.Text = "Trả thiết bị";
            btnTraThietBi.Size = new Size(120, 30);
            btnTraThietBi.Location = new Point(780, 20);
            btnTraThietBi.Click += BtnTraThietBi_Click;
            panel2.Controls.Add(btnTraThietBi);
        }

        private void QLMuonThietBi_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = phieuMuonThietBiBUS.GetAllPhieuMuonThietBi();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaPhieuMuonThietBi"].HeaderText = "Mã phiếu mượn thiết bị";
                dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["ThoiGianMuon"].HeaderText = "Thời gian mượn";
                dataGridView1.Columns["ThoiGianTra"].HeaderText = "Thời gian trả";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";

                // Tùy chỉnh màu sắc cho các trạng thái
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    switch (trangThai)
                    {
                        case "Đang mượn":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Đã xác nhận":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Đã trả":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ô tìm kiếm và cố gắng chuyển thành số nguyên
                if (!int.TryParse(Input_Search.Text.Trim(), out int maNguoiDung))
                {
                    if (string.IsNullOrEmpty(Input_Search.Text.Trim()) || Input_Search.Text.Trim() == "Tìm kiếm ở đây")
                    {
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mã người dùng là một số nguyên!");
                        return;
                    }
                }
                else
                {
                    // Tìm kiếm phiếu mượn phòng theo MaNguoiDung
                    var danhSach = phieuMuonThietBiBUS.GetAllPhieuMuonThietBiByMaNguoiDung(maNguoiDung);

                    // Gán danh sách phiếu mượn phòng vào DataGridView
                    dataGridView1.DataSource = danhSach;

                    // Tùy chỉnh giao diện của DataGridView
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaPhieuMuonThietBi"].HeaderText = "Mã phiếu mượn thiết bị";
                    dataGridView1.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                    dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dataGridView1.Columns["ThoiGianMuon"].HeaderText = "Thời gian mượn";
                    dataGridView1.Columns["ThoiGianTra"].HeaderText = "Thời gian trả";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
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
            // Tạo form nhập mã người dùng
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Nhập mã người dùng";
                inputForm.Size = new Size(400, 150);
                inputForm.StartPosition = FormStartPosition.CenterScreen;
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.MaximizeBox = false;
                inputForm.MinimizeBox = false;

                Label lblMaNguoiDung = new Label
                {
                    Text = "Mã người dùng:",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                TextBox txtMaNguoiDung = new TextBox
                {
                    Location = new Point(120, 17),
                    Size = new Size(200, 25)
                };

                Button btnXacNhan = new Button
                {
                    Text = "Xác nhận",
                    DialogResult = DialogResult.OK,
                    Location = new Point(200, 60),
                    Size = new Size(80, 30)
                };

                Button btnHuy = new Button
                {
                    Text = "Hủy",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(290, 60),
                    Size = new Size(80, 30)
                };

                inputForm.Controls.AddRange(new Control[] { lblMaNguoiDung, txtMaNguoiDung, btnXacNhan, btnHuy });
                inputForm.AcceptButton = btnXacNhan;
                inputForm.CancelButton = btnHuy;

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    if (!int.TryParse(txtMaNguoiDung.Text.Trim(), out int maNguoiDung))
                    {
                        MessageBox.Show("Vui lòng nhập mã người dùng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy danh sách thiết bị đã mượn của người dùng
                    var danhSach = phieuMuonThietBiBUS.GetAllPhieuMuonThietBiByMaNguoiDung(maNguoiDung);
                    if (danhSach == null || danhSach.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thiết bị nào đã mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Tạo form hiển thị danh sách thiết bị
                    using (Form listForm = new Form())
                    {
                        listForm.Text = "Danh sách thiết bị đã mượn";
                        listForm.Size = new Size(900, 600);
                        listForm.StartPosition = FormStartPosition.CenterScreen;
                        listForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        listForm.MaximizeBox = false;
                        listForm.MinimizeBox = false;

                        // TableLayoutPanel để layout các control
                        TableLayoutPanel table = new TableLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            RowCount = 3,
                            ColumnCount = 1,
                            AutoSize = true
                        };
                        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45)); // filter
                        table.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // datagrid
                        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // button

                        // Panel filter
                        Panel filterPanel = new Panel { Dock = DockStyle.Fill, Height = 45 };
                        Label lblLoc = new Label
                        {
                            Text = "Lọc theo trạng thái:",
                            Location = new Point(10, 12),
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Bold)
                        };
                        ComboBox cbTrangThai = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Location = new Point(140, 8),
                            Width = 200,
                            Font = new Font("Arial", 10)
                        };
                        cbTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang mượn", "Đã xác nhận", "Đã trả" });
                        cbTrangThai.SelectedIndex = 0;
                        filterPanel.Controls.Add(lblLoc);
                        filterPanel.Controls.Add(cbTrangThai);

                        // DataGridView
                        DataGridView dgv = new DataGridView
                        {
                            DataSource = danhSach,
                            Dock = DockStyle.Fill,
                            AllowUserToAddRows = false,
                            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            RowHeadersVisible = false,
                            BackgroundColor = Color.White
                        };
                        // Thêm cột checkbox để chọn phiếu
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = "Chọn";
                        checkBoxColumn.Name = "Chon";
                        dgv.Columns.Insert(0, checkBoxColumn);

                        // Đổi HeaderText nếu cột tồn tại
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            switch (col.Name)
                            {
                                case "MaPhieuMuonThietBi":
                                    col.HeaderText = "Mã phiếu mượn";
                                    break;
                                case "MaThietBi":
                                    col.HeaderText = "Mã thiết bị";
                                    break;
                                case "MaNguoiDung":
                                    col.HeaderText = "Mã người dùng";
                                    break;
                                case "ThoiGianMuon":
                                    col.HeaderText = "Thời gian mượn";
                                    break;
                                case "ThoiGianTra":
                                    col.HeaderText = "Thời gian trả";
                                    break;
                                case "TrangThai":
                                    col.HeaderText = "Trạng thái";
                                    break;
                                case "TongTien":
                                    col.HeaderText = "Tổng tiền";
                                    break;
                            }
                        }

                        // Tùy chỉnh màu sắc cho các trạng thái
                        void ColorRows()
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                                switch (trangThai)
                                {
                                    case "Đã đặt chỗ":
                                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                                        break;
                                    case "Đang mượn":
                                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                                        break;
                                    case "Đã trả":
                                        row.DefaultCellStyle.BackColor = Color.LightGray;
                                        break;
                                }
                            }
                        }
                        ColorRows();

                        // Nút xác nhận mượn
                        Button btnXacNhan2 = new Button
                        {
                            Text = "Xác nhận mượn",
                            Dock = DockStyle.Fill,
                            Height = 40,
                            Font = new Font("Arial", 11, FontStyle.Bold),
                            BackColor = Color.LightSkyBlue
                        };

                        // Thêm các control vào table
                        table.Controls.Add(filterPanel, 0, 0);
                        table.Controls.Add(dgv, 0, 1);
                        table.Controls.Add(btnXacNhan2, 0, 2);
                        listForm.Controls.Add(table);

                        // Sự kiện lọc trạng thái
                        cbTrangThai.SelectedIndexChanged += (s, ev) =>
                        {
                            string selected = cbTrangThai.SelectedItem.ToString();
                            List<object> filtered;
                            if (selected == "Tất cả")
                                filtered = danhSach.Cast<object>().ToList();
                            else
                                filtered = danhSach.Where(x => x.GetType().GetProperty("TrangThai")?.GetValue(x)?.ToString() == selected).Cast<object>().ToList();
                            dgv.DataSource = null;
                            dgv.DataSource = filtered;
                            // Đảm bảo cột checkbox luôn có
                            if (dgv.Columns["Chon"] == null)
                                dgv.Columns.Insert(0, new DataGridViewCheckBoxColumn { HeaderText = "Chọn", Name = "Chon" });
                            ColorRows();
                        };

                        // Sự kiện xác nhận mượn
                        btnXacNhan2.Click += (s, ev) =>
                        {
                            var selectedRows = dgv.Rows.Cast<DataGridViewRow>()
                                .Where(r => r.Cells["Chon"].Value != null && Convert.ToBoolean(r.Cells["Chon"].Value) == true)
                                .ToList();

                            if (selectedRows.Count == 0)
                            {
                                MessageBox.Show("Vui lòng chọn ít nhất một phiếu để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            int success = 0, fail = 0;
                            foreach (var row in selectedRows)
                            {
                                int maPhieu = Convert.ToInt32(row.Cells["MaPhieuMuonThietBi"].Value);
                                string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                                if (trangThai == "Đã đặt chỗ")
                                {
                                    try
                                    {
                                        phieuMuonThietBiBUS.UpdateTrangThaiPhieuMuonThietBi(maPhieu, "Đang mượn");
                                        success++;
                                    }
                                    catch
                                    {
                                        fail++;
                                    }
                                }
                            }
                            if (success > 0)
                                MessageBox.Show($"Đã xác nhận thành công {success} phiếu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (fail > 0)
                                MessageBox.Show($"Có {fail} phiếu xác nhận thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            listForm.Close();
                            LoadDataToGridView(); // Refresh lại danh sách chính
                        };

                        listForm.ShowDialog();
                    }
                }
            }
        }

        private void BtnTraThietBi_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maPhieuMuonThietBi = Convert.ToInt32(row.Cells["MaPhieuMuonThietBi"].Value);
                string? trangThai = row.Cells["TrangThai"].Value?.ToString();

                if (trangThai == "Đã xác nhận")
                {
                    try
                    {
                        phieuMuonThietBiBUS.UpdateTrangThaiPhieuMuonThietBi(maPhieuMuonThietBi, "Đã trả");
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
                    MessageBox.Show("Chỉ có thể trả thiết bị đã được xác nhận mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
