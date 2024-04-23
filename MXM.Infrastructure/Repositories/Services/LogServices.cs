using Microsoft.EntityFrameworkCore;
using MXM.Entities.Models;
using MXM.Infrastructure.Data;
using MXM.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Repositories.Services
{
    internal class LogServices : ILogRepository
    {
        private readonly DataContext _dataContext;
        public LogServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreatedLogSendEmail(SendEmailLog sendEmailLog)
        {
            try
            {
                _dataContext.SendEmailLogs.Add(sendEmailLog);
               var lines =  await _dataContext.SaveChangesAsync();
                return lines > 0;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ICollection<SendEmailLog>> GetLogSendEmailPeriod(DateTime initialDate, DateTime finalDate)
        {
           return  await _dataContext.SendEmailLogs.Where(l=> l.DateCreated>=initialDate && l.DateCreated<=finalDate).ToListAsync();
        }
    }
}
