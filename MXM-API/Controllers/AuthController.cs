using Microsoft.AspNetCore.Mvc;
using MXM.Entities.DTOs.ApplicationUserDTOs;
using MXM.Infrastructure.Repositories.Contracts;

namespace MXM_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {   private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> AuthApplicationUser([FromBody]AutenticacaoUsuarioDTO applicationUserAuthDTO)
        {
           if(!ModelState.IsValid)return BadRequest(ModelState);
            var userLoggedResult = await _authRepository.AuthApplicationUser(applicationUserAuthDTO.Email, applicationUserAuthDTO.Senha);
            if (userLoggedResult != null)
                return Ok(userLoggedResult);
            return NotFound("Usuario Não Encontrado");
        }
    }
}
