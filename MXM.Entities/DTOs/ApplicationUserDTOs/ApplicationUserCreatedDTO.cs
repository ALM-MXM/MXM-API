using System.ComponentModel.DataAnnotations;


namespace MXM.Entities.DTOs.ApplicationUserDTOs
{
    public class ApplicationUserCreatedDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
