using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using FluentValidation;

namespace <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>
{
    public class <%= _Entity %>Validator : EntityValidator<<%= _Entity %>>
    {
        public <%= _Entity %>Validator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("{0} must have at least 3 caracters!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("{0} must have a maximum of 100 caracters!");
        }
    }
}
