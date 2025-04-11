using Microsoft.EntityFrameworkCore;
using MXM.Infrastructure.Extensions;


namespace MXM.Infrastructure.Data.ContextConfig
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            AdicionarMapeamentosDbContext.InjetarMapeamentosDbContext(builder);
        }
    }
}
