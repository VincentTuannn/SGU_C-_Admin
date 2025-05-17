using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("nguoidung")] 
    public class NguoiDungModel
    {
        [Key]
        public int MaNguoiDung { get; set; }
        
        public int MaQuyen { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string MatKhau { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        public string HoVaTen { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string DiaChi { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        [RegularExpression("Nam|Nữ", ErrorMessage = "Giới tính phải là 'Nam' hoặc 'Nữ'")]
        public string GioiTinh { get; set; } = "Nam";
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có đúng 10 chữ số")]
        public string SoDienThoai { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [RegularExpression("Hoạt động|Không hoạt động", ErrorMessage = "Trạng thái phải là 'Hoạt động' hoặc 'Không hoạt động'")]
        public string TrangThai { get; set; } = "Hoạt động";

    }
}
