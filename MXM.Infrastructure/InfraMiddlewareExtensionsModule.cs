using Microsoft.AspNetCore.Builder;
using MXM.Infrastructure.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure
{
    public static class InfraMiddlewareExtensionsModule
    {

        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<TempoRespostaMetodsHttpMiddleware>();             

            return app;
        }
    }
}
