using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGU_CSharp_User.Model
{
    [Table("phieumuonphong")]
    public class PhieuMuonPhongModel
    {
        [Key]
        public int MaPhieuMuonPhong { get; set; }

        [Required(ErrorMessage = "Mã phòng là bắt buộc")]
        public int MaPhong { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "Thời gian mượn là bắt buộc")]
        public DateTime ThoiGianMuon { get; set; }

        [Required(ErrorMessage = "Thời gian trả là bắt buộc")]
        public DateTime ThoiGianTra { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [RegularExpression("Đang mượn|Đã trả",
            ErrorMessage = "Trạng thái phải là 'Đang mượn' hoặc 'Đã trả'")]
        public string TrangThai { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tổng tiền là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn 0")]
        public decimal TongTien { get; set; }

        [ForeignKey("MaPhong")]
        public virtual PhongModel? Phong { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDungModel? NguoiDung { get; set; }
    }
}
