using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using BAYSOFT.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using BAYSOFT.Core.Domain.Validations.EntityValidations<%= _Context %>;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.<%= _Context %>.<%= _Collection %>
{
    public class Delete<%= _Entity %>Service : DomainService<<%= _Entity %>>,IDelete<%= _Entity %>Service
    {
        private <%= _ContextType %> Context { get; set; }
        public Delete<%= _Entity %>Service(
            <%= _ContextType %> context,
            <%= _Entity %>Validator entityValidator,
            Delete<%= _Entity %>SpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(<%= _Entity %> entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.<%= _Collection %>.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
