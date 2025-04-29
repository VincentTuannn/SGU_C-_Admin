using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("phong")]
    public class PhongModel
    {
        [Key]
        public int MaPhong { get; set; }

        [Required(ErrorMessage = "Tên phòng là bắt buộc")]
        [StringLength(100)]
        public string TenPhong { get; set; } = string.Empty;

        [Required(ErrorMessage = "Loại phòng là bắt buộc")]
        [StringLength(50)]
        public string LoaiPhong { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sức chứa là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Sức chứa phải lớn hơn 0")]
        public int SucChua { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [RegularExpression("Trống|Đang mượn|Bảo trì",
            ErrorMessage = "Trạng thái phải là 'Trống', 'Đang mượn' hoặc 'Bảo trì'")]
        public string TrangThai { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá mượn là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá mượn phải lớn hơn 0")]
        public decimal GiaMuon { get; set; }
    }
}
