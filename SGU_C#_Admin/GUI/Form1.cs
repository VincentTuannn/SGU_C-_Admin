using System;
using System.Drawing;
using System.Windows.Forms;
using SGU_C__User.DTO;

namespace SGU_C__User.GUI
{
    public partial class Form1 : Form
    {
        private Label lblTitle;
        private TextBox txtName, txtAddress, txtEmail, txtPassword, txtPhone;
        private DateTimePicker dtpDob;
        private ComboBox cbGender, cbTrangThai, cbQuyen;
        private Button btnRegister, btnBack;
        private Panel panelContainer;
        public NguoiDungDTO NguoiDungData { get; private set; }
        private bool isEditMode;
        private NguoiDungDTO existingUser;

        public Form1(NguoiDungDTO user = null)
        {
            InitializeComponent();
            InitializeRegisterForm();
            if (user != null)
            {
                isEditMode = true;
                existingUser = user;
                LoadUserData(user);
            }
        }

        private void InitializeRegisterForm()
        {
            this.Size = new Size(600, 900);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.BackColor = Color.FromArgb(245, 248, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            panelContainer = new Panel
            {
                Size = new Size(500, 830),
                Location = new Point(50, 30),
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

            int startX = 60;
            int startY = 50;
            int fieldWidth = 380;
            int gapY = 70;

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
                Text = isEditMode ? "Sửa Tài Khoản" : "Đăng Ký Tài Khoản",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(startX, startY),
                ForeColor = Color.FromArgb(20, 140, 255)
            };
            panelContainer.Controls.Add(lblTitle);
            startY += 90;

            txtName = CreateTextBox("Họ và tên", startX, startY);
            startY += gapY;
            txtAddress = CreateTextBox("Địa chỉ", startX, startY);
            startY += gapY;
            txtEmail = CreateTextBox("Email", startX, startY);
            startY += gapY;
            txtPassword = CreateTextBox("Mật khẩu", startX, startY, true);
            startY += gapY;
            txtPhone = CreateTextBox("Số điện thoại", startX, startY);
            startY += gapY;

            dtpDob = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(startX, startY),
                Width = fieldWidth,
                Font = new Font("Segoe UI", 14),
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            panelContainer.Controls.Add(dtpDob);
            startY += gapY;

            Label lblGender = new Label
            {
                Text = "Giới tính",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(startX, startY - 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            panelContainer.Controls.Add(lblGender);

            cbGender = new ComboBox
            {
                Location = new Point(startX, startY),
                Width = fieldWidth,
                Font = new Font("Segoe UI", 14),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            cbGender.Items.AddRange(new string[] { "Nam", "Nữ" });
            panelContainer.Controls.Add(cbGender);
            startY += gapY;

            Label lblTrangThai = new Label
            {
                Text = "Trạng thái",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(startX, startY - 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            panelContainer.Controls.Add(lblTrangThai);

            cbTrangThai = new ComboBox
            {
                Location = new Point(startX, startY),
                Width = fieldWidth,
                Font = new Font("Segoe UI", 14),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            cbTrangThai.Items.AddRange(new string[] { "Hoạt động", "Không hoạt động" });
            cbTrangThai.SelectedIndex = 0;
            panelContainer.Controls.Add(cbTrangThai);
            startY += gapY;

            Label lblQuyen = new Label
            {
                Text = "Quyền",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(startX, startY - 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            panelContainer.Controls.Add(lblQuyen);

            cbQuyen = new ComboBox
            {
                Location = new Point(startX, startY),
                Width = fieldWidth,
                Font = new Font("Segoe UI", 14),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            cbQuyen.Items.AddRange(new Quyen[]
            {
                new Quyen(1, "Admin"),
                new Quyen(2, "Nhân viên")
            });
            cbQuyen.DisplayMember = "TenQuyen";
            cbQuyen.ValueMember = "MaQuyen";
            cbQuyen.SelectedIndex = 0;
            panelContainer.Controls.Add(cbQuyen);
            startY += gapY + 25;

            btnRegister = new Button
            {
                Text = isEditMode ? "Cập Nhật" : "Đăng Ký",
                Location = new Point(startX, startY),
                Width = fieldWidth,
                Height = 60,
                BackColor = Color.FromArgb(20, 140, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.MouseEnter += (s, e) => btnRegister.BackColor = Color.FromArgb(10, 120, 235);
            btnRegister.MouseLeave += (s, e) => btnRegister.BackColor = Color.FromArgb(20, 140, 255);
            btnRegister.Click += BtnRegister_Click;
            panelContainer.Controls.Add(btnRegister);
        }

        private void LoadUserData(NguoiDungDTO user)
        {
            txtName.Text = user.HoVaTen;
            txtAddress.Text = user.DiaChi;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.SoDienThoai;
            dtpDob.Value = user.NgaySinh;
            cbGender.SelectedItem = user.GioiTinh;
            cbTrangThai.SelectedItem = user.TrangThai;
            txtPassword.Text = user.MatKhau;
            foreach (Quyen item in cbQuyen.Items)
            {
                if (item.MaQuyen == user.MaQuyenThuoc)
                {
                    cbQuyen.SelectedItem = item;
                    break;
                }
            }
            txtName.ForeColor = txtAddress.ForeColor = txtEmail.ForeColor = txtPhone.ForeColor = Color.FromArgb(50, 50, 50);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    NguoiDungData = new NguoiDungDTO
                    {
                        MaNguoiDung = isEditMode ? existingUser.MaNguoiDung : 0,
                        HoVaTen = txtName.Text,
                        DiaChi = txtAddress.Text,
                        Email = txtEmail.Text,
                        MatKhau = txtPassword.Text,
                        SoDienThoai = txtPhone.Text,
                        NgaySinh = dtpDob.Value,
                        GioiTinh = cbGender.SelectedItem?.ToString(),
                        TrangThai = cbTrangThai.SelectedItem?.ToString(),
                        MaQuyenThuoc = Convert.ToInt32(cbQuyen.SelectedValue)
                    };
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "Họ và tên" ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Email" ||
                string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text == "Số điện thoại" ||
                string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "Địa chỉ" ||
                (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Mật khẩu") && !isEditMode ||
                cbGender.SelectedItem == null ||
                cbTrangThai.SelectedItem == null ||
                cbQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private TextBox CreateTextBox(string placeholder, int x, int y, bool isPassword = false)
        {
            TextBox txt = new TextBox
            {
                Location = new Point(x, y),
                Width = 380,
                Height = 50,
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(150, 150, 150),
                Text = placeholder,
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(15, 8, 15, 8)
            };

            Panel bottomBorder = new Panel
            {
                Size = new Size(380, 2),
                Location = new Point(x, y + 48),
                BackColor = Color.FromArgb(200, 200, 200)
            };
            panelContainer.Controls.Add(bottomBorder);
            panelContainer.Controls.Add(txt);

            if (isPassword)
                txt.PasswordChar = '*';

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.FromArgb(50, 50, 50);
                    if (isPassword) txt.PasswordChar = '●';
                }
                bottomBorder.BackColor = Color.FromArgb(20, 140, 255);
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.FromArgb(150, 150, 150);
                    if (isPassword) txt.PasswordChar = '\0';
                }
                bottomBorder.BackColor = Color.FromArgb(200, 200, 200);
            };

            return txt;
        }
    }
}