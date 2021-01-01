using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>.<%= _Collection %>
{
    internal static class AddMocked<%= _Collection %>Extensions
    {
        private static IQueryable<<%= _Entity %>> Get<%= _Collection %>Collection()
        {
            return new List<<%= _Entity %>> {
                new <%= _Entity %> { Id = 1, },
                new <%= _Entity %> { Id = 2, },
            }.AsQueryable();
        }

        private static Mock<DbSet<<%= _Entity %>>> GetMockedDbSet<%= _Collection %>()
        {
            var collection = Get<%= _Collection %>Collection();

            var mockedDbSet<%= _Collection %> = collection.MockDbSet();

            return mockedDbSet<%= _Collection %>;
        }

        internal static Mock<I<%= _Context %>DbContext> AddMocked<%= _Collection %>(this Mock<I<%= _Context %>DbContext> mockedDbContext)
        {
            var mockedDbSet<%= _Collection %> = GetMockedDbSet<%= _Collection %>();

            mockedDbContext
                .Setup(setup => setup.<%= _Collection %>)
                .Returns(mockedDbSet<%= _Collection %>.Object);

            return mockedDbContext;
        }

        internal static Mock<I<%= _Context %>DbContextQuery> AddMocked<%= _Collection %>(this Mock<I<%= _Context %>DbContextQuery> mockedDbContextQuery)
        {
            var mockedDbSet<%= _Collection %> = GetMockedDbSet<%= _Collection %>();

            mockedDbContextQuery
                .Setup(setup => setup.<%= _Collection %>)
                .Returns(mockedDbSet<%= _Collection %>.Object);

            return mockedDbContextQuery;
        }
    }
}
