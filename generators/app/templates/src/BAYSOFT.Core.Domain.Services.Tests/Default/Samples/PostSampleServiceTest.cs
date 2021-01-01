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
    public class Post<%= _Entity %>ServiceTest
    {
        private Post<%= _Entity %>Service GetMockedPost<%= _Entity %>Service()
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

            var mockedPost<%= _Entity %>SpecificationsValidator = new Post<%= _Entity %>SpecificationsValidator(
                mocked<%= _Entity %>NameAlreadyExistsSpecification);

            var mockedPost<%= _Entity %>Service = new Post<%= _Entity %>Service(
                mocked<%= _Context %>DbContext.Object,
                mocked<%= _Entity %>Validator,
                mockedPost<%= _Entity %>SpecificationsValidator);

            return mockedPost<%= _Entity %>Service;
        }

        [TestMethod]
        public async Task TestPost<%= _Entity %>WithEmptyModelAsync()
        {
            var mockedPost<%= _Entity %>Service = GetMockedPost<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %> { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPost<%= _Entity %>Service.Run(mocked<%= _Entity %>));
        }

        [TestMethod]
        public async Task TestPost<%= _Entity %>WithDuplicatedDescriptionOnSchoolAsync()
        {
            var mockedPost<%= _Entity %>Service = GetMockedPost<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Description = "<%= _Entity %> - 002",
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPost<%= _Entity %>Service.Run(mocked<%= _Entity %>));
        }

        [TestMethod]
        public async Task TestPost<%= _Entity %>ValidModelAsync()
        {
            var mockedPost<%= _Entity %>Service = GetMockedPost<%= _Entity %>Service();

            var mocked<%= _Entity %> = new <%= _Entity %>
            {
                Description = "<%= _Entity %> - 003",
            };

            await mockedPost<%= _Entity %>Service.Run(mocked<%= _Entity %>);
        }
    }
}
