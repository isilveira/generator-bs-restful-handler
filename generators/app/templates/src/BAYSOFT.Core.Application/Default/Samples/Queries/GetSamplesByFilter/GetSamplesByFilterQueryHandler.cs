using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>sByFilter
{
    public class Get<%= _Entity %>sByFilterQueryHandler : IRequestHandler<Get<%= _Entity %>sByFilterQuery, Get<%= _Entity %>sByFilterQueryResponse>
    {
        private <%= _ContextType %> Context { get; set; }
        public Get<%= _Entity %>sByFilterQueryHandler(<%= _ContextType %> context)
        {
            Context = context;
        }
        public async Task<Get<%= _Entity %>sByFilterQueryResponse> Handle(Get<%= _Entity %>sByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.<%= _Collection %>
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new Get<%= _Entity %>sByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
