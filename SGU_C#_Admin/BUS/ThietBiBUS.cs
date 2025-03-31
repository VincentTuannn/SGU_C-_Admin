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

        public bool AddNewThietBi(string ten, string loai, string trangThai, int giaMuon)
        {
            ThietBiDTO thietbi = new ThietBiDTO(0, ten, loai, trangThai, giaMuon);
            return thietbiDAO.AddThietBi(thietbi);
        }

        public bool UpdateThietBi(int maThietBi, string ten, string loai, string trangThai, int giaMuon)
        {
            ThietBiDTO thietbi = new ThietBiDTO(maThietBi, ten, loai, trangThai, giaMuon);
            return thietbiDAO.UpdateThietBi(thietbi);
        }

        public bool DeleteThietBi(int maThietBi)
        {
            return thietbiDAO.DeleteThietBi(maThietBi);
        }
    }
}
