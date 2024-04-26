using FluentValidation;
using MXM.Entities.Models;
using MXM.Infrastructure.Validators.ExtensionValidators;

namespace MXM.Infrastructure.Validators
{
    public class SendEmailValidator : AbstractValidator<SendEmail>
    {
        public SendEmailValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .WithMessage("Nome precisa ser preenchido")
                .MinimumLength(3)
                .WithMessage("Nome precisa ter no mínimo 3 caracteres")
                .Must(fr => fr.ValidateContentWordsInaproprieted())
                .WithMessage("O nome Fornecido contém palavras inapropriadas");

            RuleFor(e => e.EnderecoDestino)
                .NotEmpty()
                .WithMessage("O E-mail não pode ser vazio")
                .EmailAddress()
                .WithMessage("Formato do E-mail  é inválido!")
                .Must(fr => fr.ValidateContentWordsInaproprieted())
                .WithMessage("O E-mail fornecido contém palavras inapropriadas");

            RuleFor(e => e.Corpo)
                .NotEmpty()
                .WithMessage("Mensagem precisa ser preenchida")
                .Must(e => e.ValidateEmailBodyIsHtml())
                .WithMessage("O corpo da mensagem tem que ser no formato HTML")
                .Must(e => e.ValidateContentWordsInaproprieted())
                .WithMessage("Sua mensagem possui caracterista inapropridas, e não foi enviada");
        }
       
    }
}
