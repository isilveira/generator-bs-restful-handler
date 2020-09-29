using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Put<%= _Entity %>
{
    public class Put<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Put<%= _Entity %>CommandResponse>
    {
        public Put<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _Entity %>ID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
