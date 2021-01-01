using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ModelWrapper.Extensions.Patch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Patch<%= _Entity %>
{
    public class Patch<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Patch<%= _Entity %>Command, Patch<%= _Entity %>CommandResponse>
    {
        private IStringLocalizer MessagesLocalizer { get; set; }
        private IStringLocalizer Entities<%= _Context %>Localizer { get; set; }
        public I<%= _Context %>DbContext Context { get; set; }
        private IPatch<%= _Entity %>Service PatchService { get; set; }
        public Patch<%= _Entity %>CommandHandler(
            IStringLocalizer<Messages> messagesLocalizer,
            IStringLocalizer<Entities<%= _Context %>> entities<%= _Context %>Localizer,
            I<%= _Context %>DbContext context,
            IPatch<%= _Entity %>Service patchService)
        {
            MessagesLocalizer = messagesLocalizer;
            Entities<%= _Context %>Localizer = entities<%= _Context %>Localizer;
            Context = context;
            PatchService = patchService;
        }
        public override async Task<Patch<%= _Entity %>CommandResponse> Handle(Patch<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.Id);

            var data = await Context.<%= _Collection %>.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                throw new Exception(string.Format(MessagesLocalizer["{0} not found!"], Entities<%= _Context %>Localizer[nameof(<%= _Entity %>)]));
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new Patch<%= _Entity %>CommandResponse(request, data, MessagesLocalizer["Successful operation!"], 1);
        }
    }
}
