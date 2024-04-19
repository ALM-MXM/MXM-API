using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Entities.Models
{
    public class SendEmail
    {
        public string Name { get; set; } = null!;
        public string AdressDestination { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
