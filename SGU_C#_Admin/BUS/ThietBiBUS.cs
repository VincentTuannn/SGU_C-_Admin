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

        public List<ThietBiDTO> GetAllThietBi()
        {
            return thietbiDAO.GetAllThietBi();
        }

        public ThietBiDTO GetThietBiById(int maThietBi)
        {
            return thietbiDAO.GetById(maThietBi);
        }

        public bool AddNewThietBi(ThietBiDTO thietBi)
        {
            if (string.IsNullOrEmpty(thietBi.TenThietBi) || string.IsNullOrEmpty(thietBi.LoaiThietBi))
            {
                throw new Exception("Tên thiết bị và loại thiết bị không được để trống!");
            }
            if (thietBi.GiaMuon < 0)
            {
                throw new Exception("Giá mượn không được âm!");
            }
            if (!new[] { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(thietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            
            return thietbiDAO.AddThietBi(thietBi);
        }

        public bool UpdateThietBi(ThietBiDTO thietBi)
        {
            if (string.IsNullOrEmpty(thietBi.TenThietBi) || string.IsNullOrEmpty(thietBi.LoaiThietBi))
            {
                throw new Exception("Tên thiết bị và loại thiết bị không được để trống!");
            }
            if (thietBi.GiaMuon < 0)
            {
                throw new Exception("Giá mượn không được âm!");
            }
            if (!new[] { "Có sẵn", "Đang sử dụng", "Bảo trì" }.Contains(thietBi.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }

            return thietbiDAO.UpdateThietBi(thietBi);
        }

        public bool DeleteThietBi(int maThietBi)
        {
            return thietbiDAO.DeleteThietBi(maThietBi);
        }
    }
}
