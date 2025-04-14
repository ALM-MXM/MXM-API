using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Entities.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public string Sobrenome { get; set; } = string.Empty!;
        public string Telefone { get; set; } = string.Empty!;
    }
}
