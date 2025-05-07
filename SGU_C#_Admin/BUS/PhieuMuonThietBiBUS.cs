using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class PhieuMuonThietBiBUS
    {
        private PhieuMuonThietBiDAO phieuMuonThietBiDAO = new PhieuMuonThietBiDAO();

        public List<PhieuMuonThietBiDTO> GetAllPhieuMuonThietBi()
        {
            return phieuMuonThietBiDAO.GetAllPhieuMuonThietBi();
        }

        public List<PhieuMuonThietBiDTO> GetAllPhieuMuonThietBiByMaNguoiDung(int maNguoiDung)
        {
            try
            {
                return phieuMuonThietBiDAO.GetAllPhieuMuonThietBiByMaNguoiDung(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm thiết bị theo mã người dùng: " + ex.Message);
            }
        }

        public List<PhieuMuonThietBiDTO> GetAllPhieuMuonThietBiByMaPhieuMuonThietBi(int maPhieuMuonThietBi)
        {
            try
            {
                return phieuMuonThietBiDAO.GetAllPhieuMuonThietBiByMaPhieuMuonThietBi(maPhieuMuonThietBi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm phiếu mượn thiết bị theo ID: " + ex.Message);
            }
        }

        public void AddPhieuMuonThietBi(PhieuMuonThietBiDTO phieuMuonThietBi)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (phieuMuonThietBi.MaNguoiDung <= 0 || phieuMuonThietBi.MaThietBi <= 0)
            {
                throw new Exception("Mã người dùng và mã thiết bị phải lớn hơn 0!");
            }
            if (!new List<string> { "Đã đặt", "Đang mượn", "Đã trả", "Quá hạn" }.Contains(phieuMuonThietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (phieuMuonThietBi.ThoiGianMuon >= phieuMuonThietBi.ThoiGianTra)
            {
                throw new Exception("Thời gian mượn phải nhỏ hơn thời gian trả!");
            }
            if (phieuMuonThietBi.TongTien < 0)
            {
                throw new Exception("Tổng tiền không được âm!");
            }
            phieuMuonThietBiDAO.AddPhieuMuonThietBi(phieuMuonThietBi);
        }

        public void UpdatePhieuMuonThietBi(PhieuMuonThietBiDTO phieuMuonThietBi)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (phieuMuonThietBi.MaNguoiDung <= 0 || phieuMuonThietBi.MaThietBi <= 0)
            {
                throw new Exception("Mã người dùng và mã thiết bị phải lớn hơn 0!");
            }
            if (!new List<string> { "Đã đặt", "Đang mượn", "Đã trả", "Quá hạn" }.Contains(phieuMuonThietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (phieuMuonThietBi.ThoiGianMuon >= phieuMuonThietBi.ThoiGianTra)
            {
                throw new Exception("Thời gian mượn phải nhỏ hơn thời gian trả!");
            }
            if (phieuMuonThietBi.TongTien < 0)
            {
                throw new Exception("Tổng tiền không được âm!");
            }
            phieuMuonThietBiDAO.UpdatePhieuMuonThietBi(phieuMuonThietBi);
        }

        public void UpdateTrangThaiPhieuMuonThietBi(int maPhieuMuonThietBi, string trangThai)
        {
            try
            {
                // Kiểm tra trạng thái hợp lệ
                if (!new List<string> { "Đã đặt", "Đang mượn", "Đã trả", "Quá hạn" }.Contains(trangThai))
                {
                    throw new Exception("Trạng thái không hợp lệ!");
                }

                // Lấy thông tin phiếu mượn hiện tại
                var phieuMuon = GetAllPhieuMuonThietBiByMaPhieuMuonThietBi(maPhieuMuonThietBi).FirstOrDefault();
                if (phieuMuon == null)
                {
                    throw new Exception("Không tìm thấy phiếu mượn thiết bị!");
                }

                // Cập nhật trạng thái
                phieuMuon.TrangThai = trangThai;
                phieuMuonThietBiDAO.UpdatePhieuMuonThietBi(phieuMuon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái phiếu mượn thiết bị: " + ex.Message);
            }
        }

        public void DeletePhieuMuonThietBi(int maPhieuMuonThietBi)
        {
            phieuMuonThietBiDAO.DeletePhieuMuonThietBi(maPhieuMuonThietBi);
        }
    }
}
