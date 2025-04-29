using SGU_CSharp_User.Data;
using SGU_CSharp_User.Model;
using Microsoft.EntityFrameworkCore;


namespace SGU_CSharp_User.Service
{
    public class RoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhieuMuonPhongModel>> GetUserBookedRooms(int userId)
        {
            try
            {
                // Query the database for room bookings matching the userId
                var bookedRooms = await _context.PhieuMuonPhongModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai.Equals("Đang mượn"))
                    //.Where(p => p.TrangThai.Equals("Đã trả"))
                    .Include(p => p.Phong)  // Include related room information
                    .Include(p => p.NguoiDung) // Include user information if needed
                    .OrderByDescending(p => p.ThoiGianMuon) // Sort by booking time, newest first
                    .AsNoTracking() // Improves performance for read-only operations
                    .ToListAsync();

                return bookedRooms;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserBookedRooms: {ex.Message}");

                // Return empty list in case of error
                return new List<PhieuMuonPhongModel>();
            }
        }

    }
}
