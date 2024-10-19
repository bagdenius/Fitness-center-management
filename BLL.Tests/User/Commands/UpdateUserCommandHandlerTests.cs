using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateUserCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateUserCommandHandler(unitOfWork);
            var updatedFirstName = "NewFirstname";
            var updatedLastName = "NewLastname";


            // Act
            await handler.Handle(new UpdateUserCommand
            {
                Id = ContextFactory.UserIdForUpdate,
                ClubPassId = ContextFactory.ClubPassIdForUpdate,
                WorkoutId = ContextFactory.WorkoutIdForUpdate,
                FirstName = updatedFirstName,
                LastName = updatedLastName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Users.SingleOrDefaultAsync(user =>
            user.Id == ContextFactory.UserIdForUpdate && user.FirstName == updatedFirstName && user.LastName == updatedLastName
            && user.ClubPassId == ContextFactory.ClubPassIdForUpdate && user.WorkoutId == ContextFactory.WorkoutIdForUpdate));
        }

        [Fact]
        public async Task UpdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateUserCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateUserCommand
            {
                Id = Guid.NewGuid(),
                ClubPassId = ContextFactory.ClubPassIdForUpdate,
                WorkoutId = ContextFactory.WorkoutIdForUpdate,
            }, CancellationToken.None));
        }
    }
}
