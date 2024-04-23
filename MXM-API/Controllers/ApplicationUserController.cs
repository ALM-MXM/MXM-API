using Microsoft.AspNetCore.Mvc;
using MXM.Entities.DTOs.ApplicationUserDTOs;
using MXM.Entities.Models;
using MXM.Infrastructure.Repositories.Contracts;

namespace MXM_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ApplicationUserController:ControllerBase
    {
        private readonly IApplicationUserRepository _userRepository;
        public ApplicationUserController(IApplicationUserRepository applicationUserRepository)
        {
            _userRepository = applicationUserRepository;
        }

        [HttpPost("created")]
        public async Task<IActionResult> CreatedApplicationUser([FromBody] ApplicationUserCreatedDTO applicationUserCreatedDTO)
        {

            if(!ModelState.IsValid) return BadRequest(ModelState);
            var applicationUserCreated = new ApplicationUser()
            {
                FirstName = applicationUserCreatedDTO.FirstName,
                LastName = applicationUserCreatedDTO.LastName,
                Email = applicationUserCreatedDTO.Email,
                UserName = applicationUserCreatedDTO.Email
            };
            var userCreateResult = await _userRepository.CreatedApplicationUser(applicationUserCreated, applicationUserCreatedDTO.Password);
            if (!userCreateResult.Succeeded)
            {
                List<string> erros = new List<string>();
                foreach (var erro in userCreateResult.Errors)
                {
                    erros.Add(erro.Description);
                }
                return UnprocessableEntity(erros);
            }

            return Ok("Usuário Criado Com Sucesso");
        }
    }
}
