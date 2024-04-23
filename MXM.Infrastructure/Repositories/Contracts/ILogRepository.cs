using MXM.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Repositories.Contracts
{
    public interface ILogRepository
    {
        Task<bool> CreatedLogSendEmail(SendEmailLog sendEmailLog);
        Task<ICollection<SendEmailLog>> GetLogSendEmailPeriod(DateTime initialDate, DateTime finalDate);
    }
}
