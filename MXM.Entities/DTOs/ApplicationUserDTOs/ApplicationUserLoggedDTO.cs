﻿
namespace MXM.Entities.DTOs.ApplicationUserDTOs
{
    public class ApplicationUserLoggedDTO
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
