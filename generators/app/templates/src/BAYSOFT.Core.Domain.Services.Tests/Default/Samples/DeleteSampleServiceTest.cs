using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>.<%= _Collection %>
{
    [TestClass]
    public class Delete<%= _Entity %>ServiceTest
    {
        private Delete<%= _Entity %>Service GetMockedDelete<%= _Entity %>Service()
        {
            var mocked<%= _Context %>DbContext = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mocked<%= _Entity %>Validator = new <%= _Entity %>Validator();

            var mockedDelete<%= _Entity %>SpecificationsValidator = new Delete<%= _Entity %>SpecificationsValidator();

            var mockedDelete<%= _Entity %>Service = new Delete<%= _Entity %>Service(
                mocked<%= _Context %>DbContext.Object,
                mocked<%= _Entity %>Validator,
                mockedDelete<%= _Entity %>SpecificationsValidator
                );

            return mockedDelete<%= _Entity %>Service;
        }

        [TestMethod]
        public async Task TestDelete<%= _Entity %>ValidModelAsync()
        {
            var mockedDelete<%= _Entity %>Service = GetMockedDelete<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Id = 1,
            };

            await mockedDelete<%= _Entity %>Service.Run(mocked<%= _Entity %>);
        }
    }
}
