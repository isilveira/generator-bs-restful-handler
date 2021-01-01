using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>
{
    public class <%= _Entity %>DescriptionAlreadyExistsSpecification : DomainSpecification<<%= _Entity %>>
    {
        private I<%= _Context %>DbContextQuery Context { get; set; }
        public <%= _Entity %>DescriptionAlreadyExistsSpecification(I<%= _Context %>DbContextQuery context)
        {
            Context = context;
        }

        public override Expression<Func<<%= _Entity %>, bool>> ToExpression()
        {
            return sample => Context.<%= _Collection %>.Any(x => x.Description == sample.Description && x.Id != sample.Id);
        }
    }
}
