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
                var borrowedDevices = _context.PhieuMuonThietBiModels
                    .Where(p => p.MaNguoiDung == userId)
                    .Where(p => p.TrangThai.Equals("Đang mượn"))
                    .Include(p => p.ThietBi)  // Include related device information
                    .Include(p => p.NguoiDung) // Include user information if needed
                    .OrderByDescending(p => p.ThoiGianMuon) // Sort by borrow time, newest first
                    .ToList();

                // Make sure all devices have their names set
                foreach (var device in borrowedDevices)
                {
                    // If ThietBi is not null, use its name
                    if (device.ThietBi != null)
                    {
                        //device.TenThietBi = device.ThietBi.TenThietBi;
                    }
                }

                return borrowedDevices;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserBorrowedDevices: {ex.Message}");
                // Return empty list in case of error
                return new List<PhieuMuonThietBiModel>();
            }
        }

    }
}
