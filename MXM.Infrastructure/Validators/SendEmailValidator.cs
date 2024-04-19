using FluentValidation;
using MXM.Entities.Models;
using MXM.Infrastructure.Validators.ExtensionValidators;
using System.Text.RegularExpressions;


namespace MXM.Infrastructure.Validators
{
    public class SendEmailValidator : AbstractValidator<SendEmail>
    {
        public SendEmailValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Nome precisa ser preenchido")
                .MinimumLength(3)
                .WithMessage("Nome precisa ter no mínimo 3 caracteres");

            RuleFor(e => e.AdressDestination)
                .NotEmpty()
                .WithMessage("O E-mail não pode ser vazio")
                .EmailAddress()
                .WithMessage("Formato do E-mail  é inválido!");

            RuleFor(e => e.Body)
                .NotEmpty()
                .WithMessage("Mensagem precisa ser preenchida")
                .Must(e => e.ValidateEmailBodyIsHtml())
                .WithMessage("O corpo da mensagem tem que ser no formato HTML")
                .Must(e => e.ValidateEmailMessageIsInappropriate())
                .WithMessage("Sua mensagem possui caracterista inapropridas, e não foi enviada");
        }
       
    }
}
