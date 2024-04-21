using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MXM.Entities.Models;
using MXM.Infrastructure.Messaging.Contracts;
using MXM.Infrastructure.Messaging.Services;
using MXM.Infrastructure.Validators;


namespace MXM.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ValidatorModule();
            services.RabbitMQMessageSevices();           
            return services;
        }

        private static IServiceCollection ValidatorModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<SendEmail>, SendEmailValidator>();
            return services;
        }
        private static IServiceCollection RabbitMQMessageSevices(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQMessageRepository, RabbitMQMessageServices>();
            services.AddSingleton<IRabbitMQConnectionRepository, RabbitMQConnectionServices>();
            return services;
        }
                
    }
}
