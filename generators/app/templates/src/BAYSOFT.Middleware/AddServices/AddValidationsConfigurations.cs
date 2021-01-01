using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;
using Microsoft.Extensions.DependencyInjection;

namespace <%= _ProjectName %>.Middleware.AddServices
{
    public static class AddValidationsConfigurations
    {
        public static IServiceCollection AddSpecifications(this IServiceCollection services)
        {
            services.AddTransient<<%= _Entity %>DescriptionAlreadyExistsSpecification>();

            return services;
        }
        public static IServiceCollection AddEntityValidations(this IServiceCollection services)
        {
            services.AddTransient<<%= _Entity %>Validator>();

            return services;
        }
        public static IServiceCollection AddDomainValidations(this IServiceCollection services)
        {
            services.AddTransient<Put<%= _Entity %>SpecificationsValidator>();
            services.AddTransient<Post<%= _Entity %>SpecificationsValidator>();
            services.AddTransient<Patch<%= _Entity %>SpecificationsValidator>();
            services.AddTransient<Delete<%= _Entity %>SpecificationsValidator>();

            return services;
        }
    }
}
