using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>;
using Microsoft.Extensions.DependencyInjection;

namespace <%= _ProjectName %>.Middleware.AddServices
{
    public static class AddDomainServicesConfigurations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPut<%= _Entity %>Service, Put<%= _Entity %>Service>();
            services.AddTransient<IPost<%= _Entity %>Service, Post<%= _Entity %>Service>();
            services.AddTransient<IPatch<%= _Entity %>Service, Patch<%= _Entity %>Service>();
            services.AddTransient<IDelete<%= _Entity %>Service, Delete<%= _Entity %>Service>();

            return services;
        }
    }
}
