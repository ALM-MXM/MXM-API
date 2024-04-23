using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Entities.Models
{
    public class CustomValidatorFailure
    {
        public CustomValidatorFailure(string propertyName, string ErroMessage)
        {
            this.PropertyName = propertyName;
            this.ErroMessage = ErroMessage;
        }
        public string PropertyName { get; set; } = null!;
        public string ErroMessage { get; set; } = null!;
    }
}
