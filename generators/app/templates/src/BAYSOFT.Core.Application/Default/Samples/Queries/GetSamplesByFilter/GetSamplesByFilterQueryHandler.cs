using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;
using <%= _ProjectName %>.Core.Domain.Resources;
using Microsoft.Extensions.Localization;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Abstractions.Core.Application;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Collection %>ByFilter
{
    public class Get<%= _Collection %>ByFilterQueryHandler : ApplicationRequestHandler<<%= _Entity %>, Get<%= _Collection %>ByFilterQuery, Get<%= _Collection %>ByFilterQueryResponse>
    {
        private IStringLocalizer StringLocalizer { get; set; }
        private I<%= _Context %>DbContext Context { get; set; }
        public Get<%= _Collection %>ByFilterQueryHandler(
            IStringLocalizer<Messages> stringLocalizer,
            I<%= _Context %>DbContext context)
        {
            StringLocalizer = stringLocalizer;
            Context = context;
        }
        public override async Task<Get<%= _Collection %>ByFilterQueryResponse> Handle(Get<%= _Collection %>ByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.<%= _Collection %>
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new Get<%= _Collection %>ByFilterQueryResponse(request, data, StringLocalizer["Successful operation!"], resultCount);
        }
    }
}
