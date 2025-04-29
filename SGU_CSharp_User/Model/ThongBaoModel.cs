using SGU_CSharp_User.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("thongbao")]
    public class ThongBaoModel
    {
        [Key]
        public int MaThongBao { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
        [StringLength(100)]
        public string TieuDe { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        [StringLength(500)]
        public string NoiDung { get; set; } = string.Empty;

        [Required(ErrorMessage = "Loại thông báo là bắt buộc")]
        [RegularExpression("Chung|Vi Phạm|Sự Kiện",
            ErrorMessage = "Loại thông báo phải là 'Chung', 'Vi Phạm' hoặc 'Sự Kiện'")]
        public string LoaiThongBao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Thời gian gửi là bắt buộc")]
        public DateTime ThoiGianGui { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDungModel? NguoiDung { get; set; }
    }
}
