using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class PhieuTraBUS
    {
        private PhieuTraDAO phieuTraDAO = new PhieuTraDAO();

        public List<PhieuTraDTO> GetAllPhieuTra()
        {
            return phieuTraDAO.GetAllPhieuTra();
        }

        public void AddPhieuTra(PhieuTraDTO phieuTra)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (phieuTra.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (phieuTra.ThoiGianTra > DateTime.Now)
            {
                throw new Exception("Thời gian trả không được lớn hơn thời gian hiện tại!");
            }
            if (phieuTra.TongTienPhaiTra < 0 || phieuTra.TienPhat < 0)
            {
                throw new Exception("Tổng tiền phải trả và tiền phạt không được âm!");
            }
            phieuTraDAO.AddPhieuTra(phieuTra);
        }

        public void UpdatePhieuTra(PhieuTraDTO phieuTra)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (phieuTra.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (phieuTra.ThoiGianTra > DateTime.Now)
            {
                throw new Exception("Thời gian trả không được lớn hơn thời gian hiện tại!");
            }
            if (phieuTra.TongTienPhaiTra < 0 || phieuTra.TienPhat < 0)
            {
                throw new Exception("Tổng tiền phải trả và tiền phạt không được âm!");
            }
            phieuTraDAO.UpdatePhieuTra(phieuTra);
        }

        public void DeletePhieuTra(int maPhieuTra)
        {
            phieuTraDAO.DeletePhieuTra(maPhieuTra);
        }
    }
}
