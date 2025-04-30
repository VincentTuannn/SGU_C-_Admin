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
        public async Task<bool> Register(NguoiDungModel user)
        {
            try
            {
                // Check if email already exists
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    return false;
                }

                // Add user to database
                await _context.Users.AddAsync(user);

                // Save changes
                var result = await _context.SaveChangesAsync();

                // Return true if at least one record was added
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
                // Find the user by ID
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return (false, "Không tìm thấy người dùng.");
                }

                // Verify the current password
                if (user.MatKhau != currentPassword)
                {
                    return (false, "Mật khẩu hiện tại không chính xác.");
                }

                // Basic password validation (additional validation should be done on the client side)
                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    return (false, "Mật khẩu mới phải có ít nhất 6 ký tự.");
                }

                // Check if new password is the same as the current one
                if (newPassword == currentPassword)
                {
                    return (false, "Mật khẩu mới không thể giống mật khẩu hiện tại.");
                }

                // Update the password
                user.MatKhau = newPassword;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return (true, "Cập nhật mật khẩu thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating password: {ex.Message}");
                return (false, "Đã xảy ra lỗi khi cập nhật mật khẩu.");
            }
        }
  
    public async Task<NguoiDungModel> GetUserByEmailAndPhone(string email, string phoneNumber)
        {
            try
            {
                // Tìm người dùng có email và số điện thoại khớp
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == email && u.SoDienThoai == phoneNumber);

                return user; // Sẽ trả về null nếu không tìm thấy người dùng
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
                // Tìm người dùng dựa trên email và số điện thoại
                var user = await Task.FromResult(_context.Users
                    .FirstOrDefault(u => u.Email == email && u.SoDienThoai == phoneNumber));

                if (user == null)
                {
                    return (false, "Không tìm thấy thông tin người dùng.");
                }

                // Kiểm tra mật khẩu mới
                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    return (false, "Mật khẩu mới phải có ít nhất 6 ký tự.");
                }

                // Cập nhật mật khẩu mới
                user.MatKhau = newPassword;

                // Lưu thay đổi vào database
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
