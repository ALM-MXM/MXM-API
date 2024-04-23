using FluentValidation;
using MXM.Entities.DTOs.ApplicationUserDTOs;
using MXM.Infrastructure.Validators.ExtensionValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Validators
{
    public class ApplicationUserCreateValidator: AbstractValidator<ApplicationUserCreatedDTO>
    {
        public ApplicationUserCreateValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("Nome Precisa ser preenchido")
                .MinimumLength(3)
                .WithMessage("Nome deve conter no mínio 3 caracteres")
                .Must(fr=> fr.ValidateContentWordsInaproprieted())
                .WithMessage("Seu nome contém palavras inapropriadas");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Sobrenome Precisa ser preenchido")
                .MinimumLength(3)
                .WithMessage("Sobrenome deve conter no mínio 3 caracteres")
                 .Must(fr => fr.ValidateContentWordsInaproprieted())
                .WithMessage("Seu nome contém palavras inapropriadas");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("E-mail Precisa ser preenchido")
                .EmailAddress()
                .WithMessage("Deve ser preenchido um E-mail válido")
                .Must(fr => fr.ValidateContentWordsInaproprieted())
                .WithMessage("Seu E-mail contém palavras inapropriadas");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Senha precisa ser preenchida")
                .MinimumLength(8)
                .WithMessage("Precisa conter no mínimo 8 caracteres")
                .Must(p => p.ValidateUserPassword())
                .WithMessage("Senha precisa conter, pelomenos 1 caracteres especial ,1 letra maiúscula, 1 letra minúscula e 1 número, e no mínimo 8 caracteres");
                
        }   
    }
}
