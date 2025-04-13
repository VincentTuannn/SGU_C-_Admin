using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SGU_C__User.BUS;
using SGU_C__User.DTO;

namespace SGU_C__User.GUI
{
    public partial class QuanLyTaiKhoan : Form
    {
        private Panel panelContainer;
        private Label lblTitle;
        private DataGridView dgvAccounts;
        private Button btnAdd, btnEdit, btnDelete, btnBack;
        private TextBox txtSearch;
        private NguoiDungBUS nguoiDungBUS;

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            nguoiDungBUS = new NguoiDungBUS();
            InitializeAccountManagementForm();
            LoadUsers();
        }

        private void InitializeAccountManagementForm()
        {
            this.Size = new Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tài Khoản";
            this.BackColor = Color.FromArgb(245, 248, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            panelContainer = new Panel
            {
                Size = new Size(900, 650),
                Location = new Point(50, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Anchor = AnchorStyles.None
            };
            panelContainer.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelContainer.ClientRectangle,
                    Color.FromArgb(230, 230, 230), ButtonBorderStyle.Solid);
            };
            this.Controls.Add(panelContainer);

            btnBack = new Button
            {
                Text = "✕",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(15, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.FromArgb(100, 100, 100)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.FromArgb(220, 220, 220);
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(240, 240, 240);
            btnBack.Click += (s, e) => this.Close();
            panelContainer.Controls.Add(btnBack);

            lblTitle = new Label
            {
                Text = "Quản Lý Tài Khoản",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(70, 50),
                ForeColor = Color.FromArgb(20, 140, 255)
            };
            panelContainer.Controls.Add(lblTitle);

            txtSearch = new TextBox
            {
                Location = new Point(70, 130),
                Width = 500,
                Height = 50,
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(150, 150, 150),
                Text = "Tìm kiếm theo tên hoặc email...",
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(15, 8, 15, 8)
            };
            Panel searchBorder = new Panel
            {
                Size = new Size(500, 2),
                Location = new Point(70, 180),
                BackColor = Color.FromArgb(200, 200, 200)
            };
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Tìm kiếm theo tên hoặc email...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.FromArgb(50, 50, 50);
                }
                searchBorder.BackColor = Color.FromArgb(20, 140, 255);
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Tìm kiếm theo tên hoặc email...";
                    txtSearch.ForeColor = Color.FromArgb(150, 150, 150);
                }
                searchBorder.BackColor = Color.FromArgb(200, 200, 200);
            };
            txtSearch.TextChanged += (s, e) => FilterAccounts();
            panelContainer.Controls.Add(searchBorder);
            panelContainer.Controls.Add(txtSearch);

            dgvAccounts = new DataGridView
            {
                Location = new Point(70, 210),
                Size = new Size(760, 310),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 12),
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dgvAccounts.Columns.Add("MaNguoiDung", "Mã Người Dùng");
            dgvAccounts.Columns.Add("HoVaTen", "Họ và Tên");
            dgvAccounts.Columns.Add("Email", "Email");
            dgvAccounts.Columns.Add("SoDienThoai", "Số Điện Thoại");
            dgvAccounts.Columns.Add("DiaChi", "Địa Chỉ");
            dgvAccounts.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvAccounts.Columns.Add("GioiTinh", "Giới Tính");
            dgvAccounts.Columns.Add("TrangThai", "Trạng Thái");
            panelContainer.Controls.Add(dgvAccounts);

            int btnWidth = 180;
            int btnHeight = 50;
            int btnY = 540;

            btnAdd = CreateButton("Thêm", 70, btnY, btnWidth, btnHeight);
            btnAdd.Click += BtnAdd_Click;
            btnEdit = CreateButton("Sửa", 280, btnY, btnWidth, btnHeight);
            btnEdit.Click += BtnEdit_Click;
            btnDelete = CreateButton("Xóa", 490, btnY, btnWidth, btnHeight);
            btnDelete.Click += BtnDelete_Click;

            // Thêm nút "Quay Lại"
            Button btnReturn = CreateButton("Quay Lại", 700, btnY, btnWidth, btnHeight);
            btnReturn.Click += BtnReturn_Click;

            panelContainer.Controls.Add(btnAdd);
            panelContainer.Controls.Add(btnEdit);
            panelContainer.Controls.Add(btnDelete);
            panelContainer.Controls.Add(btnReturn);
        }

        private Button CreateButton(string text, int x, int y, int width, int height)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.FromArgb(20, 140, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(10, 120, 235);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(20, 140, 255);
            return btn;
        }

        private void LoadUsers()
        {
            try
            {
                var users = nguoiDungBUS.GetAllNguoiDung();
                RefreshGrid(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid(List<NguoiDungDTO> users)
        {
            dgvAccounts.Rows.Clear();
            foreach (var user in users)
            {
                dgvAccounts.Rows.Add(
                    user.MaNguoiDung,
                    user.HoVaTen,
                    user.Email,
                    user.SoDienThoai,
                    user.DiaChi,
                    user.NgaySinh.ToShortDateString(),
                    user.GioiTinh,
                    user.TrangThai
                );
            }
        }

        private void FilterAccounts()
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                if (searchText == "tìm kiếm theo tên hoặc email...") searchText = "";
                var users = nguoiDungBUS.GetAllNguoiDung();
                var filtered = users.Where(u =>
                    u.HoVaTen.ToLower().Contains(searchText) ||
                    u.Email.ToLower().Contains(searchText)).ToList();
                RefreshGrid(filtered);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var registerForm = new Form1();
                if (registerForm.ShowDialog() == DialogResult.OK && registerForm.NguoiDungData != null)
                {
                    nguoiDungBUS.AddNguoiDung(registerForm.NguoiDungData);
                    LoadUsers();
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccounts.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvAccounts.SelectedRows[0];
                    int maNguoiDung = Convert.ToInt32(selectedRow.Cells["MaNguoiDung"].Value);
                    var users = nguoiDungBUS.GetAllNguoiDung();
                    var user = users.FirstOrDefault(u => u.MaNguoiDung == maNguoiDung);
                    if (user != null)
                    {
                        var registerForm = new Form1(user);
                        if (registerForm.ShowDialog() == DialogResult.OK && registerForm.NguoiDungData != null)
                        {
                            nguoiDungBUS.UpdateNguoiDung(registerForm.NguoiDungData);
                            LoadUsers();
                            MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccounts.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvAccounts.SelectedRows[0];
                    int maNguoiDung = Convert.ToInt32(selectedRow.Cells["MaNguoiDung"].Value);
                    string email = selectedRow.Cells["Email"].Value.ToString();
                    if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {email}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nguoiDungBUS.DeleteNguoiDung(maNguoiDung);
                        LoadUsers();
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }
    }
}