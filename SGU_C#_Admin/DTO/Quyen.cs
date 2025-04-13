namespace SGU_C__User.DTO
{
    public class Quyen
    {
        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; }

        public Quyen(int maQuyen, string tenQuyen)
        {
            MaQuyen = maQuyen;
            TenQuyen = tenQuyen;
        }

        public override string ToString()
        {
            return TenQuyen; // Để hiển thị trong ComboBox
        }
    }
}