using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Put<%= _Entity %>
{
    public class Put<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Put<%= _Entity %>Command, Put<%= _Entity %>CommandResponse>
    {
        public <%= _ContextType %> Context { get; set; }
        private IPut<%= _Entity %>Service PutService { get; set; }
        public Put<%= _Entity %>CommandHandler(
            <%= _ContextType %> context,
            IPut<%= _Entity %>Service putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<Put<%= _Entity %>CommandResponse> Handle(Put<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _Entity %>ID);
            var data = await Context.<%= _Collection %>.SingleOrDefaultAsync(x => x.<%= _Entity %>ID == id);

            if (data == null)
            {
                throw new Exception("<%= _Entity %> not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new Put<%= _Entity %>CommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
