using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MXM.Entities.Models;
using MXM.Infrastructure.Messaging.Contracts;
using MXM.Infrastructure.Repositories.Contracts;
using MXM.Infrastructure.Validators.ExtensionValidators;
using MXM_API.Extensions;
using System.Text.Json;


namespace MXM_API.Controllers
{
    [Controller]
    [Route("mxm-api/[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly IValidator<SendEmail> _validatorSendEmail;
        private readonly IRabbitMQMessageRepository _rabbitMQRepository;
        const string sendEmailRoutingKey = "queueSendEmails";
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogRepository _logRepository;
        public SendEmailController(
            IValidator<SendEmail> validatorSendEmail,
            IRabbitMQMessageRepository rabbitMQRepository,
            IHttpContextAccessor contextAccessor
            ,ILogRepository logRepository)
        {
            _validatorSendEmail = validatorSendEmail;
            _rabbitMQRepository = rabbitMQRepository;
            _contextAccessor = contextAccessor;
            _logRepository = logRepository;
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
                {   //TODO - Salvar Log do envio no MongoDB
                    var clientIpAdress = GetClientIPAdress.GetClientIPAddress(_contextAccessor.HttpContext);
                    var log = new SendEmailLog() { IpAdressClientRequest = clientIpAdress, DateCreated = DateTime.Now,Content = JsonSerializer.Serialize(sendEmail)};
                    await _logRepository.CreatedLogSendEmail(log);
                    return Ok(new { StatusCode = 200, Message = "E-mail enviado com sucesso" });                   
                }                    
                return BadRequest(new { StatusCode = 400, Message = "E-mail não enviado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = $"E-mail não enviado: {ex.Message}" });
            }
        }
    }
}

