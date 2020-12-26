using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Exceptions;
using <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>.<%= _Collection %>
{
    [TestClass]
    public class Patch<%= _Entity %>ServiceTest
    {
        private Patch<%= _Entity %>Service GetMockedPatch<%= _Entity %>Service()
        {
            var mockedDbContext = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mockedDbContextQuery = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mocked<%= _Entity %>Validator = new <%= _Entity %>Validator();

            var mockedPatch<%= _Entity %>SpecificationsValidator = new Patch<%= _Entity %>SpecificationsValidator();

            var mockedPatch<%= _Entity %>Service = new Patch<%= _Entity %>Service(
                mocked<%= _Context %>DbContext.Object,
                mocked<%= _Entity %>Validator,
                mockedPatch<%= _Entity %>SpecificationsValidator
                );

            return mockedPatch<%= _Entity %>Service;
        }

        [TestMethod]
        public async Task TestPatch<%= _Entity %>ValidModelAsync()
        {
            var mockedPatch<%= _Entity %>Service = GetMockedPatch<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Id = 1,
            };

            await mockedPatch<%= _Entity %>Service.Run(mocked<%= _Entity %>);
        }
    }
}
