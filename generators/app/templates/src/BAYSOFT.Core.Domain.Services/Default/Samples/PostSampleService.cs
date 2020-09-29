using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using BAYSOFT.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using BAYSOFT.Core.Domain.Validations.EntityValidations<%= _Context %>;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.<%= _Context %>.<%= _Collection %>
{
    public class Post<%= _Entity %>Service : DomainService<<%= _Entity %>>, IPost<%= _Entity %>Service
    {
        private <%= _ContextType %> Context { get; set; }
        public Post<%= _Entity %>Service(
            <%= _ContextType %> context,
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
