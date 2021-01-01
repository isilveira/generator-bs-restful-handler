using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace <%= _ProjectName %>.Middleware.AddServices
{
    public static class AddDbContextConfigurations
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
        {
            services.AddDbContext<I<%= _Context %>DbContext, <%= _Context %>DbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("<%= _Context %>Connection"),
                    sql => sql.MigrationsAssembly(presentationAssembly.GetName().Name)));

            services.AddDbContext<I<%= _Context %>DbContextQuery, <%= _Context %>DbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("<%= _Context %>Connection"),
                    sql => sql.MigrationsAssembly(presentationAssembly.GetName().Name)));

            return services;
        }
    }
}
