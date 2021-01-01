using System.Threading;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public <%= _EntityIDType %>erface I<%= _Context %>DbContext : I<%= _Context %>DbContextQuery
    {
        public <%= _EntityIDType %> SaveChanges(bool acceptAllChangesOnSuccess);
        public <%= _EntityIDType %> SaveChanges();
        public Task<<%= _EntityIDType %>> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        public Task<<%= _EntityIDType %>> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
