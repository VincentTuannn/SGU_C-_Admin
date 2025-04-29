using SGU_CSharp_User.Data;
using SGU_CSharp_User.Model;

namespace SGU_CSharp_User.Service
{
    public class NguoiDungService
    {
        private readonly ApplicationDbContext _context;

        public NguoiDungService(ApplicationDbContext context)
        {
            _context = context;
        }

        public NguoiDungModel login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.MatKhau == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public NguoiDungModel GetUserById(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.MaNguoiDung == userId);
                return user; // Will return null if user doesn't exist
            }
            catch (Exception ex)
            {
                // Log exception if desired
                Console.WriteLine($"Error retrieving user by ID: {ex.Message}");
                return null;
            }
        }


    }
}
