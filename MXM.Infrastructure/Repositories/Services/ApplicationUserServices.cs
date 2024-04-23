using Microsoft.AspNetCore.Identity;
using MXM.Entities.Models;
using MXM.Infrastructure.Repositories.Contracts;


namespace MXM.Infrastructure.Repositories.Services
{
    internal class ApplicationUserServices : IApplicationUserRepository
    {        
        private readonly UserManager<ApplicationUser> _userManager;        

        public ApplicationUserServices(UserManager<ApplicationUser> userManager)
        {           
            _userManager = userManager;            
        }
        public async Task<IdentityResult> CreatedApplicationUser(ApplicationUser applicationUser, string password)
        {
            var resultCreatedApplicationUser = new IdentityResult();
            try
            {
                resultCreatedApplicationUser = await _userManager.CreateAsync(applicationUser, password);
                return resultCreatedApplicationUser;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
