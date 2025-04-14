using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Entities.Models
{
    public class Usuario
    {
        private string _senhaHash = string.Empty; 
        public string Id { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public string Sobrenome { get; set; } = string.Empty!;
        public string Telefone { get; set; } = string.Empty!;
        public string Password
        {
            get => _senhaHash;
            set => _senhaHash = GerarHash(value);
        }
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; } = false; 
        private string GerarHash(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
