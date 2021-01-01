using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using <%= _ProjectName %>.Core.Domain.Resources;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Abstractions.Core.Application;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ByID
{
    public class Get<%= _Entity %>ByIDQueryHandler : ApplicationRequestHandler<<%= _Entity %>, Get<%= _Entity %>ByIDQuery, Get<%= _Entity %>ByIDQueryResponse>
    {
        private IStringLocalizer MessagesLocalizer { get; set; }
        private IStringLocalizer Entities<%= _Context %>Localizer { get; set; }
        private I<%= _Context %>DbContext Context { get; set; }
        public Get<%= _Entity %>ByIDQueryHandler(
            IStringLocalizer<Messages> messagesLocalizer,
            IStringLocalizer<Entities<%= _Context %>> entities<%= _Context %>Localizer,
            I<%= _Context %>DbContext context)
        {
            MessagesLocalizer = messagesLocalizer;
            Entities<%= _Context %>Localizer = entities<%= _Context %>Localizer;
            Context = context;
        }
        public override async Task<Get<%= _Entity %>ByIDQueryResponse> Handle(Get<%= _Entity %>ByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _EntityID %>);

            var data = await Context.<%= _Collection %>
                .Where(x => x.<%= _EntityID %> == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception(string.Format(MessagesLocalizer["{0} not found!"], Entities<%= _Context %>Localizer[nameof(<%= _Entity %>)]));
            }

            return new Get<%= _Entity %>ByIDQueryResponse(request, data, MessagesLocalizer["Successful operation!"], 1);
        }
    }
}
