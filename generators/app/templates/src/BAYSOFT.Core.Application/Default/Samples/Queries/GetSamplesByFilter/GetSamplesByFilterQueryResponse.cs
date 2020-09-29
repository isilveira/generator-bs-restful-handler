using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>sByFilter
{
    public class Get<%= _Entity %>sByFilterQueryResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Get<%= _Entity %>sByFilterQueryResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
