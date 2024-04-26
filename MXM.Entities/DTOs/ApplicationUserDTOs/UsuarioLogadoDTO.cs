
namespace MXM.Entities.DTOs.ApplicationUserDTOs
{
    public class UsuarioLogadoDTO
    {
        public string Id { get; set; } = null!;
        public string PrimeiroNome { get; set; } = null!;
        public string UltimoNome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
