using ModelWrapper;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using BAYSOFT.Abstractions.Core.Application;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ById
{
    public class Get<%= _Entity %>ByIdQueryResponse : ApplicationResponse<<%= _Entity %>>
    {
        public Get<%= _Entity %>ByIdQueryResponse(WrapRequest<<%= _Entity %>> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
