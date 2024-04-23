using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MXM.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MinLength(3, ErrorMessage ="Nome precisa conter no minímo 3 caracteres")]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Sobrenome precisa conter no minímo 3 caracteres")]
        public string LastName { get; set; } = null!;
    }
}
