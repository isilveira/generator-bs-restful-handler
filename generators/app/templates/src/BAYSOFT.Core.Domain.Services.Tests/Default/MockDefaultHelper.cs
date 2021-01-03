using <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Moq;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>
{
    public static class Mock<%= _Context %>Helper
    {
        internal static Mock<I<%= _Context %>DbContext> GetMockedDbContext()
        {
            var mockedDbContext = new Mock<I<%= _Context %>DbContext>();

            return mockedDbContext;
        }
        internal static Mock<I<%= _Context %>DbContextQuery> GetMockedDbContextQuery()
        {
            var mockedDbContextQuery = new Mock<I<%= _Context %>DbContextQuery>();

            return mockedDbContextQuery;
        }
    }
}
