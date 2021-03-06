﻿using BAYSOFT.Abstractions.Core.Domain.Validations;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;

namespace <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>
{
    public class Post<%= _Entity %>SpecificationsValidator : DomainValidator<<%= _Entity %>>
    {
        public Post<%= _Entity %>SpecificationsValidator()
        {
        }
    }
}
