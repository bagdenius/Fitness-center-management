using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class RemoveClubPassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveClubPassCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveClubPassCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveClubPassCommand
            {
                Id = ContextFactory.ClubPassIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.ClubsPass.SingleOrDefaultAsync(clubPass =>
            clubPass.Id == ContextFactory.ClubPassIdForDelete));
        }

        [Fact]
        public async Task RemoveClubPassCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveClubPassCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveClubPassCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
