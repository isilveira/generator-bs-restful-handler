using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using Microsoft.EntityFrameworkCore;

namespace <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface <%= _ContextType %>Query
    {
        public DbSet<<%= _Entity %>> <%= _Entity %>s { get; set; }
    }
}
