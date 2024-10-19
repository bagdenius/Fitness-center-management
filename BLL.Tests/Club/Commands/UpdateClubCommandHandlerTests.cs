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
    public class UpdateClubCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateClubCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateClubCommandHandler(unitOfWork);
            var updatedName = "New name";


            // Act
            await handler.Handle(new UpdateClubCommand
            {
                Id = ContextFactory.ClubIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Clubs.SingleOrDefaultAsync(club =>
            club.Id == ContextFactory.ClubIdForUpdate && club.Name == updatedName));
        }

        [Fact]
        public async Task UpdateClubCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateClubCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateClubCommand
            {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }

    }
}
