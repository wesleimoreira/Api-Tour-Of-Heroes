using Api_Tour_Of_Heroes_Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Api_Tour_Of_Heroes_Infrastructure.Repositories;

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

            services.AddScoped<IHeroRepositoty, HeroRepository>();
        }
    }
}
