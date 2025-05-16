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
    public partial class QLMuonPhong : Form
    {
        private PhieuMuonPhongBUS phieuMuonPhongBUS = new PhieuMuonPhongBUS();
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        private Button btnMuonPhong;
        public QLMuonPhong()
        {
            InitializeComponent();
            LoadDataToGridView();
            // Thêm nút Mượn/trả phòng
            btnMuonPhong = new Button();
            btnMuonPhong.Text = "Mượn/trả phòng";
            btnMuonPhong.Size = new Size(150, 30);
            btnMuonPhong.Location = new Point(700, 20);
            btnMuonPhong.Click += BtnMuonTraPhong_Click;
            panel2.Controls.Add(btnMuonPhong);
        }

        private void QLMuonPhong_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = phieuMuonPhongBUS.GetAllPhieuMuonPhong();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = danhSach;

                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaPhieuMuonPhong"].HeaderText = "Mã phiếu mượn phòng";
                dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                dataGridView1.Columns["ThoiGianMuon"].HeaderText = "Thời gian mượn";
                dataGridView1.Columns["ThoiGianTra"].HeaderText = "Thời gian trả";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
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
                    var danhSach = phieuMuonPhongBUS.GetAllPhieuMuonPhongByMaNguoiDung(maNguoiDung);

                    // Gán danh sách phiếu mượn phòng vào DataGridView
                    dataGridView1.DataSource = danhSach;

                    // Tùy chỉnh giao diện của DataGridView
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaPhieuMuonPhong"].HeaderText = "Mã phiếu mượn phòng";
                    dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
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

        private void BtnMuonTraPhong_Click(object sender, EventArgs e)
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

                    // Lấy danh sách phiếu mượn phòng của người dùng
                    var danhSach = phieuMuonPhongBUS.GetAllPhieuMuonPhongByMaNguoiDung(maNguoiDung);
                    if (danhSach == null || danhSach.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy phiếu mượn phòng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Tạo form hiển thị danh sách phiếu
                    using (Form listForm = new Form())
                    {
                        listForm.Text = "Danh sách phiếu mượn phòng";
                        listForm.Size = new Size(900, 600);
                        listForm.StartPosition = FormStartPosition.CenterScreen;
                        listForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        listForm.MaximizeBox = false;
                        listForm.MinimizeBox = false;

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
                                case "MaPhieuMuonPhong":
                                    col.HeaderText = "Mã phiếu mượn";
                                    break;
                                case "MaPhong":
                                    col.HeaderText = "Mã phòng";
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

                        // Nút xác nhận mượn/trả
                        Button btnXacNhan2 = new Button
                        {
                            Text = "Mượn/trả phòng",
                            Dock = DockStyle.Bottom,
                            Height = 40,
                            Font = new Font("Arial", 11, FontStyle.Bold),
                            BackColor = Color.LightSkyBlue
                        };

                        btnXacNhan2.Click += (s, ev) =>
                        {
                            var selectedRows = dgv.Rows.Cast<DataGridViewRow>()
                                .Where(r => r.Cells["Chon"].Value != null && Convert.ToBoolean(r.Cells["Chon"].Value) == true)
                                .ToList();

                            if (selectedRows.Count == 0)
                            {
                                MessageBox.Show("Vui lòng chọn ít nhất một phiếu để xác nhận/trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            int success = 0, fail = 0;
                            foreach (var row in selectedRows)
                            {
                                int maPhieu = Convert.ToInt32(row.Cells["MaPhieuMuonPhong"].Value);
                                string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                                try
                                {
                                    if (trangThai == "Đã đặt chỗ")
                                    {
                                        phieuMuonPhongBUS.UpdateTrangThaiVaThoiGian(maPhieu, "Đang mượn");
                                        success++;
                                    }
                                    else if (trangThai == "Đang mượn")
                                    {
                                        phieuMuonPhongBUS.UpdateTrangThaiVaThoiGian(maPhieu, "Đã trả");
                                        // Có thể cập nhật trạng thái phòng nếu cần
                                        success++;
                                    }
                                    else
                                    {
                                        fail++;
                                    }
                                }
                                catch
                                {
                                    fail++;
                                }
                            }
                            if (success > 0)
                                MessageBox.Show($"Đã xử lý thành công {success} phiếu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (fail > 0)
                                MessageBox.Show($"Có {fail} phiếu xử lý thất bại hoặc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Load lại dữ liệu cho DataGridView mà KHÔNG đóng form
                            var danhSachMoi = phieuMuonPhongBUS.GetAllPhieuMuonPhongByMaNguoiDung(maNguoiDung);
                            dgv.DataSource = null;
                            dgv.DataSource = danhSachMoi;

                            // Đảm bảo cột checkbox luôn có
                            if (dgv.Columns["Chon"] == null)
                                dgv.Columns.Insert(0, new DataGridViewCheckBoxColumn { HeaderText = "Chọn", Name = "Chon" });

                            // Đổi HeaderText nếu cột tồn tại
                            foreach (DataGridViewColumn col in dgv.Columns)
                            {
                                switch (col.Name)
                                {
                                    case "MaPhieuMuonPhong":
                                        col.HeaderText = "Mã phiếu mượn";
                                        break;
                                    case "MaPhong":
                                        col.HeaderText = "Mã phòng";
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
                            ColorRows();
                        };

                        listForm.Controls.Add(dgv);
                        listForm.Controls.Add(btnXacNhan2);
                        listForm.ShowDialog();
                    }
                }
            }
        }
    }
}
