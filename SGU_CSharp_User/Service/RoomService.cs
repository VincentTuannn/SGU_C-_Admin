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
                var bookedRooms = await _context.PhieuMuonPhongModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai.Equals("Đang mượn"))
                    .Include(p => p.Phong)  
                    .Include(p => p.NguoiDung) 
                    .OrderByDescending(p => p.ThoiGianMuon) 
                    .AsNoTracking() 
                    .ToListAsync();

                return bookedRooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserBookedRooms: {ex.Message}");

                return new List<PhieuMuonPhongModel>();
            }
        }
        public async Task<List<PhieuMuonPhongModel>> GetRoomBookings(int roomId)
        {
            try
            {
                var bookings = await _context.PhieuMuonPhongModels
                    .Where(p => p.MaPhong == roomId)
                    .OrderBy(p => p.ThoiGianMuon)
                    .ToListAsync();

                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetDeviceBookings: {ex.Message}");
                return new List<PhieuMuonPhongModel>();
            }
        }
        public async Task<List<PhongModel>> GetEmptyRoom()
        {
            try
            {
                var rooms = await _context.PhongModels
                    .Where(p => !p.TrangThai.Equals("Bảo trì"))
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
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (bookingModel == null)
                    throw new ArgumentNullException(nameof(bookingModel), "Booking model cannot be null");

                if (bookingModel.MaPhong <= 0)
                    throw new ArgumentException("Invalid room ID", nameof(bookingModel.MaPhong));

                if (bookingModel.MaNguoiDung <= 0)
                    throw new ArgumentException("Invalid user ID", nameof(bookingModel.MaNguoiDung));

                if (bookingModel.ThoiGianMuon >= bookingModel.ThoiGianTra)
                    throw new ArgumentException("Start time must be before end time");

                var room = await _context.PhongModels
                    .FirstOrDefaultAsync(r => r.MaPhong == bookingModel.MaPhong);

                if (room == null)
                    throw new InvalidOperationException($"Room with ID {bookingModel.MaPhong} does not exist");

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

                bookingModel.TrangThai = "Đang mượn";

                await _context.PhieuMuonPhongModels.AddAsync(bookingModel);
                await _context.SaveChangesAsync();


                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
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
                    .Include(p => p.Phong)  
                    .Include(p => p.NguoiDung) 
                    .OrderByDescending(p => p.ThoiGianTra) 
                    .ToListAsync();

                return returnedRooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserReturnedRooms: {ex.Message}");
                return new List<PhieuMuonPhongModel>();
            }
        }


    }
}
