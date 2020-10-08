using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>
{
    public interface IPatch<%= _Entity %>Service : IDomainService<<%= _Entity %>>
    {
    }
}
