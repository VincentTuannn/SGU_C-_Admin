using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class ThongBaoBUS
    {
        private ThongBaoDAO thongBaoDAO = new ThongBaoDAO();

        public List<ThongBaoDTO> GetAllThongBao()
        {
            return thongBaoDAO.GetAllThongBao();
        }

        public void AddThongBao(ThongBaoDTO thongBao)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (thongBao.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (string.IsNullOrEmpty(thongBao.TieuDe))
            {
                throw new Exception("Tiêu đề không được để trống!");
            }
            if (string.IsNullOrEmpty(thongBao.NoiDung))
            {
                throw new Exception("Nội dung không được để trống!");
            }
            if (!new List<string> { "Chung", "Vi Phạm", "Sự Kiện" }.Contains(thongBao.LoaiThongBao))
            {
                throw new Exception("Loại thông báo không hợp lệ!");
            }
            if (thongBao.ThoiGianGui > DateTime.Now)
            {
                throw new Exception("Thời gian gửi không được lớn hơn thời gian hiện tại!");
            }
            thongBaoDAO.AddThongBao(thongBao);
        }

        public void UpdateThongBao(ThongBaoDTO thongBao)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (thongBao.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (string.IsNullOrEmpty(thongBao.TieuDe))
            {
                throw new Exception("Tiêu đề không được để trống!");
            }
            if (string.IsNullOrEmpty(thongBao.NoiDung))
            {
                throw new Exception("Nội dung không được để trống!");
            }
            if (!new List<string> { "Chung", "Vi Phạm", "Sự Kiện" }.Contains(thongBao.LoaiThongBao))
            {
                throw new Exception("Loại thông báo không hợp lệ!");
            }
            if (thongBao.ThoiGianGui > DateTime.Now)
            {
                throw new Exception("Thời gian gửi không được lớn hơn thời gian hiện tại!");
            }
            thongBaoDAO.UpdateThongBao(thongBao);
        }

        public void DeleteThongBao(int maThongBao)
        {
            thongBaoDAO.DeleteThongBao(maThongBao);
        }
    }
}
