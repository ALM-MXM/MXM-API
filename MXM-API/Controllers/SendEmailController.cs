using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MXM.Entities.Models;
using MXM.Infrastructure.Messaging.Contracts;
using MXM.Infrastructure.Validators.ExtensionValidators;


namespace MXM_API.Controllers
{
    [Controller]
    [Route("mxm-api/[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly IValidator<SendEmail> _validatorSendEmail;
        private readonly IRabbitMQRepository _rabbitMQRepository;
        const string sendEmailRoutingKey = "queueSendEmails";
        public SendEmailController(IValidator<SendEmail> validatorSendEmail, IRabbitMQRepository rabbitMQRepository)
        {
            _validatorSendEmail = validatorSendEmail;
            _rabbitMQRepository = rabbitMQRepository;
        }

        [HttpPost]        
        public async Task<IActionResult> SendEmail([FromBody] SendEmail sendEmail)
        {
            try
            {
                var result = await _validatorSendEmail.ValidateAsync(sendEmail);
                if (!result.IsValid)
                    return BadRequest(new { Errors = result.Errors.CustomValidatorFailures() });
                var resultAddEmailInQueue = await _rabbitMQRepository.Publisher(sendEmail, sendEmailRoutingKey);
                if (resultAddEmailInQueue)
                    return Ok(new { StatusCode = 200, Message = "E-mail enviado com sucesso" });
                return BadRequest(new { StatusCode = 400, Message = "E-mail não enviado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = $"E-mail não enviado: {ex.Message}" });
            }
        }
    }
}

