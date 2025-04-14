using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MXM.Infrastructure.Data.ContextConfig;
using MXM.Infrastructure.Repositories.UsuarioRepository;
using MXM.Infrastructure.Services.ReturnPadraoServices;
using MXM.Infrastructure.Services.UsuarioServices;
using System.Text;


namespace MXM.Infrastructure
{
    public static class InfraServicesModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.DbContextModule(configuration);
            services.RepositoriesModule();
            services.ServicesModule();
            services.AuthenticationAndAuthorizationModule(configuration);
            return services;
        }                  
        private static IServiceCollection DbContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }

        private static IServiceCollection RepositoriesModule(this IServiceCollection services)
        {
            services.AddScoped(typeof(UsuarioRepository<DataContext>));
            return services;
        }

        private static IServiceCollection ServicesModule(this IServiceCollection services)
        {
            services.AddScoped(typeof(ServicoDeMensagem));
            services.AddScoped(typeof(ServicoRetornoPadrao));

            services.AddScoped(typeof(GravarUsuarioService));
            services.AddScoped(typeof(ObterUsuarioService));


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
