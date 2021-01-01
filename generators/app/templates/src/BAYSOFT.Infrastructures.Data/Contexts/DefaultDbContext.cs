using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using <%= _ProjectName %>.Infrastructures.Data.EntityMappings.<%= _Context %>;

namespace <%= _ProjectName %>.Infrastructures.Data.Contexts
{
    public class <%= _Context %>DbContext : DbContext, I<%= _Context %>DbContext
    {
        public DbSet<<%= _Entity %>> <%= _Collection %> { get; set; }

        protected <%= _Context %>DbContext()
        {
            Database.Migrate();
        }

        public <%= _Context %>DbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new <%= _Entity %>Map());
        }
    }
}
