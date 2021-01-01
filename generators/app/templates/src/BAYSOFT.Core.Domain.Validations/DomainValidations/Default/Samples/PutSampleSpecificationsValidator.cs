using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;
using NetDevPack.Specification;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Put<%= _Entity %>SpecificationsValidator : DomainValidator<<%= _Entity %>>
    {
        public Put<%= _Entity %>SpecificationsValidator(
            <%= _Entity %>DescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            base.Add("SanpleMustBeUnique", new Rule<<%= _Entity %>>(sampleDescriptionAlreadyExistsSpecification.Not(), "A register with this description already exists!"));
        }
    }
}
