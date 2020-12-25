using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Patch<%= _Entity %>
{
    public class Patch<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Patch<%= _Entity %>Command, Patch<%= _Entity %>CommandResponse>
    {
        public <%= _ContextType %> Context { get; set; }
        private IPatch<%= _Entity %>Service PatchService { get; set; }
        public Patch<%= _Entity %>CommandHandler(
            <%= _ContextType %> context,
            IPatch<%= _Entity %>Service patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<Patch<%= _Entity %>CommandResponse> Handle(Patch<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _EntityID %>);

            var data = await Context.<%= _Collection %>.SingleOrDefaultAsync(x => x.<%= _EntityID %> == id);

            if (data == null)
            {
                throw new Exception("<%= _Entity %> not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new Patch<%= _Entity %>CommandResponse(request, data, "Successful operation!", 1);
        }
    }
}