using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Post<%= _Entity %>
{
    public class Post<%= _Entity %>CommandResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Post<%= _Entity %>CommandResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
