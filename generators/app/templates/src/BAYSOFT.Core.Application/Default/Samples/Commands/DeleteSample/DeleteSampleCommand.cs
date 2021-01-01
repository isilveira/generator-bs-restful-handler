using BAYSOFT.Abstractions.Core.Application;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Application.<%= _Context %>.<%= _Collection %>.Commands.Delete<%= _Entity %>
{
    public class Delete<%= _Entity %>Command : ApplicationRequest<<%= _Entity %>, Delete<%= _Entity %>CommandResponse>
    {
        public Delete<%= _Entity %>Command()
        {
            ConfigKeys(x => x.<%= _EntityID %>);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
