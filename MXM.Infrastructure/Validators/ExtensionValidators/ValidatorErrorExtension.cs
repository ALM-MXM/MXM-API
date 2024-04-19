using FluentValidation.Results;
using MXM.Entities.Models;


namespace MXM.Infrastructure.Validators.ExtensionValidators
{
    public  static class ValidatorErrorExtension
    {
        public static IList<CustomValidatorFailure> CustomValidatorFailures(this IList<ValidationFailure> failures)
        {
            return failures.Select(x => new CustomValidatorFailure(x.PropertyName, x.ErrorMessage)).ToList();
        }
    }
}
