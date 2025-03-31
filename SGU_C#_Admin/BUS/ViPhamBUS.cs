using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;

namespace SGU_C__User.BUS
{
    public class ViPhamBUS
    {
        private ViPhamDAO viPhamDAO;

        public ViPhamBUS()
        {
            viPhamDAO = new ViPhamDAO();
        }

        // Lấy danh sách vi phạm
        public List<ViPhamDTO> GetAllViPham()
        {
            return viPhamDAO.GetAllViPham();
        }

        // Thêm vi phạm mới
        public bool AddViPham(ViPhamDTO viPham)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (viPham.MaNguoiDung <= 0 || viPham.MaThietBi <= 0 || viPham.MaPhong <= 0)
            {
                throw new ArgumentException("Mã người dùng, thiết bị và phòng phải lớn hơn 0.");
            }
            if (string.IsNullOrEmpty(viPham.LoaiViPham) || !IsValidLoaiViPham(viPham.LoaiViPham))
            {
                throw new ArgumentException("Loại vi phạm không hợp lệ.");
            }
            return viPhamDAO.AddViPham(viPham);
        }

        // Cập nhật vi phạm
        public bool UpdateViPham(ViPhamDTO viPham)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (viPham.MaViPham <= 0)
            {
                throw new ArgumentException("Mã vi phạm phải lớn hơn 0.");
            }
            if (viPham.MaNguoiDung <= 0 || viPham.MaThietBi <= 0 || viPham.MaPhong <= 0)
            {
                throw new ArgumentException("Mã người dùng, thiết bị và phòng phải lớn hơn 0.");
            }
            if (string.IsNullOrEmpty(viPham.LoaiViPham) || !IsValidLoaiViPham(viPham.LoaiViPham))
            {
                throw new ArgumentException("Loại vi phạm không hợp lệ.");
            }
            return viPhamDAO.UpdateViPham(viPham);
        }

        // Xóa vi phạm
        public bool DeleteViPham(int maViPham)
        {
            if (maViPham <= 0)
            {
                throw new ArgumentException("Mã vi phạm phải lớn hơn 0.");
            }
            return viPhamDAO.DeleteViPham(maViPham);
        }

        // Kiểm tra LoaiViPham hợp lệ
        private bool IsValidLoaiViPham(string loaiViPham)
        {
            string[] validTypes = { "Trễ", "Làm hỏng", "Làm mất", "Khác" };
            return Array.Exists(validTypes, type => type == loaiViPham);
        }
    }
}