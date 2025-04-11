using MXM.Entities.Models;
using MXM.Infrastructure.Data.ContextConfig;
using MXM.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Repositories.UsuarioRepository
{
    public class UsuarioRepository<T> : BaseRepository<Usuario> where T : DataContext
    {
        public UsuarioRepository(T dataContext) : base(dataContext)
        {

        }
    }
}
