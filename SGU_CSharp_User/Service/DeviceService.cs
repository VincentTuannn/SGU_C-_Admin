using Microsoft.EntityFrameworkCore;
using SGU_CSharp_User.Data;
using SGU_CSharp_User.Model;

namespace SGU_CSharp_User.Service
{
    public class DeviceService
    {
        private readonly ApplicationDbContext _context;

        public DeviceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ThietBiModel>> getAll()
        {
            try
            {
                var allDevices = await _context.ThietBiModels
                    .Where(d => !d.TrangThai.Equals("Bảo trì"))
                    .OrderBy(d => d.MaThietBi)  // Sắp xếp theo mã thiết bị
                    .ToListAsync();

                return allDevices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getAll: {ex.Message}");
                return new List<ThietBiModel>();  // Trả về danh sách rỗng nếu có lỗi
            }
        }


        public async Task<List<PhieuMuonThietBiModel>> GetDeviceBookings(int deviceId)
        {
            try
            {
                var bookings = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaThietBi == deviceId)
                    .OrderBy(p => p.ThoiGianMuon)
                    .ToListAsync();

                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetDeviceBookings: {ex.Message}");
                return new List<PhieuMuonThietBiModel>();
            }
        }

        public async Task<List<PhieuMuonThietBiModel>> GetUserBorrowedDevices(int userId)
        {
            try
            {
                var borrowedDevices = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai.Equals("Đang mượn"))
                    .Include(p => p.ThietBi)  
                    .Include(p => p.NguoiDung) 
                    .OrderByDescending(p => p.ThoiGianMuon) 
                    .ToListAsync();

                foreach (var device in borrowedDevices)
                {
                    if (device.ThietBi != null)
                    {
                        // Add any additional processing here if needed
                    }
                }

                return borrowedDevices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserBorrowedDevices: {ex.Message}");
                return new List<PhieuMuonThietBiModel>();
            }
        }
 
 
    public async Task<List<ThietBiModel>> GetAvailableDevices()
        {
            try
            {
                var availableDevices = await _context.ThietBiModels
                    .Where(p => p.TrangThai.Equals("Có sẵn"))
                    .ToListAsync();

                return availableDevices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAvailableDevices: {ex.Message}");
                return new List<ThietBiModel>();
            }
        }

        public async Task<bool> SaveDeviceBooking(PhieuMuonThietBiModel bookingModel)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (bookingModel == null)
                    throw new ArgumentNullException(nameof(bookingModel), "Booking model cannot be null");

                if (bookingModel.MaThietBi <= 0)
                    throw new ArgumentException("Invalid device ID", nameof(bookingModel.MaThietBi));

                if (bookingModel.MaNguoiDung <= 0)
                    throw new ArgumentException("Invalid user ID", nameof(bookingModel.MaNguoiDung));

                if (bookingModel.ThoiGianMuon >= bookingModel.ThoiGianTra)
                    throw new ArgumentException("Start time must be before end time");

                var device = await _context.ThietBiModels
                    .FirstOrDefaultAsync(d => d.MaThietBi == bookingModel.MaThietBi);

                if (device == null)
                    throw new InvalidOperationException($"Device with ID {bookingModel.MaThietBi} does not exist");

                //if (device.TrangThai != "Có sẵn")
                //    throw new InvalidOperationException($"Device with ID {bookingModel.MaThietBi} is not available");

                var conflictingBookings = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaThietBi == bookingModel.MaThietBi)
                    .Where(p => p.TrangThai == "Đang mượn")
                    .Where(p =>
                        (p.ThoiGianMuon <= bookingModel.ThoiGianMuon && p.ThoiGianTra > bookingModel.ThoiGianMuon) ||
                        (p.ThoiGianMuon < bookingModel.ThoiGianTra && p.ThoiGianTra >= bookingModel.ThoiGianTra) ||
                        (p.ThoiGianMuon >= bookingModel.ThoiGianMuon && p.ThoiGianTra <= bookingModel.ThoiGianTra)
                    )
                    .ToListAsync();

                if (conflictingBookings.Any())
                    throw new InvalidOperationException("The device is already booked for the selected time period");

                decimal hourlyRate = device.GiaMuon;
                bookingModel.TongTien = hourlyRate;

                bookingModel.TrangThai = "Đã đặt chỗ";

                await _context.PhieuMuonThietBiModels.AddAsync(bookingModel);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error in SaveDeviceBooking: {ex.Message}");
                return false;
            }
        }

        public async Task<List<PhieuMuonThietBiModel>> GetUserReturnedDevices(int userId)
        {
            try
            {
                var returnedDevices = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai == "Đã trả")
                    .Include(p => p.ThietBi)  
                    .Include(p => p.NguoiDung) 
                    .OrderByDescending(p => p.ThoiGianTra) 
                    .ToListAsync();

                return returnedDevices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserReturnedDevices: {ex.Message}");
                return new List<PhieuMuonThietBiModel>();
            }
        }

        public async Task<bool> ConfirmBooking(int bookingId)
        {
            try
            {
                var booking = await _context.PhieuMuonThietBiModels
                    .FirstOrDefaultAsync(p => p.MaPhieuMuonThietBi == bookingId && p.TrangThai == "Đã đặt chỗ");

                if (booking == null)
                    return false;

                booking.TrangThai = "Đang mượn";
                _context.PhieuMuonThietBiModels.Update(booking);

                // Cập nhật trạng thái thiết bị nếu cần
                var device = await _context.ThietBiModels.FirstOrDefaultAsync(d => d.MaThietBi == booking.MaThietBi);
                if (device != null)
                {
                    device.TrangThai = "Đang sử dụng";
                    _context.ThietBiModels.Update(device);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ConfirmBooking: {ex.Message}");
                return false;
            }
        }

        public async Task<List<PhieuMuonThietBiModel>> GetUserReservedDevices(int userId)
        {
            try
            {
                var reservedDevices = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai.Equals("Đã đặt chỗ"))
                    .Include(p => p.ThietBi)  
                    .Include(p => p.NguoiDung) 
                    .OrderByDescending(p => p.ThoiGianMuon) 
                    .ToListAsync();

                return reservedDevices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserReservedDevices: {ex.Message}");
                return new List<PhieuMuonThietBiModel>();
            }
        }

    }

    }

