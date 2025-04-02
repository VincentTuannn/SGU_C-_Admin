using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class PhongBUS
    {
        private PhongDAO phongDAO = new PhongDAO();

        public List<PhongDTO> GetAllPhong()
        {
            return phongDAO.GetAllPhong();
        }

        public void AddPhong(PhongDTO phong)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(phong.TenPhong) || string.IsNullOrEmpty(phong.LoaiPhong))
            {
                throw new Exception("Tên phòng và loại phòng không được để trống!");
            }
            if (phong.SucChua <= 0 || phong.GiaMuon < 0)
            {
                throw new Exception("Sức chứa phải lớn hơn 0 và giá mượn không được âm!");
            }
            if (!new List<string> { "Trống", "Đang mượn", "Bảo trì" }.Contains(phong.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            phongDAO.AddPhong(phong);
        }

        public void UpdatePhong(PhongDTO phong)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (string.IsNullOrEmpty(phong.TenPhong) || string.IsNullOrEmpty(phong.LoaiPhong))
            {
                throw new Exception("Tên phòng và loại phòng không được để trống!");
            }
            if (phong.SucChua <= 0 || phong.GiaMuon < 0)
            {
                throw new Exception("Sức chứa phải lớn hơn 0 và giá mượn không được âm!");
            }
            if (!new List<string> { "Trống", "Đang mượn", "Bảo trì" }.Contains(phong.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            phongDAO.UpdatePhong(phong);
        }

        public void DeletePhong(int maPhong)
        {
            phongDAO.DeletePhong(maPhong);
        }
    }
}
