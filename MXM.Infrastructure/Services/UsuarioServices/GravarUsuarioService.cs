using MXM.Entities.Models;
using MXM.Infrastructure.Data.ContextConfig;
using MXM.Infrastructure.Repositories.UsuarioRepository;

namespace MXM.Infrastructure.Services.UsuarioServices
{
    public class GravarUsuarioService
    {
        private readonly UsuarioRepository<DataContext> _usuarioRepository;
        public GravarUsuarioService(UsuarioRepository<DataContext> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //public async Task GravarUsuario(Usuario usuario)
        //{
        //    var listaDeUsuario = new List<Usuario>();

        //    for (int i = 0; i < 10000000; i++)
        //    {
        //        var usuarioDbInsert = new Usuario
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Nome = $"João_{i}",
        //            Sobrenome = $"Silva_{i}",
        //            Email = "email-@email.com",
        //            Telefone = "11999999999",
        //            Password = "senha123@12321",
        //            Ativo = true
        //        };
        //        listaDeUsuario.Add(usuarioDbInsert);
        //    }
        //    await _usuarioRepository.DbSet.AddRangeAsync(listaDeUsuario);
        //    await _usuarioRepository.DbContext.SaveChangesAsync();
        //}
    }
}
