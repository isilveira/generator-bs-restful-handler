using BAYSOFT.Abstractions.Core.Domain.Services;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>
{
    public class Post<%= _Entity %>Service : DomainService<<%= _Entity %>>, IPost<%= _Entity %>Service
    {
        private I<%= _Context %>DbContext Context { get; set; }
        public Post<%= _Entity %>Service(
            I<%= _Context %>DbContext context,
            <%= _Entity %>Validator entityValidator,
            Post<%= _Entity %>SpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(<%= _Entity %> entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.<%= _Collection %>.AddAsync(entity);
        }
    }
}
