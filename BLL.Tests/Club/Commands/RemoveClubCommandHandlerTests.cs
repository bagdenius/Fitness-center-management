using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class RemoveClubCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveClubCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveClubCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveClubCommand
            {
                Id = ContextFactory.ClubIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Clubs.SingleOrDefaultAsync(club =>
            club.Id == ContextFactory.ClubIdForDelete));
        }

        [Fact]
        public async Task RemoveClubCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveClubCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveClubCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
