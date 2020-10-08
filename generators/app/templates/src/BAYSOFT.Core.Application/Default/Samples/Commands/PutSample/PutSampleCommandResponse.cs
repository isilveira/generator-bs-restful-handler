using ModelWrapper;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Put<%= _Entity %>
{
    public class Put<%= _Entity %>CommandResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Put<%= _Entity %>CommandResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
