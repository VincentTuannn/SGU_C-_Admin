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

        public async Task<List<PhongModel>> GetEmptyRoom()
        {
            try
            {
                var rooms = await _context.PhongModels
                    .Where(p => p.TrangThai.Equals("Trống"))
                    .ToListAsync();

                return rooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEmptyRoom: {ex.Message}");

                return new List<PhongModel>();
            }
        }

        public async Task<bool> SaveBooking(PhieuMuonPhongModel bookingModel)
        {
            // Use a transaction to ensure both operations (save booking and update room status) succeed or fail together
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Validate the booking model
                if (bookingModel == null)
                    throw new ArgumentNullException(nameof(bookingModel), "Booking model cannot be null");

                if (bookingModel.MaPhong <= 0)
                    throw new ArgumentException("Invalid room ID", nameof(bookingModel.MaPhong));

                if (bookingModel.MaNguoiDung <= 0)
                    throw new ArgumentException("Invalid user ID", nameof(bookingModel.MaNguoiDung));

                if (bookingModel.ThoiGianMuon >= bookingModel.ThoiGianTra)
                    throw new ArgumentException("Start time must be before end time");

                // Check if room exists and is available
                var room = await _context.PhongModels
                    .FirstOrDefaultAsync(r => r.MaPhong == bookingModel.MaPhong);

                if (room == null)
                    throw new InvalidOperationException($"Room with ID {bookingModel.MaPhong} does not exist");

                if (room.TrangThai != "Trống")
                    throw new InvalidOperationException($"Room with ID {bookingModel.MaPhong} is not available");

                // Check for conflicting bookings
                var conflictingBookings = await _context.PhieuMuonPhongModels
                    .Where(p => p.MaPhong == bookingModel.MaPhong)
                    .Where(p => p.TrangThai == "Đang mượn")
                    .Where(p =>
                        (p.ThoiGianMuon <= bookingModel.ThoiGianMuon && p.ThoiGianTra > bookingModel.ThoiGianMuon) ||
                        (p.ThoiGianMuon < bookingModel.ThoiGianTra && p.ThoiGianTra >= bookingModel.ThoiGianTra) ||
                        (p.ThoiGianMuon >= bookingModel.ThoiGianMuon && p.ThoiGianTra <= bookingModel.ThoiGianTra)
                    )
                    .ToListAsync();

                if (conflictingBookings.Any())
                    throw new InvalidOperationException("The room is already booked for the selected time period");

                // Set default values for the booking
                bookingModel.TrangThai = "Đang mượn";

                // Save the booking
                await _context.PhieuMuonPhongModels.AddAsync(bookingModel);
                await _context.SaveChangesAsync();

                // Update the room status
                room.TrangThai = "Đang mượn";
                _context.PhongModels.Update(room);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Roll back the transaction in case of error
                await transaction.RollbackAsync();
                Console.WriteLine($"Error in SaveBooking: {ex.Message}");
                return false;
            }
        }
        public async Task<List<PhieuMuonPhongModel>> GetUserReturnedRooms(int userId)
        {
            try
            {
                var returnedRooms = await _context.PhieuMuonPhongModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai == "Đã trả")
                    .Include(p => p.Phong)  // Include related room information
                    .Include(p => p.NguoiDung) // Include user information if needed
                    .OrderByDescending(p => p.ThoiGianTra) // Sort by return time, newest first
                    .ToListAsync();

                return returnedRooms;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserReturnedRooms: {ex.Message}");
                // Return empty list in case of error
                return new List<PhieuMuonPhongModel>();
            }
        }


    }
}
