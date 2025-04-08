namespace SGU_C__User
{
    public partial class TrangChu_Admin : Form
    {
        public TrangChu_Admin()
        {
            InitializeComponent();
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
    }
}
