using System.Text;
using Microsoft.EntityFrameworkCore;
using Api_Tour_Of_Heroes_Domain.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Api_Tour_Of_Heroes_Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api_Tour_Of_Heroes_Infrastructure.DependencyInjections
{
    public static class InfrastructureDependencyInjection
    {
        public static void AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("StringConnection"));
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("JWTSECRET").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
