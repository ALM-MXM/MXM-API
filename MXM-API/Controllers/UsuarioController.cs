using Microsoft.AspNetCore.Mvc;
using MXM.Entities.Models;
using MXM.Infrastructure.Services.ReturnPadraoServices;
using MXM.Infrastructure.Services.UsuarioServices;
using System.Diagnostics;

namespace MXM_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly GravarUsuarioService _gravarUsuarioService;
        private readonly ObterUsuarioService _obterUsuarioService;
        public UsuarioController(
              GravarUsuarioService gravarUsuarioService
            , ObterUsuarioService obterUsuarioService)
        {
            _gravarUsuarioService = gravarUsuarioService;
            _obterUsuarioService = obterUsuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> GravarUsuario(Usuario usuarioDto)
        {
            // await _gravarUsuarioService.GravarUsuario(usuarioDto);
            return Ok();
        }

        [HttpGet("asnotraking")]
        public async Task<IActionResult> ObterUsuarioAsNoTrackingAsync()
        {          
            await _obterUsuarioService.ObterUsuariosAsNotracking();          
            return _obterUsuarioService.Retornar(this); 
        }
        [HttpGet("GetNormal")]
        public async Task<IActionResult> ObterUsuarioComumSemAsNoTraking()
        {            
            await _obterUsuarioService.ObterUsuariosComum(); 
            return _obterUsuarioService.Retornar(this);
        }
    }
}
