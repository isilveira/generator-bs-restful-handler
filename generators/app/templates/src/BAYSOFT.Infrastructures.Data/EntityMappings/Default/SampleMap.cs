using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Infrastructures.Data.EntityMappings.<%= _Context %>
{
    public class <%= _Entity %>Map : IEntityTypeConfiguration<<%= _Entity %>>
    {
        public void Configure(EntityTypeBuilder<<%= _Entity %>> builder)
        {
            builder
                .Property<<%= _EntityIDType %>>("<%= _EntityID %>")
                .ValueGeneratedOnAdd()
                .HasColumnType("<%= _EntityIDType %>")
                .UseIdentityColumn();

            builder
                .HasKey("<%= _EntityID %>");

            builder
                .ToTable("<%= _Collection %>");
        }
    }
}
