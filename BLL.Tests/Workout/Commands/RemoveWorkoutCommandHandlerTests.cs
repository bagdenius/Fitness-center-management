using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class RemoveWorkoutCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveWorkoutCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveWorkoutCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveWorkoutCommand
            {
                Id = ContextFactory.WorkoutIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Workouts.SingleOrDefaultAsync(workout =>
            workout.Id == ContextFactory.WorkoutIdForDelete));
        }

        [Fact]
        public async Task RemoveWorkoutCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveWorkoutCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveWorkoutCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
