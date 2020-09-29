using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Validations.EntityValidations<%= _Context %>
{
    public class <%= _Entity %>Validator : AbstractValidator<<%= _Entity %>>
    {
        public <%= _Entity %>Validator()
        {
        }
    }
}
