using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateWorkoutCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateWorkoutCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateWorkoutCommandHandler(unitOfWork);
            var updatedType = "New type";


            // Act
            await handler.Handle(new UpdateWorkoutCommand
            {
                Id = ContextFactory.WorkoutIdForUpdate,
                //ClubId = ContextFactory.ClubIdForUpdate,
                Type = updatedType
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Workouts.SingleOrDefaultAsync(workout =>
            workout.Id == ContextFactory.WorkoutIdForUpdate && workout.Type == updatedType /*&& workout.ClubId == ContextFactory.ClubIdForUpdate*/));
        }

        [Fact]
        public async Task UpdateWorkoutCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateWorkoutCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateWorkoutCommand
            {
                Id = Guid.NewGuid(),
                //ClubId = ContextFactory.ClubIdForUpdate
            }, CancellationToken.None));
        }
    }
}
