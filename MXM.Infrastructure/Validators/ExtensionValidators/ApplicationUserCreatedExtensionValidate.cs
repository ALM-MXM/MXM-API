using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Validators.ExtensionValidators
{
    public static class ApplicationUserCreatedExtensionValidate
    {
        public static bool ValidateUserPassword(this string password)
        {
            var regexValidatePassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>]).{8,}$";
            var verificarPassword = Regex.IsMatch(password, regexValidatePassword);
            return verificarPassword;
        }        
    }
}
