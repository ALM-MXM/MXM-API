using MXM.Entities.Models;


namespace MXM.Infrastructure.Repositories.Contracts
{
    public interface ILogRepository
    {
        Task<bool> CreatedLogSendEmail(SendEmailLog sendEmailLog);
        Task<ICollection<SendEmailLog>> GetLogSendEmailPeriod(DateTime initialDate, DateTime finalDate);
    }
}
