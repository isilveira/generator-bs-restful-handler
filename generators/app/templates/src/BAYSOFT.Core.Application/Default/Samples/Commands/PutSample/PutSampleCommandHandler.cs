using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ModelWrapper.Extensions.Put;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Put<%= _Entity %>
{
    public class Put<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Put<%= _Entity %>Command, Put<%= _Entity %>CommandResponse>
    {
        private IStringLocalizer MessagesLocalizer { get; set; }
        private IStringLocalizer Entities<%= _Context %>Localizer { get; set; }
        public I<%= _Context %>DbContext Context { get; set; }
        private IPut<%= _Entity %>Service PutService { get; set; }
        public Put<%= _Entity %>CommandHandler(
            IStringLocalizer<Messages> messagesLocalizer,
            IStringLocalizer<Entities<%= _Context %>> entities<%= _Context %>Localizer,
            I<%= _Context %>DbContext context,
            IPut<%= _Entity %>Service putService)
        {
            MessagesLocalizer = messagesLocalizer;
            Entities<%= _Context %>Localizer = entities<%= _Context %>Localizer;
            Context = context;
            PutService = putService;
        }
        public override async Task<Put<%= _Entity %>CommandResponse> Handle(Put<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.<%= _EntityID %>);
            var data = await Context.<%= _Collection %>.SingleOrDefaultAsync(x => x.<%= _EntityID %> == id);

            if (data == null)
            {
                throw new Exception(string.Format(MessagesLocalizer["{0} not found!"], Entities<%= _Context %>Localizer[nameof(<%= _Entity %>)]));
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new Put<%= _Entity %>CommandResponse(request, data, MessagesLocalizer["Successful operation!"], 1);
        }
    }
}
