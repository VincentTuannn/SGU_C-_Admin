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
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace SGU_C__User.GUI
{
    public partial class ThongKe : Form
    {
        private ThietBiBUS thietBiBus = new ThietBiBUS();
        private PhongBUS PhongBUS = new PhongBUS();
        private CheckInBUS checkInBUS = new CheckInBUS();
        public ThongKe()
        {
            InitializeComponent();
            LoadChartData();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            TrangChu_Admin mainForm = new TrangChu_Admin();
            mainForm.Show();
            this.Close();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void LoadChartData()
        {
            try
            {
                // Khởi tạo chart
                Chart chart = new Chart();
                chart.Dock = DockStyle.Bottom;
                //chart.Size = new Size(280, 100); // Chỉnh kích thước bảng
                //chart.Location = new Point(58, 115); // Chỉnh vị trí bảng
                panel2.Controls.Add(chart);

                // Tạo ChartArea
                ChartArea chartArea = new ChartArea("ChartArea");
                chart.ChartAreas.Add(chartArea);

                // Tạo Series (dữ liệu trên chart)
                Series series = new Series("ThongKeMuon");
                series.ChartType = SeriesChartType.Column; // Sử dụng biểu đồ cột
                chart.Series.Add(series);

                // Lấy dữ liệu từ DAO
                int soPhongMuon = PhongBUS.CountPhongMuon();
                int soThietBiMuon = thietBiBus.CountSoLuong();
                int soCheckIn = checkInBUS.GetCheckInCountsByDate();

                // Thêm dữ liệu vào Series
                series.Points.AddXY("Phòng mượn", soPhongMuon);
                series.Points.AddXY("Thiết bị mượn", soThietBiMuon);
                series.Points.AddXY("Số lượng thành viên vào khu vực học tập", soCheckIn);

                // Đặt tiêu đề cho chart
                chart.Titles.Add("Thống kê số lượng mượn phòng và thiết bị");

                // Tùy chỉnh hiển thị (tùy chọn)
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                series.Points[0].Color = System.Drawing.Color.Blue; // Màu cho "Phòng mượn"
                series.Points[1].Color = System.Drawing.Color.Green; // Màu cho "Thiết bị mượn"
                series.Points[2].Color = System.Drawing.Color.Red; // Màu cho "Số lượng thành viên vào khu học tập"
                chart.ChartAreas[0].AxisX.Title = "Danh mục thống kê";
                chart.ChartAreas[0].AxisY.Title = "Số lượng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chart: " + ex.Message);
            }
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
