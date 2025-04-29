using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("checkin")]
    public class CheckInModel
    {
        [Key]
        public int MaCheckIn { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "Thời gian vào là bắt buộc")]
        public DateTime ThoiGianVao { get; set; }

        [Required(ErrorMessage = "Thời gian ra là bắt buộc")]
        public DateTime ThoiGianRa { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [RegularExpression("Checked In|Checked Out",
            ErrorMessage = "Trạng thái phải là 'Checked In' hoặc 'Checked Out'")]
        public string TrangThai { get; set; } = string.Empty;

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDungModel? NguoiDung { get; set; }
    }
}
