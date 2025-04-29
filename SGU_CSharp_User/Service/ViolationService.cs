using Microsoft.EntityFrameworkCore;
using SGU_CSharp_User.Data;
using SGU_CSharp_User.Model;

namespace SGU_CSharp_User.Service
{
    public class ViolationService
    {
        private readonly ApplicationDbContext _context;

        public ViolationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViPhamModel>> GetUserViolations(int userId)
        {
            try
            {
                // Query violations where the MaNguoiDung matches the userId
                var violations = await _context.ViPhamModels
                    .Where(v => v.MaNguoiDung == userId)
                    .Include(v => v.ThietBi)  // Include related device information
                    .Include(v => v.Phong)    // Include related room information
                    .Include(v => v.NguoiDung) // Include user information if needed
                    .OrderByDescending(v => v.MaViPham) // Order by violation ID, assuming newer violations have higher IDs
                    .AsNoTracking() // Improve performance for read-only operations
                    .ToListAsync();

                return violations;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in GetUserViolations: {ex.Message}");

                // Return empty list in case of error
                return new List<ViPhamModel>();
            }
        }


    }
}
