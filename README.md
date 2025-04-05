# Quản lý thư quán 

Dự án này là một ứng dụng quản lý thư quán, tập trung vào chức năng mượn phòng và thiết bị. Người dùng có thể dễ dàng quản lý việc đặt phòng, mượn trả thiết bị và theo dõi lịch sử mượn trả.

## Chức năng chính

* **Quản lý phòng:**
    * Xem danh sách phòng trống/đang sử dụng.
    * Đặt phòng theo thời gian.
    * Xem lịch sử đặt phòng.
* **Quản lý thiết bị:**
    * Xem danh sách thiết bị có sẵn.
    * Mượn/trả thiết bị.
    * Theo dõi tình trạng thiết bị.
    * Xem lịch sử mượn trả thiết bị.
* **Quản lý người dùng:**
    * Đăng ký/đăng nhập.
    * Xem thông tin cá nhân.
    * Xem lịch sử mượn phòng và thiết bị.
* **Báo cáo:**
    * Thống kê số lượng phòng đã đặt.
    * Thống kê số lượng thiết bị đã mượn.
    * Báo cáo vi phạm (nếu có).

## Yêu cầu hệ thống

* Hệ điều hành: Windows (khuyến nghị)
* Phần mềm:
    * Git (để clone dự án)
    * SQL Server Management Studio (SSMS)
    * SQL Server Express

## Cài đặt

1. **Clone dự án:**

   Mở terminal hoặc Git Bash và chạy lệnh sau để clone dự án từ GitHub
   
   git clone https://github.com/VincentTuannn/SGU_C-_Admin.git

   Tải SQL Server 2022 Express
   
   https://www.microsoft.com/en-us/sql-server/sql-server-downloads?msockid=0f2f2017e2a5675637463505e3b766c3

   Tải SQL Server Management Studio (SSMS)
   
   https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms
   
## Kết nối cơ sở dữ liệu
* Vào mục Tools trên thanh menu
* Chọn Connect to Database
* Ở phần Data source chọn Microsoft SQL Server
* Ở thanh Server name chọn tên Server của bạn 
* Dưới thanh Select or enter a database name chọn quanlythuquan (Đã tạo trong SSMS)
* Nhấn nút Test Connection ở góc trái bên dưới để kiểm tra kết nối
* Nhấn nút Advanced để mở trang Advanced Properties
* Tại đây ở cuối trang sẽ có địa chỉ connectionString // VD: "Data Source=DESKTOP-LGO8DG6\SQLEXPRESS;Initial Catalog=quanlythuquan;Integrated Security=True;Trust Server Certificate=True"
* Chuyển về trang Add Connection rồi nhấn OK để kết nối cơ sở dữ liệu
* Kiểm tra các file DAO dòng connectionString đổi lại theo địa chỉ đã lấy trong Advanced Properties
* Chạy project để kiểm tra kết nối cơ sở dữ liệu
