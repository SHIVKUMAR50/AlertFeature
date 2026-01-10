using Infrastructure.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AlertDbContext : DbContext
    {
        public AlertDbContext(){}

        public AlertDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlertInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ReleaseInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserAlertHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<AlertCategory> AlertCategory { get; set; }
        public DbSet<AlertInfo> AlertInfo { get; set; }
        public DbSet<MaintenanceInfo> MaintenanceInfo { get; set; }
        public DbSet<ReleaseInfo> ReleaseInfo { get; set; }
        public DbSet<UserAlertHistory> UserAlertHistory { get; set; }
        public DbSet<Users>Users { get; set; }


    }
}
