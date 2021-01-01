using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Patch<%= _Entity %>
{
    public class Patch<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Patch<%= _Entity %>CommandResponse>
    {
        public Patch<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _EntityID %>);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
