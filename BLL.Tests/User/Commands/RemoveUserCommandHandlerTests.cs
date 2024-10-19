using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class RemoveUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveUserCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveUserCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveUserCommand
            {
                Id = ContextFactory.UserIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Users.SingleOrDefaultAsync(user =>
            user.Id == ContextFactory.UserIdForDelete));
        }

        [Fact]
        public async Task RemoveUserCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveUserCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveUserCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
