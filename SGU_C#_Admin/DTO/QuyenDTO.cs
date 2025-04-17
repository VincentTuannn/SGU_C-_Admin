using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.DTO
{
    internal class QuyenDTO
    {
        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; }

        public QuyenDTO() { }

        public QuyenDTO(int maQuyen, string tenQuyen)
        {
            MaQuyen = maQuyen;
            TenQuyen = tenQuyen;
        }
    }
}
