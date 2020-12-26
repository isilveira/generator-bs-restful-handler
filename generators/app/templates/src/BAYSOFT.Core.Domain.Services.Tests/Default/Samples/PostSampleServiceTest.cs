using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>.<%= _Collection %>
{
    [TestClass]
    public class Post<%= _Entity %>ServiceTest
    {
        private Post<%= _Entity %>Service GetMockedPost<%= _Entity %>Service()
        {
            var mockedDbContext = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mockedDbContextQuery = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mocked<%= _Entity %>Validator = new <%= _Entity %>Validator();

            var mockedPost<%= _Entity %>SpecificationsValidator = new Post<%= _Entity %>SpecificationsValidator();

            var mockedPost<%= _Entity %>Service = new Post<%= _Entity %>Service(
                mockedDbContext.Object,
                mocked<%= _Entity %>Validator,
                mockedPost<%= _Entity %>SpecificationsValidator);

            return mockedPost<%= _Entity %>Service;
        }

        [TestMethod]
        public async Task TestPost<%= _Entity %>ValidModelAsync()
        {
            var mockedPost<%= _Entity %>Service = GetMockedPost<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
            };

            await mockedPost<%= _Entity %>Service.Run(mocked<%= _Entity %>);
        }
    }
}
