using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MXM.Entities.DTOs.ApplicationUserDTOs;
using MXM.Entities.Models;
using MXM.Infrastructure.Data;
using MXM.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MXM.Infrastructure.Repositories.Services
{
    internal class AuthServices : IAuthRepository
    {
        private readonly SignInManager<ApplicationUser> _sigInManager;
        private readonly DataContext _data;
        private readonly IConfiguration _configuration;
        public AuthServices(SignInManager<ApplicationUser> signInManager , IConfiguration configuration , DataContext dataContext)
        {
            _sigInManager = signInManager;
            _data = dataContext;
            _configuration = configuration;
        }
        public async Task<ApplicationUserLoggedDTO> AuthApplicationUser(string email, string password)
        {
            var result = await _sigInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {                
                return await CreatedToken(email);
            }
            else
            {
                return null;
            }
        }
        private async Task<ApplicationUserLoggedDTO> CreatedToken(string applicationUserEmail)
        {
            var applicationLogin = _data.ApplicationUsers.Where(user => user.Email == applicationUserEmail).FirstOrDefault();
            if (applicationLogin != null)
            {
                var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, applicationLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expirationGet = _configuration["TokenConfiguration:ExpireHours"];
                var expiration = DateTime.UtcNow.AddHours(double.Parse(expirationGet));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["TokenConfiguration:Issuer"],
                    audience: _configuration["TokenConfiguration:Audience"],
                    claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );                
                return new ApplicationUserLoggedDTO()
                {
                    Id = applicationLogin.Id,
                    FirstName = applicationLogin.FirstName,
                    LastName = applicationLogin.LastName,
                    Email=applicationLogin.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)  
                };
            }
            throw new Exception("Usuário não localziado");
        }
    }
}
