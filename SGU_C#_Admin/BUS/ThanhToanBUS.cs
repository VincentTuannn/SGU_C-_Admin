using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class ThanhToanBUS
    {
        private ThanhToanDAO thanhToanDAO = new ThanhToanDAO();

        public List<ThanhToanDTO> GetAllThanhToan()
        {
            return thanhToanDAO.GetAllThanhToan();
        }

        public void AddThanhToan(ThanhToanDTO thanhToan)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (thanhToan.MaPhieuTra <= 0)
            {
                throw new Exception("Mã phiếu trả phải lớn hơn 0!");
            }
            if (thanhToan.TongTienPhaiTra < 0)
            {
                throw new Exception("Tổng tiền phải trả không được âm!");
            }
            if (thanhToan.NgayThanhToan > DateTime.Now)
            {
                throw new Exception("Ngày thanh toán không được lớn hơn thời gian hiện tại!");
            }
            if (!new List<string> { "Tiền mặt", "Chuyển khoản" }.Contains(thanhToan.HinhThucThanhToan))
            {
                throw new Exception("Hình thức thanh toán không hợp lệ!");
            }
            thanhToanDAO.AddThanhToan(thanhToan);
        }

        public void UpdateThanhToan(ThanhToanDTO thanhToan)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (thanhToan.MaPhieuTra <= 0)
            {
                throw new Exception("Mã phiếu trả phải lớn hơn 0!");
            }
            if (thanhToan.TongTienPhaiTra < 0)
            {
                throw new Exception("Tổng tiền phải trả không được âm!");
            }
            if (thanhToan.NgayThanhToan > DateTime.Now)
            {
                throw new Exception("Ngày thanh toán không được lớn hơn thời gian hiện tại!");
            }
            if (!new List<string> { "Tiền mặt", "Chuyển khoản" }.Contains(thanhToan.HinhThucThanhToan))
            {
                throw new Exception("Hình thức thanh toán không hợp lệ!");
            }
            thanhToanDAO.UpdateThanhToan(thanhToan);
        }

        public void DeleteThanhToan(int maThanhToan)
        {
            thanhToanDAO.DeleteThanhToan(maThanhToan);
        }
    }
}
