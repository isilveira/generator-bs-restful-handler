using ModelWrapper;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Abstractions.Core.Application;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Delete<%= _Entity %>
{
    public class Delete<%= _Entity %>CommandResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Delete<%= _Entity %>CommandResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
