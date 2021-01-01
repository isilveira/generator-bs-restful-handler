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
                .Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder
                .Property<string>("Description")
                .HasColumnType("nvarchar(512)");

            builder
                .HasKey("Id");

            builder
                .ToTable("<%= _Collection %>");
        }
    }
}
