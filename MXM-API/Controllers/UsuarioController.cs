using Microsoft.AspNetCore.Mvc;
using MXM.Entities.Models;
using MXM.Infrastructure.Services.UsuarioServices;

namespace MXM_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly GravarUsuarioService _gravarUsuarioService;
        public UsuarioController(GravarUsuarioService gravarUsuarioService)
        {
            _gravarUsuarioService = gravarUsuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> GravarUsuario(Usuario usuarioDto)
        {
            await _gravarUsuarioService.GravarUsuario(usuarioDto);
            return Ok();
        }
    }
}
