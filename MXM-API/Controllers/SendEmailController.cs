using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MXM.Entities.Models;
using MXM.Infrastructure.Validators.ExtensionValidators;


namespace MXM_API.Controllers
{
    [Controller]
    [Route("mxm-api/[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly IValidator<SendEmail> _validatorSendEmail;
        public SendEmailController(IValidator<SendEmail> validatorSendEmail)
        {
            _validatorSendEmail = validatorSendEmail;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] SendEmail sendEmail)
        {
            var result = await _validatorSendEmail.ValidateAsync(sendEmail);
            if (!result.IsValid)                             
                return BadRequest(result.Errors.CustomValidatorFailures());   
            
            return Ok("E-mail enviado com sucesso");
        }
    }
}
