using DataLayer.DbModel;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Implementation;
using ServiceLayer.Interfaces;

namespace DependencyRegistration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }

        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ITodoContext, TodoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TodoContext")));

            return services;
        }
    }
}
