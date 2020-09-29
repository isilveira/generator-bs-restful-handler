using BAYSOFT.Core.Domain.Entities.<%= _Context %>;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface <%= _ContextType %>Query
    {
        public DbSet<<%= _Entity %>> <%= _Entity %>s { get; set; }
    }
}
