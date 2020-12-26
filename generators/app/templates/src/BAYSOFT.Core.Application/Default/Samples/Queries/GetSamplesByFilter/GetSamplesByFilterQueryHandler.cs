using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Collection %>ByFilter
{
    public class Get<%= _Collection %>ByFilterQueryHandler : IRequestHandler<Get<%= _Collection %>ByFilterQuery, Get<%= _Collection %>ByFilterQueryResponse>
    {
        private <%= _ContextType %> Context { get; set; }
        public Get<%= _Collection %>ByFilterQueryHandler(<%= _ContextType %> context)
        {
            Context = context;
        }
        public async Task<Get<%= _Collection %>ByFilterQueryResponse> Handle(Get<%= _Collection %>ByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.<%= _Collection %>
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new Get<%= _Collection %>ByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
