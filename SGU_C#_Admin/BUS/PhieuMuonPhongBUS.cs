using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class PhieuMuonPhongBUS
    {
        private PhieuMuonPhongDAO phieuMuonPhongDAO = new PhieuMuonPhongDAO();

        public List<PhieuMuonPhongDTO> GetAllPhieuMuonPhong()
        {
            return phieuMuonPhongDAO.GetAllPhieuMuonPhong();
        }

        public List<PhieuMuonPhongDTO> GetAllPhieuMuonPhongByMaNguoiDung(int maNguoiDung)
        {
            try
            {
                return phieuMuonPhongDAO.GetAllPhieuMuonPhongByMaNguoiDung(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm phòng theo mã người dùng: " + ex.Message);
            }
        }

        public List<PhieuMuonPhongDTO> GetAllPhieuMuonPhongByMaPhieuMuonPhong(int maPhieuMuonPhong)
        {
            try
            {
                return phieuMuonPhongDAO.GetAllPhieuMuonPhongByMaPhieuMuonPhong(maPhieuMuonPhong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm người dùng theo ID: " + ex.Message);
            }
        }

        public void AddPhieuMuonPhong(PhieuMuonPhongDTO phieuMuonPhong)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (phieuMuonPhong.MaPhong <= 0 || phieuMuonPhong.MaNguoiDung <= 0)
            {
                throw new Exception("Mã phòng và mã người dùng phải lớn hơn 0!");
            }
            if (phieuMuonPhong.ThoiGianMuon >= phieuMuonPhong.ThoiGianTra)
            {
                throw new Exception("Thời gian mượn phải nhỏ hơn thời gian trả!");
            }
            if (!new List<string> { "Đang mượn", "Đã trả", "Quá hạn" }.Contains(phieuMuonPhong.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (phieuMuonPhong.TongTien < 0)
            {
                throw new Exception("Tổng tiền không được âm!");
            }
            phieuMuonPhongDAO.AddPhieuMuonPhong(phieuMuonPhong);
        }

        public void UpdatePhieuMuonPhong(PhieuMuonPhongDTO phieuMuonPhong)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (phieuMuonPhong.MaPhong <= 0 || phieuMuonPhong.MaNguoiDung <= 0)
            {
                throw new Exception("Mã phòng và mã người dùng phải lớn hơn 0!");
            }
            if (phieuMuonPhong.ThoiGianMuon >= phieuMuonPhong.ThoiGianTra)
            {
                throw new Exception("Thời gian mượn phải nhỏ hơn thời gian trả!");
            }
            if (!new List<string> { "Đang mượn", "Đã trả", "Quá hạn" }.Contains(phieuMuonPhong.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (phieuMuonPhong.TongTien < 0)
            {
                throw new Exception("Tổng tiền không được âm!");
            }
            phieuMuonPhongDAO.UpdatePhieuMuonPhong(phieuMuonPhong);
        }

        public void DeletePhieuMuonPhong(int maPhieuMuonPhong)
        {
            phieuMuonPhongDAO.DeletePhieuMuonPhong(maPhieuMuonPhong);
        }
    }
}
