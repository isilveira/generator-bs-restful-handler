using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Queries.Get<%= _Collection %>ByFilter
{
    public class Get<%= _Collection %>ByFilterQuery : ApplicationRequest<<%= _Entity %>, Get<%= _Collection %>ByFilterQueryResponse>
    {
        public Get<%= _Collection %>ByFilterQuery()
        {
            ConfigKeys(x => x.<%= _EntityID %>);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
