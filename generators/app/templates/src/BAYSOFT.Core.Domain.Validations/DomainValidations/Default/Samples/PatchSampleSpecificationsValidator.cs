using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using NetDevPack.Specification;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Patch<%= _Entity %>SpecificationsValidator : SpecValidator<<%= _Entity %>>
    {
        public Patch<%= _Entity %>SpecificationsValidator()
        {
        }
    }
}
