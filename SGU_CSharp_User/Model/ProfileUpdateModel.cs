using System.ComponentModel.DataAnnotations;

namespace SGU_CSharp_User.Model
{
    public class ProfileUpdateModel
    {
        public int MaNguoiDung { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;
        
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
        [Required(ErrorMessage = "Mật khẩu mới là bắt buộc")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} ký tự", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "Mật khẩu phải có ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 chữ số và 1 ký tự đặc biệt")]
        public string? NewPassword { get; set; }
        
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Mật khẩu cũ là bắt buộc")]

        public string? CurrentPassword { get; set; }
    }
}
