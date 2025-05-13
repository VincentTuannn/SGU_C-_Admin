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
    public partial class MuonThietBi : Form
    {
        private PhieuMuonThietBiBUS phieuMuonThietBiBUS = new PhieuMuonThietBiBUS();

        public MuonThietBi()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Mượn Thiết Bị";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo panel chính
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Tạo label tiêu đề
            Label lblTitle = new Label
            {
                Text = "Mượn Thiết Bị",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Tạo panel nhập mã người dùng
            Panel inputPanel = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(740, 50)
            };

            Label lblMaNguoiDung = new Label
            {
                Text = "Mã người dùng:",
                Location = new Point(0, 15),
                AutoSize = true
            };

            TextBox txtMaNguoiDung = new TextBox
            {
                Location = new Point(120, 12),
                Size = new Size(200, 25)
            };

            Button btnTimKiem = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(340, 10),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White
            };

            inputPanel.Controls.AddRange(new Control[] { lblMaNguoiDung, txtMaNguoiDung, btnTimKiem });

            // Tạo DataGridView
            DataGridView dgvThietBi = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(740, 300),
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };

            // Thêm cột checkbox
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Chọn";
            chk.Name = "Chon";
            dgvThietBi.Columns.Add(chk);

            // Tạo panel nút
            Panel buttonPanel = new Panel
            {
                Location = new Point(20, 440),
                Size = new Size(740, 50)
            };

            Button btnChonTatCa = new Button
            {
                Text = "Chọn tất cả",
                Location = new Point(0, 10),
                Size = new Size(120, 30)
            };

            Button btnXacNhan = new Button
            {
                Text = "Xác nhận",
                Location = new Point(620, 10),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White
            };

            Button btnHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(500, 10),
                Size = new Size(100, 30)
            };

            buttonPanel.Controls.AddRange(new Control[] { btnChonTatCa, btnXacNhan, btnHuy });

            // Thêm các control vào form
            mainPanel.Controls.AddRange(new Control[] { lblTitle, inputPanel, dgvThietBi, buttonPanel });
            this.Controls.Add(mainPanel);

            // Xử lý sự kiện
            btnTimKiem.Click += (s, e) =>
            {
                try
                {
                    if (!int.TryParse(txtMaNguoiDung.Text.Trim(), out int maNguoiDung))
                    {
                        MessageBox.Show("Vui lòng nhập mã người dùng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var danhSach = phieuMuonThietBiBUS.GetAllPhieuMuonThietBiByMaNguoiDung(maNguoiDung)
                        .Where(p => p.TrangThai == "Đã đặt").ToList();

                    if (danhSach == null || danhSach.Count == 0)
                    {
                        MessageBox.Show("Không có thiết bị nào đã đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvThietBi.DataSource = danhSach;
                    dgvThietBi.Columns["Chon"].DisplayIndex = 0;
                    dgvThietBi.Columns["MaPhieuMuonThietBi"].HeaderText = "Mã phiếu mượn";
                    dgvThietBi.Columns["MaThietBi"].HeaderText = "Mã thiết bị";
                    dgvThietBi.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
                    dgvThietBi.Columns["ThoiGianMuon"].HeaderText = "Thời gian mượn";
                    dgvThietBi.Columns["ThoiGianTra"].HeaderText = "Thời gian trả";
                    dgvThietBi.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvThietBi.Columns["TongTien"].HeaderText = "Tổng tiền";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnChonTatCa.Click += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvThietBi.Rows)
                    row.Cells["Chon"].Value = true;
            };

            btnXacNhan.Click += (s, e) =>
            {
                try
                {
                    List<int> phieuMuonChon = new List<int>();
                    foreach (DataGridViewRow row in dgvThietBi.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                        {
                            int maPhieuMuonThietBi = Convert.ToInt32(row.Cells["MaPhieuMuonThietBi"].Value);
                            phieuMuonChon.Add(maPhieuMuonThietBi);
                        }
                    }

                    if (phieuMuonChon.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa chọn thiết bị nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool updateSuccess = true;
                    foreach (var maPhieuMuonThietBi in phieuMuonChon)
                    {
                        try
                        {
                            phieuMuonThietBiBUS.UpdateTrangThaiVaThoiGian(maPhieuMuonThietBi, "Đang mượn");
                        }
                        catch (Exception ex)
                        {
                            updateSuccess = false;
                            MessageBox.Show($"Lỗi khi cập nhật phiếu mượn {maPhieuMuonThietBi}: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (updateSuccess)
                    {
                        MessageBox.Show($"Đã chuyển trạng thái {phieuMuonChon.Count} thiết bị thành 'Đang mượn'!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnHuy.Click += (s, e) => this.Close();
        }
    }
} 