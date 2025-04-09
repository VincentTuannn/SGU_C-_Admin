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
            return thietBiDAO.GetAllThietBi();
        }

        public void AddThietBi(ThietBiDTO thietBi)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(thietBi.TenThietBi))
            {
                throw new Exception("Tên thiết bị không được để trống!");
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

    }
}
