using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class AddWorkoutCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddWorkoutCommandHandler_Success()
        {
            //Arange
            var handler = new AddWorkoutCommandHandler(unitOfWork);
            var Type = "Type";
            var ClubId = ContextFactory.ClubIdForUpdate;
            var Price = 1;            

            //Act
            var workoutId = await handler.Handle(
                new AddWorkoutCommand
                {
                    Type = Type,
                    ClubId = ClubId,
                    Price = Price
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Workouts.SingleOrDefaultAsync(workout =>
                workout.Id == workoutId && workout.Type == Type && workout.ClubId == ClubId
                && workout.Price == Price));
        }


        [Fact]
        public async Task AddWorkoutHandler_FailedOnClubId()
        {
            // Arrange
            var handler = new AddWorkoutCommandHandler(unitOfWork);
            var ClubId = Guid.NewGuid();

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new AddWorkoutCommand
            { ClubId = ClubId }, CancellationToken.None));
        }
    }
}
