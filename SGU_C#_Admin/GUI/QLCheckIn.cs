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
    public partial class QLCheckIn : Form
    {
        CheckInBUS checkInBUS = new CheckInBUS();
        private DateTimePicker datePickerCheckIn;
        private Label lblSearchByDate;
        private Button btnReset;
        private Button btnCheckout;
        private Panel panelSearch;

        public QLCheckIn()
        {
            InitializeComponent();
            LoadDataToGridView();
            // Đưa label tiêu đề lên gần nút Quay lại
            label2.Location = new Point(30, 20);
            label2.BringToFront();
            // Tạo panelSearch chứa các control tìm kiếm và nút
            panelSearch = new Panel();
            panelSearch.Size = new Size(900, 40);
            panelSearch.Location = new Point(30, 60);
            // Thêm các control vào panelSearch
            lblSearchByDate = new Label();
            lblSearchByDate.Text = "Tìm kiếm theo ngày:";
            lblSearchByDate.Location = new Point(0, 10);
            lblSearchByDate.AutoSize = true;
            panelSearch.Controls.Add(lblSearchByDate);
            datePickerCheckIn = new DateTimePicker();
            datePickerCheckIn.Format = DateTimePickerFormat.Custom;
            datePickerCheckIn.CustomFormat = "dd-MM-yyyy";
            datePickerCheckIn.Location = new Point(120, 7);
            datePickerCheckIn.Width = 120;
            datePickerCheckIn.ValueChanged += DatePickerCheckIn_ValueChanged;
            panelSearch.Controls.Add(datePickerCheckIn);
            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Location = new Point(250, 7);
            btnReset.Size = new Size(70, 27);
            btnReset.Click += BtnReset_Click;
            panelSearch.Controls.Add(btnReset);
            Input_Search.Location = new Point(340, 7);
            Input_Search.Width = 188;
            panelSearch.Controls.Add(Input_Search);
            btnCheckIn.Location = new Point(540, 7);
            btnCheckIn.Size = new Size(100, 27);
            panelSearch.Controls.Add(btnCheckIn);
            btnCheckout = new Button();
            btnCheckout.Text = "Checkout";
            btnCheckout.Location = new Point(650, 7);
            btnCheckout.Size = new Size(100, 27);
            btnCheckout.Click += btnCheckout_Click;
            panelSearch.Controls.Add(btnCheckout);
            // Thêm panelSearch vào panel2
            panel2.Controls.Add(panelSearch);
            // Đặt DataGridView ngay dưới panelSearch
            dataGridView1.Location = new Point(30, 110);
            dataGridView1.Size = new Size(panel2.Width - 60, panel2.Height - 130);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }

        private void LoadDataToGridView()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var danhSach = checkInBUS.GetAllCheckIn();
                // Lấy danh sách người dùng để map tên
                var nguoiDungDAO = new DAO.NguoiDungDAO();
                var allNguoiDung = nguoiDungDAO.GetAllNguoiDung();
                // Tạo danh sách mới có thêm tên người dùng
                var data = danhSach.Select(c => new {
                    c.MaCheckin,
                    TenNguoiDung = allNguoiDung.FirstOrDefault(u => u.MaNguoiDung == c.MaNguoiDung)?.HoVaTen ?? "",
                    c.ThoiGianVao,
                    c.ThoiGianRa,
                    c.TrangThai
                }).ToList();
                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = data;
                // Tùy chỉnh tiêu đề cột
                dataGridView1.Columns["MaCheckin"].HeaderText = "Mã checkin";
                dataGridView1.Columns["TenNguoiDung"].HeaderText = "Tên người dùng";
                dataGridView1.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                dataGridView1.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                // Căn chỉnh độ rộng các cột để lấp đầy DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["MaCheckin"].FillWeight = 15;
                dataGridView1.Columns["TenNguoiDung"].FillWeight = 25;
                dataGridView1.Columns["ThoiGianVao"].FillWeight = 25;
                dataGridView1.Columns["ThoiGianRa"].FillWeight = 25;
                dataGridView1.Columns["TrangThai"].FillWeight = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Input_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                    var danhSach = checkInBUS.GetAllCheckInByMaNguoiDung(maNguoiDung);
                    var nguoiDungDAO = new DAO.NguoiDungDAO();
                    var allNguoiDung = nguoiDungDAO.GetAllNguoiDung();
                    var data = danhSach.Select(c => new {
                        c.MaCheckin,
                        TenNguoiDung = allNguoiDung.FirstOrDefault(u => u.MaNguoiDung == c.MaNguoiDung)?.HoVaTen ?? "",
                        c.ThoiGianVao,
                        c.ThoiGianRa,
                        c.TrangThai
                    }).ToList();
                    dataGridView1.DataSource = data;
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    dataGridView1.Columns["MaCheckin"].HeaderText = "Mã checkin";
                    dataGridView1.Columns["TenNguoiDung"].HeaderText = "Tên người dùng";
                    dataGridView1.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                    dataGridView1.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
                    dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns["MaCheckin"].FillWeight = 15;
                    dataGridView1.Columns["TenNguoiDung"].FillWeight = 25;
                    dataGridView1.Columns["ThoiGianVao"].FillWeight = 25;
                    dataGridView1.Columns["ThoiGianRa"].FillWeight = 25;
                    dataGridView1.Columns["TrangThai"].FillWeight = 10;
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

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã người dùng:", "Check-in", "");
            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không hợp lệ!");
                return;
            }

            // Kiểm tra mã người dùng
            var nguoiDungDAO = new DAO.NguoiDungDAO();
            if (!nguoiDungDAO.IsExist(maNguoiDung))
            {
                MessageBox.Show("Không phải thành viên!");
                return;
            }

            // Kiểm tra vi phạm
            var viPhamDAO = new DAO.ViPhamDAO();
            if (viPhamDAO.IsViPham(maNguoiDung))
            {
                MessageBox.Show("Tài khoản đã vi phạm nên không được vào!");
                return;
            }

            // Kiểm tra đã check-in mà chưa checkout
            var checkInDAO = new DAO.CheckInDAO();
            var checkIns = checkInDAO.GetAllCheckInByMaNguoiDung(maNguoiDung);
            bool daCheckInChuaCheckout = checkIns.Any(c => c.TrangThai == "Checked In" && c.ThoiGianRa == null);
            if (daCheckInChuaCheckout)
            {
                MessageBox.Show("Người dùng này đã check-in và chưa checkout!");
                return;
            }

            // Lưu check-in
            checkInDAO.AddCheckIn(maNguoiDung);
            var nguoiDung = nguoiDungDAO.GetAllNguoiDungByID(maNguoiDung).FirstOrDefault();
            string tenNguoiDung = nguoiDung != null ? nguoiDung.HoVaTen : "";
            string thoiGianCheckIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            MessageBox.Show($"Check-in thành công!\nTên: {tenNguoiDung}\nThời gian: {thoiGianCheckIn}", "Thông báo");
            LoadDataToGridView();
        }

        private void DatePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = datePickerCheckIn.Value.Date;
            var danhSach = checkInBUS.GetAllCheckInByDate(selectedDate);
            var nguoiDungDAO = new DAO.NguoiDungDAO();
            var allNguoiDung = nguoiDungDAO.GetAllNguoiDung();
            var data = danhSach.Select(c => new {
                c.MaCheckin,
                TenNguoiDung = allNguoiDung.FirstOrDefault(u => u.MaNguoiDung == c.MaNguoiDung)?.HoVaTen ?? "",
                c.ThoiGianVao,
                c.ThoiGianRa,
                c.TrangThai
            }).ToList();
            dataGridView1.DataSource = data;
            dataGridView1.Columns["MaCheckin"].HeaderText = "Mã checkin";
            dataGridView1.Columns["TenNguoiDung"].HeaderText = "Tên người dùng";
            dataGridView1.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
            dataGridView1.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
            dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["MaCheckin"].FillWeight = 15;
            dataGridView1.Columns["TenNguoiDung"].FillWeight = 25;
            dataGridView1.Columns["ThoiGianVao"].FillWeight = 25;
            dataGridView1.Columns["ThoiGianRa"].FillWeight = 25;
            dataGridView1.Columns["TrangThai"].FillWeight = 10;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã người dùng:", "Checkout", "");
            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không hợp lệ!");
                return;
            }

            var checkInDAO = new DAO.CheckInDAO();
            var checkIns = checkInDAO.GetAllCheckInByMaNguoiDung(maNguoiDung);
            var checkInChuaCheckout = checkIns.FirstOrDefault(c => c.TrangThai == "Checked In" && c.ThoiGianRa == null);
            if (checkInChuaCheckout == null)
            {
                MessageBox.Show("Không tìm thấy bản ghi check-in chưa checkout cho người dùng này!");
                return;
            }

            // Cập nhật thời gian ra và trạng thái
            checkInChuaCheckout.ThoiGianRa = DateTime.Now;
            checkInChuaCheckout.TrangThai = "Checked Out";
            checkInDAO.UpdateCheckIn(checkInChuaCheckout);

            // Lấy tên người dùng
            var nguoiDungDAO = new DAO.NguoiDungDAO();
            var nguoiDung = nguoiDungDAO.GetAllNguoiDungByID(maNguoiDung).FirstOrDefault();
            string tenNguoiDung = nguoiDung != null ? nguoiDung.HoVaTen : "";
            string thoiGianCheckout = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            MessageBox.Show($"Checkout thành công!\nTên: {tenNguoiDung}\nThời gian: {thoiGianCheckout}", "Thông báo");
            LoadDataToGridView();
        }
    }
}
