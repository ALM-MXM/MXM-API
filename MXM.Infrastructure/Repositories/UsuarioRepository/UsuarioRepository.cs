using Microsoft.EntityFrameworkCore;
using MXM.Entities.Models;
using MXM.Infrastructure.Data.ContextConfig;
using MXM.Infrastructure.Repositories.BaseRepository;

namespace MXM.Infrastructure.Repositories.UsuarioRepository
{
    public class UsuarioRepository<T> : BaseRepository<Usuario> where T : DataContext
    {
        public UsuarioRepository(T dataContext) : base(dataContext)
        {

        }

        public async Task<List<Usuario>> ObterListaDeUsuarioAsNoTraking()
        {
            return await DbSet.AsNoTracking().OrderBy(u => u.Nome).Skip(1).Take(100).ToListAsync();
        }

        public async Task<List<Usuario>> ObterListaDeUsuarioComum()
        {
            return await DbSet.OrderBy(u => u.Nome).Skip(1).Take(100).ToListAsync();
        }
    }
}
