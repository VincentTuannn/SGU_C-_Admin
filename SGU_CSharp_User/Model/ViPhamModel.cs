using SGU_CSharp_User.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("vipham")]
    public class ViPhamModel
    {
        [Key]
        public int MaViPham { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "Mã thiết bị là bắt buộc")]
        public int MaThietBi { get; set; }

        [Required(ErrorMessage = "Mã phòng là bắt buộc")]
        public int MaPhong { get; set; }

        [Required(ErrorMessage = "Loại vi phạm là bắt buộc")]
        [RegularExpression("Trả trễ|Làm hỏng|Làm mất|Khác",
            ErrorMessage = "Loại vi phạm phải là 'Trả trễ', 'Làm hỏng', 'Làm mất' hoặc 'Khác'")]
        public string LoaiViPham { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nội dung vi phạm là bắt buộc")]
        [StringLength(500)]
        public string NoiDungViPham { get; set; } = string.Empty;

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDungModel? NguoiDung { get; set; }

        [ForeignKey("MaThietBi")]
        public virtual ThietBiModel? ThietBi { get; set; }

        [ForeignKey("MaPhong")]
        public virtual PhongModel? Phong { get; set; }
    }
}
