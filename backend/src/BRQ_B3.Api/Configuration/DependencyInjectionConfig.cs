using BRQ_B3.Business.Intefaces;
using BRQ_B3.Business.Services;
using BRQ_B3.Data.Context;
using BRQ_B3.Data.Repository;

namespace BRQ_B3.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICalculoCDBRepository, CalculoCDBRepository>();
            services.AddScoped<ICalculoCDBService, CalculoCDBService>();

            return services;
        }
    }
}