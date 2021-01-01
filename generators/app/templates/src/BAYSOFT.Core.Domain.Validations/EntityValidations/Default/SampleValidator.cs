using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using FluentValidation;

namespace <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>
{
    public class <%= _Entity %>Validator : EntityValidator<<%= _Entity %>>
    {
        public <%= _Entity %>Validator()
        {
        }
    }
}
