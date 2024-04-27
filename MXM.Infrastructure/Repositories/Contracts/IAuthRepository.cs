using MXM.Entities.DTOs.ApplicationUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Repositories.Contracts
{
    public interface IAuthRepository
    {
        Task<UsuarioLogadoDTO?> AuthApplicationUser(string email, string password);       
    }
}
