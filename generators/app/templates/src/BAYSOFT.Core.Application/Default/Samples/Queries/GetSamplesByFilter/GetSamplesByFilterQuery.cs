using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Entity %>sByFilter
{
    public class Get<%= _Entity %>sByFilterQuery : ApplicationRequest<<%= _Entity %>, Get<%= _Entity %>sByFilterQueryResponse>
    {
        public Get<%= _Entity %>sByFilterQuery()
        {
            ConfigKeys(x => x.<%= _EntityID %>);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
