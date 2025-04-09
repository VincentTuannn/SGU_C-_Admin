using SGU_C__User.BUS;
using SGU_C__User.DAO;

namespace SGU_C__User
{
    public partial class TrangChu_Admin : Form
    {
        private Label numberLabelThietBi;
        private ThietBiBUS thietBiBUS = new ThietBiBUS();
        public TrangChu_Admin()
        {
            InitializeComponent();

            //Tạo tiêu đề cho header
            Label headerLabelThietBi = new Label
            {
                Text = "Tổng số thiết bị được mượn",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(panel4.Width, 30),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            //Tạo tiêu đề cho số lượng
            numberLabelThietBi = new Label
            {
                Font = new Font("Arial", 36, FontStyle.Bold),
                Size = new Size(panel4.Width, 50),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel4.Controls.Add(headerLabelThietBi);
            panel4.Controls.Add(numberLabelThietBi);

            CountSoLuong();

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

    }
}
