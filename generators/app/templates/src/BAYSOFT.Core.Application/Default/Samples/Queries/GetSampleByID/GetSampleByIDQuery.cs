using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ById
{
    public class Get<%= _Entity %>ByIdQuery : ApplicationRequest<<%= _Entity %>, Get<%= _Entity %>ByIdQueryResponse>
    {
        public Get<%= _Entity %>ByIdQuery()
        {
            ConfigKeys(x => x.<%= _EntityID %>);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
