using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UoW;
using AutoMapper;
using ViewModels;
using Xunit;
using Shouldly;
using CommandsAndQueries;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetUserQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetUserQueryHandler_Success()
        {
            // Arrange
            var handler = new GetUserQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetUserQuery
            { Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF") }, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<UserModel>();
            //result.ClubPassId.ShouldBe(ContextFactory.ClubPassIdForUpdate);
            //result.WorkoutId.ShouldBe(ContextFactory.WorkoutIdForUpdate);
            result.FirstName.ShouldBe("FirstName1");
            result.LastName.ShouldBe("LastName1");

        }

        [Fact]
        public async Task GetUserQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetUserQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetUserQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
