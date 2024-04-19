using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MXM.Entities.Models;
using MXM.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ValidatorModule();
            return services;
        }

        public static IServiceCollection ValidatorModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<SendEmail>, SendEmailValidator>();
            return services;
        }
    }
}
