using Microsoft.EntityFrameworkCore;
using MXM.Infrastructure.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
