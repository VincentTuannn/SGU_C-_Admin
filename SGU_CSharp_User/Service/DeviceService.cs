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

        public async  Task<List<PhieuMuonThietBiModel>> GetUserBorrowedDevices(int userId)
        {
            try
            {
                var reservedDevices = await _context.PhieuMuonThietBiModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai == "Đã đặt chỗ")
                    .Include(p => p.ThietBi)  // Include related device information
                    .Include(p => p.NguoiDung) // Include user information if needed
                    .OrderByDescending(p => p.ThoiGianMuon) // Sort by borrow time, newest first
                    .ToListAsync();

                // Make sure all devices have their names set
                foreach (var device in reservedDevices)
                {
                    // If ThietBi is not null, use its name
                    if (device.ThietBi != null)
                    {
                        //device.TenThietBi = device.ThietBi.TenThietBi;
                    }
                }

                return reservedDevices;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserBorrowedDevices: {ex.Message}");
                // Return empty list in case of error
                return new List<PhieuMuonThietBiModel>();
            }
        }
 
 
    public async Task<List<ThietBiModel>> GetAvailableDevices()
        {
            try
            {
                // Retrieve devices that are available (not currently borrowed)
                var availableDevices = await _context.ThietBiModels
                    .Where(p => p.TrangThai.Equals("Có sẵn"))
                    .ToListAsync();

                return availableDevices;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetAvailableDevices: {ex.Message}");
                // Return empty list in case of error
                return new List<ThietBiModel>();
            }
        }

        public async Task<bool> SaveDeviceBooking(PhieuMuonThietBiModel bookingModel)
        {
            // Use a transaction to ensure both operations (save booking and update device status) succeed or fail together
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Validate the booking model
                if (bookingModel == null)
                    throw new ArgumentNullException(nameof(bookingModel), "Booking model cannot be null");

                if (bookingModel.MaThietBi <= 0)
                    throw new ArgumentException("Invalid device ID", nameof(bookingModel.MaThietBi));

                if (bookingModel.MaNguoiDung <= 0)
                    throw new ArgumentException("Invalid user ID", nameof(bookingModel.MaNguoiDung));

                if (bookingModel.ThoiGianMuon >= bookingModel.ThoiGianTra)
                    throw new ArgumentException("Start time must be before end time");

                // Check if device exists and is available
                var device = await _context.ThietBiModels
                    .FirstOrDefaultAsync(d => d.MaThietBi == bookingModel.MaThietBi);

                if (device == null)
                    throw new InvalidOperationException($"Device with ID {bookingModel.MaThietBi} does not exist");

                if (device.TrangThai != "Có sẵn")
                    throw new InvalidOperationException($"Device with ID {bookingModel.MaThietBi} is not available");

                // Check for conflicting bookings
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

                // Calculate total cost based on device rental price and duration
                decimal hourlyRate = device.GiaMuon;
                bookingModel.TongTien = hourlyRate;

                // Set default values for the booking
                bookingModel.TrangThai = "Đã đặt chỗ";

                // Save the booking
                await _context.PhieuMuonThietBiModels.AddAsync(bookingModel);
                await _context.SaveChangesAsync();

                // Update the device status
                device.TrangThai = "Đang sử dụng";
                _context.ThietBiModels.Update(device);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Roll back the transaction in case of error
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
                    .Include(p => p.ThietBi)  // Include related device information
                    .Include(p => p.NguoiDung) // Include user information if needed
                    .OrderByDescending(p => p.ThoiGianTra) // Sort by return time, newest first
                    .ToListAsync();

                return returnedDevices;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserReturnedDevices: {ex.Message}");
                // Return empty list in case of error
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

    }

    }

