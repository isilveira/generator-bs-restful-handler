using BAYSOFT.Core.Domain.Entities.<%= _Context %>;

namespace BAYSOFT.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Post<%= _Entity %>
{
    public class Post<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Post<%= _Entity %>CommandResponse>
    {
        public Post<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _Entity %>ID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
