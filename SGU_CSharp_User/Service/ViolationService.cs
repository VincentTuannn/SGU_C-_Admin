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
                var violations = await _context.ViPhamModels
                    .Where(v => v.MaNguoiDung == userId)
                    .Include(v => v.ThietBi)  
                    .Include(v => v.Phong)  
                    .Include(v => v.NguoiDung) 
                    .OrderByDescending(v => v.MaViPham) 
                    .AsNoTracking() 
                    .ToListAsync();

                return violations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserViolations: {ex.Message}");
                return new List<ViPhamModel>();
            }
        }


    }
}
