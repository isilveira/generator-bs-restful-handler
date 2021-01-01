using BAYSOFT.Abstractions.Core.Domain.Services;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>
{
    public class Patch<%= _Entity %>Service : DomainService<<%= _Entity %>>, IPatch<%= _Entity %>Service
    {
        private I<%= _Context %>DbContext Context { get; set; }
        public Patch<%= _Entity %>Service(
            I<%= _Context %>DbContext context,
            <%= _Entity %>Validator entityValidator,
            Patch<%= _Entity %>SpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(<%= _Entity %> entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
