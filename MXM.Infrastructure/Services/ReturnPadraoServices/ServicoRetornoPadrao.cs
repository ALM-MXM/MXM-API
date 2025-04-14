using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Services.ReturnPadraoServices
{
    public class ServicoRetornoPadrao : ServicoDeMensagem
    {
        public object? Retorno { get; set; } = null;
    }
}
