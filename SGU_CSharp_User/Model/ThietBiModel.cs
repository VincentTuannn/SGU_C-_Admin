using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("thietbi")]
    public class ThietBiModel
    {
        [Key]
        public int MaThietBi { get; set; }

        [Required(ErrorMessage = "Tên thiết bị là bắt buộc")]
        [StringLength(100)]
        public string TenThietBi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Loại thiết bị là bắt buộc")]
        [StringLength(50)]
        public string LoaiThietBi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [RegularExpression("Có sẵn|Đang sử dụng|Bảo trì",
            ErrorMessage = "Trạng thái phải là 'Có sẵn', 'Đang sử dụng' hoặc 'Bảo trì'")]
        public string TrangThai { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá mượn là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá mượn phải lớn hơn 0")]
        public decimal GiaMuon { get; set; }
    }
}
