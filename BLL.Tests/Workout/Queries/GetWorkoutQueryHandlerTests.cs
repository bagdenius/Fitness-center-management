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
    public class GetWorkoutQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetWorkoutQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubPassQueryHandler_Success()
        {
            // Arrange
            var handler = new GetWorkoutQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetWorkoutQuery
            { Id = Guid.Parse("CB500691-F0F5-4BC3-A003-4485A4700911") }, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<WorkoutModel>();
            result.ClubId.ShouldBe(ContextFactory.ClubIdForUpdate);
            result.Type.ShouldBe("Type1");
            result.Time.ShouldBe(DateTime.Today);
            result.Price.ShouldBe(1);

        }

        [Fact]
        public async Task GetWorkoutQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetWorkoutQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetWorkoutQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
