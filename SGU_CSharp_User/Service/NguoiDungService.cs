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
                return user; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user by ID: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> Register(NguoiDungModel user)
        {
            try
            {
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    return false;
                }

                await _context.Users.AddAsync(user);

                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Register: {ex.Message}");
                return false;
            }
        }
        public async Task<(bool Success, string Message)> UpdatePassword(int userId, string newPassword, string currentPassword)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return (false, "Không tìm thấy người dùng.");
                }

                if (user.MatKhau != currentPassword)
                {
                    return (false, "Mật khẩu hiện tại không chính xác.");
                }

                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    return (false, "Mật khẩu mới phải có ít nhất 6 ký tự.");
                }

                if (newPassword == currentPassword)
                {
                    return (false, "Mật khẩu mới không thể giống mật khẩu hiện tại.");
                }

                user.MatKhau = newPassword;

                await _context.SaveChangesAsync();

                return (true, "Cập nhật mật khẩu thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating password: {ex.Message}");
                return (false, "Đã xảy ra lỗi khi cập nhật mật khẩu.");
            }
        }

        public bool getUserByEmail(string email)
        {
            try
            {
                // Kiểm tra email có tồn tại trong database không
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                // Trả về true nếu tìm thấy user (email đã tồn tại)
                // Trả về false nếu không tìm thấy (email chưa được sử dụng)
                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking email existence: {ex.Message}");
                return false;
            }
        }

        public bool getUserByPhone(string phone)
        {
            try
            {
                // Kiểm tra email có tồn tại trong database không
                var user = _context.Users.FirstOrDefault(u => u.SoDienThoai == phone);

                // Trả về true nếu tìm thấy user (email đã tồn tại)
                // Trả về false nếu không tìm thấy (email chưa được sử dụng)
                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking phone existence: {ex.Message}");
                return false;
            }
        }



        public async Task<NguoiDungModel> GetUserByEmailAndPhone(string email, string phoneNumber)
        {
            try
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == email && u.SoDienThoai == phoneNumber);

                return user; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserByEmailAndPhone: {ex.Message}");
                return null;
            }
        }

        public async Task<(bool Success, string Message)> UpdatePasswordForgot(string email, string phoneNumber, string newPassword)
        {
            try
            {
                var user = await Task.FromResult(_context.Users
                    .FirstOrDefault(u => u.Email == email && u.SoDienThoai == phoneNumber));

                if (user == null)
                {
                    return (false, "Không tìm thấy thông tin người dùng.");
                }

                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    return (false, "Mật khẩu mới phải có ít nhất 6 ký tự.");
                }

                user.MatKhau = newPassword;

                await _context.SaveChangesAsync();

                return (true, "Đặt lại mật khẩu thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdatePasswordForgot: {ex.Message}");
                return (false, "Đã xảy ra lỗi khi đặt lại mật khẩu.");
            }
        }

    }
}
