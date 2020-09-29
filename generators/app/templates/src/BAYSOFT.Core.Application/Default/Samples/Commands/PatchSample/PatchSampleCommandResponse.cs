using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Patch<%= _Entity %>
{
    public class Patch<%= _Entity %>CommandResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Patch<%= _Entity %>CommandResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
