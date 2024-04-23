using System.ComponentModel.DataAnnotations;


namespace MXM.Entities.DTOs.ApplicationUserDTOs
{
    public class ApplicationUserAuthDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
