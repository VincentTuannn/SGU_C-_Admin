using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("phieutra")]
    public class PhieuTraModel
    {
        [Key]
        public int MaPhieuTra { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "Thời gian trả là bắt buộc")]
        public DateTime ThoiGianTra { get; set; }

        [Required(ErrorMessage = "Tổng tiền phải trả là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải trả phải lớn hơn 0")]
        public decimal TongTienPhaiTra { get; set; }

        [Required(ErrorMessage = "Tiền phạt là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tiền phạt phải lớn hơn hoặc bằng 0")]
        public decimal TienPhat { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDungModel? NguoiDung { get; set; }
    }
}
