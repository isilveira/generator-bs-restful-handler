using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Delete<%= _Entity %>
{
    public class Delete<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Delete<%= _Entity %>Command, Delete<%= _Entity %>CommandResponse>
    {
        public <%= _ContextType %> Context { get; set; }
        private IDelete<%= _Entity %>Service DeleteService { get; set; }
        public Delete<%= _Entity %>CommandHandler(
            <%= _ContextType %> context,
            IDelete<%= _Entity %>Service deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<Delete<%= _Entity %>CommandResponse> Handle(Delete<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _Entity %>ID);

            var data = await Context.<%= _Collection %>.SingleOrDefaultAsync(x => x.<%= _Entity %>ID == id);

            if (data == null)
                throw new Exception("<%= _Entity %> not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new Delete<%= _Entity %>CommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
