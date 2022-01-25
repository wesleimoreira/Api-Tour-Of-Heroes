using Api_Tour_Of_Heroes_Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Tour_Of_Heroes_Application.DependencyInjections
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
