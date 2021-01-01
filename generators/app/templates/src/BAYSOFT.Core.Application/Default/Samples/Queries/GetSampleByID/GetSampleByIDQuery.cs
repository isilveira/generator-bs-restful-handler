using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ByID
{
    public class Get<%= _Entity %>ByIDQuery : ApplicationRequest<<%= _Entity %>, Get<%= _Entity %>ByIDQueryResponse>
    {
        public Get<%= _Entity %>ByIDQuery()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
