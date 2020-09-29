using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ByID
{
    public class Get<%= _Entity %>ByIDQueryResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Get<%= _Entity %>ByIDQueryResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
