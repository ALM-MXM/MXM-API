using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MXM.Entities.Models;
using MXM.Infrastructure.Data;
using MXM.Infrastructure.Messaging.Contracts;
using MXM.Infrastructure.Messaging.Services;
using MXM.Infrastructure.Repositories.Contracts;
using MXM.Infrastructure.Repositories.Services;
using MXM.Infrastructure.Validators;
using System.Text;


namespace MXM.Infrastructure
{
    public static class InfrastructureModule
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RepositoriesModule();
            services.DbContextModule(configuration);
            services.AuthenticationAndAuthorizationModule(configuration);
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
        private static IServiceCollection DbContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DbKingHostConnect"));
            });
            return services;
        }

        private static IServiceCollection RepositoriesModule(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IApplicationUserRepository, ApplicationUserServices>();
            services.AddScoped<IAuthRepository, AuthServices>();
            services.AddScoped<ILogRepository, LogServices>();
            return services;
        }

        private static IServiceCollection AuthenticationAndAuthorizationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

             }).AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateAudience = false,
                     ValidateIssuer = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                 };
             });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });
            return services;
        }

    }
}
