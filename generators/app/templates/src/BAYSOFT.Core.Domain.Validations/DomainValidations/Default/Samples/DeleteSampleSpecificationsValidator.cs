using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using NetDevPack.Specification;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Delete<%= _Entity %>SpecificationsValidator : SpecValidator<<%= _Entity %>>
    {
        public Delete<%= _Entity %>SpecificationsValidator()
        {
        }
    }
}
