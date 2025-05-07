using SGU_C__User.BUS;
using SGU_C__User.DAO;
using SGU_C__User.GUI;
using System.Diagnostics;

namespace SGU_C__User
{
    public partial class TrangChu_Admin : Form
    {
        #region Fields
        private readonly Label numberLabelThietBi;
        private readonly Label numberLabelViPham;
        private readonly Label numberLabelDatPhong;
        private readonly ThietBiBUS thietBiBUS;
        private readonly ViPhamBUS viPhamBUS;
        private readonly PhongBUS phongBUS;
        private readonly NguoiDungBUS nguoiDungBUS;
        private readonly System.Windows.Forms.Timer refreshTimer;
        #endregion

        #region Constructor
        public TrangChu_Admin()
        {
            InitializeComponent();
            
            // Khởi tạo các label số với style đúng
            numberLabelThietBi = CreateNumberLabel(panel_ThietBi);
            numberLabelViPham = CreateNumberLabel(panel_ViPham);
            numberLabelDatPhong = CreateNumberLabel(panel_PhongBan);

            thietBiBUS = new ThietBiBUS();
            viPhamBUS = new ViPhamBUS();
            phongBUS = new PhongBUS();
            nguoiDungBUS = new NguoiDungBUS();
            refreshTimer = new System.Windows.Forms.Timer();

            InitializeServices();
            InitializeUI();
            SetupEventHandlers();
            StartAutoRefresh();
        }
        #endregion

        #region Initialization Methods
        private void InitializeServices()
        {
            // Removed assignments to readonly fields here
        }

        private void InitializeUI()
        {
            InitializeDashboardPanels();
            UpdateDashboardCounts();
        }

        private void InitializeDashboardPanels()
        {
            // Initialize ThietBi Panel
            var headerLabelThietBi = CreateHeaderLabel("Tổng số thiết bị được mượn", panel_ThietBi);
            panel_ThietBi.Controls.AddRange(new Control[] { headerLabelThietBi, numberLabelThietBi });

            // Initialize ViPham Panel
            var headerLabelViPham = CreateHeaderLabel("Tổng số vi phạm", panel_ViPham);
            panel_ViPham.Controls.AddRange(new Control[] { headerLabelViPham, numberLabelViPham });

            // Initialize CheckIn Panel
            var headerCheckIn = CreateHeaderLabel("Quản lý check-in/checkout", panel_CheckIn);
            panel_CheckIn.Controls.Add(headerCheckIn);

            // Initialize PhongBan Panel
            var headerDatPhong = CreateHeaderLabel("Số lượt đặt chỗ hôm nay", panel_PhongBan);
            panel_PhongBan.Controls.AddRange(new Control[] { headerDatPhong, numberLabelDatPhong });
        }

