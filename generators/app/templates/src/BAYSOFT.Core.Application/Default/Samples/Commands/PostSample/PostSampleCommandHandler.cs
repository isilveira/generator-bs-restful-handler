using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Resources;
using Microsoft.Extensions.Localization;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Post<%= _Entity %>
{
    public class Post<%= _Entity %>CommandHandler : ApplicationRequestHandler<<%= _Entity %>, Post<%= _Entity %>Command, Post<%= _Entity %>CommandResponse>
    {
        private IStringLocalizer MessagesLocalizer { get; set; }
        private I<%= _Context %>DbContext Context { get; set; }
        private IPost<%= _Entity %>Service PostService { get; set; }
        public Post<%= _Entity %>CommandHandler(
            IStringLocalizer<Messages> messagesLocalizer,
            I<%= _Context %>DbContext context,
            IPost<%= _Entity %>Service postService
        )
        {
            MessagesLocalizer = messagesLocalizer;
            Context = context;
            PostService = postService;
        }
        public override async Task<Post<%= _Entity %>CommandResponse> Handle(Post<%= _Entity %>Command request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new Post<%= _Entity %>CommandResponse(request, data, MessagesLocalizer["Successful operation!"], 1);
        }
    }
}
