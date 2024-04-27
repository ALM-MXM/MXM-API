using System.ComponentModel.DataAnnotations;


namespace MXM.Entities.DTOs.ApplicationUserDTOs
{
    public class AutenticacaoUsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Senha { get; set; } = null!;
    }
}





