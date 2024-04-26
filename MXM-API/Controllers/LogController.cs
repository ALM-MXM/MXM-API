using Microsoft.AspNetCore.Mvc;
using MXM.Infrastructure.Repositories.Contracts;

namespace MXM_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        public LogController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        [HttpGet("period")]
        public async Task<IActionResult> GetLogSendEmailPeriod(string dateInitial, string dateFinal)
        {
            var dateInitialFormating = DateTime.Parse(dateInitial);
            var dateFinalFormating = DateTime.Parse(dateFinal).AddDays(1).AddTicks(-1);
            var listLogsAnalyse =  await _logRepository.GetLogSendEmailPeriod(dateInitialFormating, dateFinalFormating);
            return Ok(listLogsAnalyse);
        }
    }
}
