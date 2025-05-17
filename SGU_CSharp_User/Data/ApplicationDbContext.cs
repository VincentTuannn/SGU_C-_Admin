using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGU_CSharp_User.Model;
namespace SGU_CSharp_User.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<NguoiDungModel> Users { get; set; }
        public DbSet<CheckInModel> checkInModels { get; set; }
        public DbSet<PhongModel> PhongModels { get; set; }
        public DbSet<ThietBiModel> ThietBiModels { get; set; }
        public DbSet<PhieuMuonPhongModel> PhieuMuonPhongModels { get; set; }
        public DbSet<PhieuMuonThietBiModel> PhieuMuonThietBiModels { get; set; }
        public DbSet<PhieuTraModel> PhieuTraModels { get; set; }
        public DbSet<ViPhamModel> ViPhamModels { get; set; }
        public DbSet<ThongBaoModel> ThongBaoModels { get; set; }
        public DbSet<ThanhToanModel> ThanhToanModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhieuMuonThietBiModel>()
                .Property(p => p.TongTien)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<ThietBiModel>()
                .Property(t => t.GiaMuon)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<PhieuTraModel>()
                .Property(p => p.TongTienPhaiTra)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<PhieuTraModel>()
                .Property(p => p.TienPhat)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<ThanhToanModel>()
                .Property(p => p.TongTienPhaiTra)
                .HasColumnType("decimal(18,0)");
            modelBuilder.Entity<PhongModel>()
                .Property(p => p.GiaMuon)
                .HasColumnType("decimal(18,0)");            
            modelBuilder.Entity<PhieuMuonPhongModel>()
                .Property(p => p.TongTien)
                .HasColumnType("decimal(18,0)");




        }
    }

}
