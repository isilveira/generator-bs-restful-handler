using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Services.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.DomainValidations.<%= _Context %>.<%= _Collection %>;
using <%= _ProjectName %>.Core.Domain.Validations.EntityValidations.<%= _Context %>;
using <%= _ProjectName %>.Core.Domain.Validations.Specifications.<%= _Context %>.<%= _Collection %>;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Services.Tests.<%= _Context %>.<%= _Collection %>
{

    [TestClass]
    public class Put<%= _Entity %>ServiceTest
    {
        private Put<%= _Entity %>Service GetMockedPut<%= _Entity %>Service()
        {
            var mocked<%= _Context %>DbContext = Mock<%= _Context %>Helper
                .GetMockedDbContext()
                .AddMocked<%= _Collection %>();

            var mocked<%= _Context %>DbContextQuery = Mock<%= _Context %>Helper
                .GetMockedDbContextQuery()
                .AddMocked<%= _Collection %>();

            var mocked<%= _Entity %>Validator = new <%= _Entity %>Validator();

            var mocked<%= _Entity %>NameAlreadyExistsSpecification = new <%= _Entity %>DescriptionAlreadyExistsSpecification(
                mocked<%= _Context %>DbContextQuery.Object);

            var mockedPut<%= _Entity %>SpecificationsValidator = new Put<%= _Entity %>SpecificationsValidator(
                mocked<%= _Entity %>NameAlreadyExistsSpecification);

            var mockedPut<%= _Entity %>Service = new Put<%= _Entity %>Service(
                mocked<%= _Context %>DbContext.Object,
                mocked<%= _Entity %>Validator,
                mockedPut<%= _Entity %>SpecificationsValidator);

            return mockedPut<%= _Entity %>Service;
        }

        [TestMethod]
        public async Task TestPut<%= _Entity %>WithEmptyModelAsync()
        {
            var mockedPut<%= _Entity %>Service = GetMockedPut<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %> { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPut<%= _Entity %>Service.Run(mocked<%= _Entity %>));
        }

        [TestMethod]
        public async Task TestPut<%= _Entity %>WithDuplicatedDescriptionOnSchoolAsync()
        {
            var mockedPut<%= _Entity %>Service = GetMockedPut<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Id = 1,
                Description = "<%= _Entity %> - 002"
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPut<%= _Entity %>Service.Run(mocked<%= _Entity %>));
        }

        [TestMethod]
        public async Task TestPut<%= _Entity %>ValidModelAsync()
        {
            var mockedPut<%= _Entity %>Service = GetMockedPut<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Id = 1,
                Description = "<%= _Entity %> - 003",
            };

            await mockedPut<%= _Entity %>Service.Run(mocked<%= _Entity %>);
        }
    }
}
