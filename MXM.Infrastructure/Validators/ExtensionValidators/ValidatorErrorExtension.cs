using FluentValidation.Results;
using MXM.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
