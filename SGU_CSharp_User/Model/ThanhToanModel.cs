using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("thanhtoan")]
    public class ThanhToanModel
    {
        [Key]
        public int MaThanhToan { get; set; }

        [Required(ErrorMessage = "Mã phiếu trả là bắt buộc")]
        public int MaPhieuTra { get; set; }

        [Required(ErrorMessage = "Tổng tiền phải trả là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải trả phải lớn hơn 0")]
        public decimal TongTienPhaiTra { get; set; }

        [Required(ErrorMessage = "Ngày thanh toán là bắt buộc")]
        public DateTime NgayThanhToan { get; set; }

        [Required(ErrorMessage = "Hình thức thanh toán là bắt buộc")]
        [RegularExpression("Tiền mặt|Chuyển khoản",
            ErrorMessage = "Hình thức thanh toán phải là 'Tiền mặt' hoặc 'Chuyển khoản'")]
        public string HinhThucThanhToan { get; set; } = string.Empty;

        [ForeignKey("MaPhieuTra")]
        public virtual PhieuTraModel? PhieuTra { get; set; }
    }
}
