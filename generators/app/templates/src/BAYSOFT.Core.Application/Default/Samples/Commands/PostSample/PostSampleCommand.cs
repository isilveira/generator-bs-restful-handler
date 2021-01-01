using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Post<%= _Entity %>
{
    public class Post<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Post<%= _Entity %>CommandResponse>
    {
        public Post<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _EntityID %>);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
