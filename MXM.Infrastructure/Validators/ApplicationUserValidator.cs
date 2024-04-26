using FluentValidation;
using MXM.Entities.Models;

namespace MXM.Infrastructure.Validators
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
            RuleFor(u=> u.FirstName)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(u=> u.LastName)
                .NotEmpty()
                .MinimumLength(3);            
        }
    }
}
