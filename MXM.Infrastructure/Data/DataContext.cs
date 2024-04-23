using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MXM.Entities.Models;


namespace MXM.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SendEmailLog> SendEmailLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SendEmailLog>()
                .HasKey(e => e.LogId);
            builder.Entity<SendEmailLog>()
                .Property(e => e.LogId)
                .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);
        }
    }
}
