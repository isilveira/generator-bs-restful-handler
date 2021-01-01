using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Delete<%= _Entity %>SpecificationsValidator : DomainValidator<<%= _Entity %>>
    {
        public Delete<%= _Entity %>SpecificationsValidator()
        {
        }
    }
}
