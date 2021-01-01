using ModelWrapper;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Abstractions.Core.Application;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Collection %>ByFilter
{
    public class Get<%= _Collection %>ByFilterQueryResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Get<%= _Collection %>ByFilterQueryResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
