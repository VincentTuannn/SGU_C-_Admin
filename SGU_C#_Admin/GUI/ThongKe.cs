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
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
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
                int soLuongUserLocked = nguoiDungBUS.CountUserLocked();
                int soLuongUserUnlocked = nguoiDungBUS.CountUserUnlocked();

                // Thêm dữ liệu vào Series
                series.Points.AddXY("Phòng mượn", soPhongMuon);
                series.Points.AddXY("Thiết bị mượn", soThietBiMuon);
                series.Points.AddXY("Số lượng thành viên vào khu vực học tập", soCheckIn);
                series.Points.AddXY("Người dùng đang hoạt động", soLuongUserUnlocked);
                series.Points.AddXY("Người dùng không hoạt động", soLuongUserLocked);

                // Đặt tiêu đề cho chart
                chart.Titles.Add("Thống kê số lượng");

                // Tùy chỉnh hiển thị (tùy chọn)
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                series.Points[0].Color = System.Drawing.Color.Blue; // Màu cho "Phòng mượn"
                series.Points[1].Color = System.Drawing.Color.Yellow; // Màu cho "Thiết bị mượn"
                series.Points[2].Color = System.Drawing.Color.Purple; // Màu cho "Số lượng thành viên vào khu học tập"
                series.Points[3].Color = System.Drawing.Color.Green; // Màu cho "Người dùng đang hoạt động"
                series.Points[4].Color = System.Drawing.Color.Red; // Màu cho "Người dùng không hoạt động"
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

        private void button_filter_Click(object sender, EventArgs e)
        {
            LoadChartDataByDate(dateTimePicker1.Value);
        }

        private void LoadChartDataByDate(DateTime selectedDate)
        {
            try
            {
                // Xóa chart cũ nếu có
                panel2.Controls.Clear();

                // Khởi tạo chart mới
                Chart chart = new Chart();
                chart.Dock = DockStyle.Bottom;
                panel2.Controls.Add(chart);

                // Tạo ChartArea
                ChartArea chartArea = new ChartArea("ChartArea");
                chart.ChartAreas.Add(chartArea);

                // Tạo Series (dữ liệu trên chart)
                Series series = new Series("ThongKeMuon");
                series.ChartType = SeriesChartType.Column;
                chart.Series.Add(series);

                // Lấy dữ liệu từ DAO theo ngày được chọn
                int soPhongMuon = PhongBUS.CountPhongMuonByDate(selectedDate);
                int soThietBiMuon = thietBiBus.CountSoLuongByDate(selectedDate);
                int soCheckIn = checkInBUS.GetCheckInCountsByDates(selectedDate);
                int soLuongUserLocked = nguoiDungBUS.CountUserLocked();
                int soLuongUserUnlocked = nguoiDungBUS.CountUserUnlocked();

                // Thêm dữ liệu vào Series
                series.Points.AddXY("Phòng mượn", soPhongMuon);
                series.Points.AddXY("Thiết bị mượn", soThietBiMuon);
                series.Points.AddXY("Số lượng thành viên vào khu vực học tập", soCheckIn);
                series.Points.AddXY("Người dùng đang hoạt động", soLuongUserUnlocked);
                series.Points.AddXY("Người dùng không hoạt động", soLuongUserLocked);

                // Đặt tiêu đề cho chart
                chart.Titles.Clear();
                chart.Titles.Add($"Thống kê số lượng ngày {selectedDate.ToString("dd/MM/yyyy")}");

                // Tùy chỉnh hiển thị
                series.IsValueShownAsLabel = true;
                series.Points[0].Color = System.Drawing.Color.Blue;
                series.Points[1].Color = System.Drawing.Color.Yellow;
                series.Points[2].Color = System.Drawing.Color.Purple;
                series.Points[3].Color = System.Drawing.Color.Green;
                series.Points[4].Color = System.Drawing.Color.Red;
                chart.ChartAreas[0].AxisX.Title = "Danh mục thống kê";
                chart.ChartAreas[0].AxisY.Title = "Số lượng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chart theo ngày: " + ex.Message);
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa chart cũ nếu có
                panel2.Controls.Clear();

                // Gọi lại hàm load dữ liệu tổng quát (không lọc ngày)
                LoadChartData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset dữ liệu chart: " + ex.Message);
            }
        }
    }
}
