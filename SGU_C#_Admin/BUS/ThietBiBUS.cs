using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class ThietBiBUS
    {
        private ThietBiDAO thietbiDAO = new ThietBiDAO();

        private ThietBiDAO thietBiDAO = new ThietBiDAO();

        public List<ThietBiDTO> GetAllThietBi()
        {
            try
            {
                return thietBiDAO.GetAllThietBi();
            }
            catch (Exception ex) 
            {
                throw new Exception("Lỗi khi tìm kiếm tất cả thiết bị: " + ex.Message);
            } 
            
        }

        public List<ThietBiDTO> GetAllThietBiByName(string tenThietBi)
        {
            try
            {
                return thietBiDAO.GetAllThietBiByName(tenThietBi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm thiết bị theo tên: " + ex.Message);
            }
        }

        public List<ThietBiDTO> GetAllThietBiByID(int maThietBi)
        {
            try
            {
                return thietBiDAO.GetAllThietBiByID(maThietBi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm thiết bị theo ID: " + ex.Message);
            }
        }

        public void AddThietBi(ThietBiDTO thietBi)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(thietBi.TenThietBi))
            {
                throw new Exception("Tên thiết bị không được để trống!");
            }
            if (thietBiDAO.IsDeviceExist(thietBi.TenThietBi))
            {
                throw new Exception("Thiết bị đã tồn tại!");
            }
            if (string.IsNullOrEmpty(thietBi.LoaiThietBi))
            {
                throw new Exception("Loại thiết bị không được để trống!");
            }
            if (!new List<string> { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(thietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (thietBi.GiaMuon < 0)
            {
                throw new Exception("Giá mượn không được âm!");
            }
            thietBiDAO.AddThietBi(thietBi);
        }

        public void UpdateThietBi(ThietBiDTO thietBi)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (string.IsNullOrEmpty(thietBi.TenThietBi))
            {
                throw new Exception("Tên thiết bị không được để trống!");
            }
            if (thietBiDAO.IsDeviceExist(thietBi.TenThietBi))
            {
                throw new Exception("Thiết bị đã tồn tại!");
            }
            if (string.IsNullOrEmpty(thietBi.LoaiThietBi))
            {
                throw new Exception("Loại thiết bị không được để trống!");
            }
            if (!new List<string> { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(thietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            if (thietBi.GiaMuon < 0)
            {
                throw new Exception("Giá mượn không được âm!");
            }
            thietBiDAO.UpdateThietBi(thietBi);
        }

        public void DeleteThietBi(int maThietBi)
        {
            thietBiDAO.DeleteThietBi(maThietBi);
        }

        // Phương thức lấy số lượng thiết bị
        public int CountSoLuong() 
        {
            try
            {
                int count = thietBiDAO.CountSoLuong(); 
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số lượng thiết bị: " + ex.Message);
            }
        }

        public void UpdateTrangThai(int maThietBi, string trangThai, DateTime? thoiGianTra = null)
        {
            try
            {
                if (!new List<string> { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(trangThai))
                {
                    throw new Exception("Trạng thái không hợp lệ!");
                }
                thietBiDAO.UpdateTrangThai(maThietBi, trangThai, thoiGianTra);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái thiết bị: " + ex.Message);
            }
        }

        public List<ThietBiDTO> GetThietBiDaDatByNguoiDung(int maNguoiDung)
        {
            // Giả sử bạn có thể lấy tất cả thiết bị và lọc theo MaNguoiDung và trạng thái
            // Nếu cần truy vấn DB chuẩn hơn, hãy thêm hàm tương ứng ở DAO
            var allPhieuMuon = new PhieuMuonThietBiBUS().GetAllPhieuMuonThietBiByMaNguoiDung(maNguoiDung);
            var thietBiIds = allPhieuMuon
                .Where(p => p.TrangThai == "Đã đặt chỗ")
                .Select(p => p.MaThietBi)
                .ToList();
            var allThietBi = GetAllThietBi();
            return allThietBi.Where(tb => thietBiIds.Contains(tb.MaThietBi)).ToList();
        }

    }
}
