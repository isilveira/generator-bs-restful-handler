using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ByID
{
    public class Get<%= _Entity %>ByIDQueryHandler : IRequestHandler<Get<%= _Entity %>ByIDQuery, Get<%= _Entity %>ByIDQueryResponse>
    {
        private <%= _ContextType %> Context { get; set; }
        public Get<%= _Entity %>ByIDQueryHandler(<%= _ContextType %> context)
        {
            Context = context;
        }
        public async Task<Get<%= _Entity %>ByIDQueryResponse> Handle(Get<%= _Entity %>ByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _EntityID %>);

            var data = await Context.<%= _Collection %>
                .Where(x => x.<%= _EntityID %> == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("<%= _Entity %> not found!");
            }

            return new Get<%= _Entity %>ByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
