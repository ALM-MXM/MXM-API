using Microsoft.AspNetCore.Identity;
using MXM.Entities.Models;

namespace MXM.Infrastructure.Repositories.Contracts
{
    public interface IApplicationUserRepository
    {
        Task<IdentityResult> CreatedApplicationUser(ApplicationUser applicationUser, string password);
    }
}