        private Label CreateHeaderLabel(string text, Panel parent)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(parent.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Label CreateNumberLabel(Panel parent)
        {
            return new Label
            {
                Font = new Font("Arial", 36, FontStyle.Bold),
                Size = new Size(parent.Width, 50),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void SetupEventHandlers()
        {
            Btn_QLCheckIn.MouseEnter += Btn_QLCheckIn_MouseEnter;
            Btn_QLCheckIn.MouseLeave += Btn_CheckIn_MouseLeave;
        }

        private void StartAutoRefresh()
        {
            refreshTimer.Interval = 30000; // Refresh every 30 seconds
            refreshTimer.Tick += (s, e) => UpdateDashboardCounts();
            refreshTimer.Start();
        }
        #endregion

        #region Dashboard Update Methods
        private void UpdateDashboardCounts()
        {
            try
            {
                UpdateDeviceCount();
                UpdateViolationCount();
                UpdateRoomCount();
            }
            catch (Exception ex)
            {
                LogError("Error updating dashboard counts", ex);
                ShowErrorMessage("Lỗi cập nhật thông tin", ex.Message);
            }
        }

        private void UpdateDeviceCount()
        {
            try
            {
                int deviceCount = thietBiBUS.CountSoLuong();
                numberLabelThietBi.Text = deviceCount.ToString();
            }
            catch (Exception ex)
            {
                LogError("Error counting devices", ex);
                numberLabelThietBi.Text = "0";
            }
        }

        private void UpdateViolationCount()
        {
            try
            {
                int violationCount = viPhamBUS.CountViPham();
                numberLabelViPham.Text = violationCount.ToString();
            }
            catch (Exception ex)
            {
                LogError("Error counting violations", ex);
                numberLabelViPham.Text = "0";
            }
        }

        private void UpdateRoomCount()
        {
            try
            {
                int roomCount = phongBUS.CountPhongMuon();
                numberLabelDatPhong.Text = roomCount.ToString();
            }
            catch (Exception ex)
            {
                LogError("Error counting rooms", ex);
                numberLabelDatPhong.Text = "0";
            }
        }
        #endregion

        #region Event Handlers
        private void Btn_QLThietBi_Click(object sender, EventArgs e)
        {
            OpenForm(new QLThietBi());
        }

        private void Btn_QLViPham_Click(object sender, EventArgs e)
        {
            OpenForm(new QLViPham());
        }

        private void Btn_QLPhongBan_Click(object sender, EventArgs e)
        {
            OpenForm(new QLPhong());
        }

        private void Btn_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenForm(new QLTaiKhoan());
        }

        private void Btn_QLMuonPhong_Click(object sender, EventArgs e)
        {
            OpenForm(new QLMuonPhong());
        }

        private void Btn_QLMuonThietBi_Click(object sender, EventArgs e)
        {
            OpenForm(new QLMuonThietBi());
        }

        private void Btn_QLThanhToan_Click(object sender, EventArgs e)
        {
            OpenForm(new QLThanhToan());
        }

        private void Btn_QLCheckIn_Click(object sender, EventArgs e)
        {
            OpenForm(new QLCheckIn());
        }

        private void Btn_ThongKe_Click(object sender, EventArgs e)
        {
            OpenForm(new ThongKe());
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            if (ConfirmLogout())
            {
                Application.Exit();
            }
        }

        private void Btn_QLCheckIn_MouseEnter(object sender, EventArgs e)
        {
            UpdateButtonAppearance(Btn_QLCheckIn, Color.White, Color.Black);
        }

        private void Btn_CheckIn_MouseLeave(object sender, EventArgs e)
        {
            UpdateButtonAppearance(Btn_QLCheckIn, Color.Blue, Color.White);
        }
        #endregion

        #region Helper Methods
        private void OpenForm(Form form)
        {
            try
            {
                form.Owner = this;
                form.FormClosed += (s, args) => this.Show();
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                LogError($"Error opening form {form.GetType().Name}", ex);
                ShowErrorMessage("Lỗi", "Không thể mở form. Vui lòng thử lại.");
            }
        }

        private void UpdateButtonAppearance(Button button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
        }

        private bool ConfirmLogout()
        {
            return MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void LogError(string message, Exception ex)
        {
            Debug.WriteLine($"{message}: {ex.Message}");
            // TODO: Implement proper logging
        }

        private void ShowErrorMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Panel Paint Events
        private void panel_ThietBi_Paint(object sender, PaintEventArgs e)
        {
            DrawDashedBorder(e.Graphics, panel_ThietBi);
        }

        private void panel_ViPham_Paint(object sender, PaintEventArgs e)
        {
            DrawDashedBorder(e.Graphics, panel_ViPham);
        }

        private void panel_CheckIn_Paint(object sender, PaintEventArgs e)
        {
            DrawDashedBorder(e.Graphics, panel_CheckIn);
        }

        private void DrawDashedBorder(Graphics g, Panel panel)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }
        #endregion

        // Add this method to handle the Load event
        private void TrangChu_Admin_Load(object sender, EventArgs e)
        {
            // Optionally, you can call initialization logic here if needed
            // For now, do nothing or add any logic you want to run on form load
        }
    }
}
