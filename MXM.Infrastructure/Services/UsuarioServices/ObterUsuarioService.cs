using MXM.Infrastructure.Data.ContextConfig;
using MXM.Infrastructure.Repositories.UsuarioRepository;
using MXM.Infrastructure.Services.ReturnPadraoServices;
using MXM.Infrastructure.Services.ReturnPadraoServices.InterfacesServicoPadrao;

namespace MXM.Infrastructure.Services.UsuarioServices
{
    public class ObterUsuarioService : ServicoRetornoPadrao, IServicoComBuscaPadrao
    {
        private readonly UsuarioRepository<DataContext> _usuarioRepository;
        public ObterUsuarioService(UsuarioRepository<DataContext> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Encontrado { get ; set ; }

        public async Task ObterUsuariosAsNotracking()
        {
            var listaUsuariosNoTracking = await _usuarioRepository.ObterListaDeUsuarioAsNoTraking();
            Encontrado = true;
            Retorno = listaUsuariosNoTracking;
        }
        public async Task ObterUsuariosComum()
        {
            var listaUsuariosMetodoComum = await _usuarioRepository.ObterListaDeUsuarioComum();
            Encontrado = true;
            Retorno = listaUsuariosMetodoComum;
        }       
    }
}
