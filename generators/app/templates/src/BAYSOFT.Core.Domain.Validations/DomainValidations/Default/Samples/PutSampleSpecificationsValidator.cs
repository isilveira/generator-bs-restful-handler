using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using NetDevPack.Specification;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Put<%= _Entity %>SpecificationsValidator : SpecValidator<<%= _Entity %>>
    {
        public Put<%= _Entity %>SpecificationsValidator()
        {
        }
    }
}
