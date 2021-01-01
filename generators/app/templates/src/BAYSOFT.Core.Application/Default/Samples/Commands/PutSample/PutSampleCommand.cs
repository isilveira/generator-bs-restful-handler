using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Put<%= _Entity %>
{
    public class Put<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Put<%= _Entity %>CommandResponse>
    {
        public Put<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _EntityID %>);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
