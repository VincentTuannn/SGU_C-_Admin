using SGU_C__User.BUS;
using SGU_C__User.DAO;
using SGU_C__User.GUI;

namespace SGU_C__User
{
    public partial class TrangChu_Admin : Form
    {
        private Label numberLabelThietBi;
        private Label numberLabelViPham;
        private Label numberLabelDatPhong;
        private ThietBiBUS thietBiBUS = new ThietBiBUS();
        private ViPhamBUS viPhamBUS = new ViPhamBUS();
        private PhongBUS phongBUS = new PhongBUS();
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        public TrangChu_Admin()
        {
            InitializeComponent();

            //Tạo tiêu đề cho header thiết bị đang sử dụng
            Label headerLabelThietBi = new Label
            {
                Text = "Tổng số thiết bị được mượn",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(panel4.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho số lượng thiết bị đang sử dụng
            numberLabelThietBi = new Label
            {
                Font = new Font("Arial", 36, FontStyle.Bold),
                Size = new Size(panel4.Width, 50),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho header tổng số vi phạm
            Label headerLabelViPham = new Label
            {
                Text = "Tổng số vi phạm",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(panel4.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho tổng số vi phạm
            numberLabelViPham = new Label
            {
                Font = new Font("Arial", 36, FontStyle.Bold),
                Size = new Size(panel4.Width, 50),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho header thông tin check-in/checkout
            Label headerCheckIn = new Label
            {
                Text = "Quản lý check-in/checkout",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(panel4.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho header số lượt đặt chỗ hôm nay
            Label headerDatPhong = new Label
            {
                Text = "Số lượt đặt chỗ hôm nay",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(panel4.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho số lượng đặt phòng
            numberLabelDatPhong = new Label
            {
                Font = new Font("Arial", 36, FontStyle.Bold),
                Size = new Size(panel4.Width, 50),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel4.Controls.Add(headerLabelThietBi);
            panel4.Controls.Add(numberLabelThietBi);
            panel7.Controls.Add(headerLabelViPham);
            panel7.Controls.Add(numberLabelViPham);
            panel5.Controls.Add(headerCheckIn);
            panel6.Controls.Add(headerDatPhong);
            panel6.Controls.Add(numberLabelDatPhong);

            CountSoLuong();
            CountViPham();
            CountPhongMuon();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLThietBi deviceManagementForm = new QLThietBi();
            deviceManagementForm.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại
        }

        private void button7_Click(object sender, EventArgs e)
        {
            QLViPham violationManagementForm = new QLViPham();
            violationManagementForm.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 0, 0, panel4.Width - 1, panel4.Height - 1);
            }
        }

        // Phương thức cập nhật số lượng thiết bị trên giao diện
        private void CountSoLuong()
        {
            try
            {
                int deviceCount = thietBiBUS.CountSoLuong();
                numberLabelThietBi.Text = deviceCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberLabelThietBi.Text = "0";
            }
        }

        private void CountPhongMuon()
        {
            try
            {
                int roomCount = phongBUS.CountPhongMuon();
                numberLabelDatPhong.Text = roomCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberLabelDatPhong.Text = "0";
            }
        }

        private void CountViPham()
        {
            try
            {
                int violationCount = viPhamBUS.CountViPham();
                numberLabelViPham.Text = violationCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberLabelViPham.Text = "0";
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 0, 0, panel4.Width - 1, panel4.Height - 1);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 0, 0, panel4.Width - 1, panel4.Height - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLTaiKhoan accountManagementForm = new QLTaiKhoan();
            accountManagementForm.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại
        }
    }
}
