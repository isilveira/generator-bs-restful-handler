using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Patch<%= _Entity %>SpecificationsValidator : DomainValidator<<%= _Entity %>>
    {
        public Patch<%= _Entity %>SpecificationsValidator(
            <%= _Entity %>DescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            base.Add("SanpleMustBeUnique", new DomainRule<<%= _Entity %>>(sampleDescriptionAlreadyExistsSpecification.Not(), "A register with this description already exists!"));
        }
    }
}
