using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>ByID
{
    public class Get<%= _Entity %>ByIDQuery : ApplicationRequest<<%= _Entity %>, Get<%= _Entity %>ByIDQueryResponse>
    {
        public Get<%= _Entity %>ByIDQuery()
        {
            ConfigKeys(x => x.<%= _Entity %>ID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
