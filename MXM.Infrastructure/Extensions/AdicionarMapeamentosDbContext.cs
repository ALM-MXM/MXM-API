using Microsoft.EntityFrameworkCore;
using MXM.Infrastructure.Data.Mappings;

namespace MXM.Infrastructure.Extensions
{
    public static class AdicionarMapeamentosDbContext
    {
        public static void InjetarMapeamentosDbContext(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
