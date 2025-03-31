using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class ThietBiDTO
    {
        public int MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string LoaiThietBi { get; set; }
        public string TrangThai { get; set; }
        public int GiaMuon { get; set; }

        public ThietBiDTO() { }

        public ThietBiDTO(int maThietBi, string tenThietBi, string loaiThietBi, string trangThai, int giaMuon)
        {
            MaThietBi = maThietBi;
            TenThietBi = tenThietBi;
            LoaiThietBi = loaiThietBi;
            TrangThai = trangThai;
            GiaMuon = giaMuon;
        }
    }
}
