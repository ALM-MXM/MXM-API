using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Middlewares
{
    public class TempoRespostaMetodsHttpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TempoRespostaMetodsHttpMiddleware> _logger;

        public TempoRespostaMetodsHttpMiddleware(RequestDelegate next, ILogger<TempoRespostaMetodsHttpMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // segue para o restante do pipeline (inclui controllers, etc)
            await _next(context);

            stopwatch.Stop();

            var tempoMs = stopwatch.ElapsedMilliseconds;
            var path = context.Request.Path;
            var metodo = context.Request.Method;
            var statusCode = context.Response.StatusCode;

            _logger.LogInformation("[{Metodo}] {Path} - {StatusCode} - {Tempo}ms",
                metodo, path, statusCode, tempoMs);
        }
    }
}
