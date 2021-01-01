using <%= _ProjectName %>.Middleware.AddServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper.Middleware;
using System;
using System.Reflection;

namespace <%= _ProjectName %>.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
        {
            services.AddLocalization();

            services.AddDbContexts(configuration, presentationAssembly);
            services.AddSpecifications();
            services.AddEntityValidations();
            services.AddDomainValidations();
            services.AddDomainServices();

            var assembly = AppDomain.CurrentDomain.Load("<%= _ProjectName %>.Core.Application");

            services.AddMediatR(assembly);

            services.AddModelWrapper()
                .Add<%= _Context %>ReturnedCollectionSize(10)
                .AddMinimumReturnedCollectionSize(1)
                .AddMaximumReturnedCollectionSize(100)
                .AddQueryTermsMinimumSize(3)
                .AddSuppressedTerms(new string[] { "the" });

            // YOUR CODE GOES HERE
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            var supportedCultures = new string[] { "en-US", "pt-BR" };

            var localizationOptions = new RequestLocalizationOptions()
                .Set<%= _Context %>Culture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            
            app.UseRequestLocalization(localizationOptions);

            //app.UseAuthentication();
            //app.UseAuthorization();
            // YOUR CODE GOES HERE
            return app;
        }
    }
}
