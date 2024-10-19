using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateClubPassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateClubPassCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateClubPassCommandHandler(unitOfWork);
            var updatedName = "NewName";


            // Act
            await handler.Handle(new UpdateClubPassCommand
            {
                Id = ContextFactory.ClubPassIdForUpdate,
                //ClubId = ContextFactory.ClubIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.ClubsPass.SingleOrDefaultAsync(clubPass =>
            clubPass.Id == ContextFactory.ClubPassIdForUpdate && clubPass.Name == updatedName /*&& clubPass.ClubId == ContextFactory.ClubIdForUpdate*/));
        }

        [Fact]
        public async Task UpdateClubPassCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateClubPassCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateClubPassCommand
            {
                Id = Guid.NewGuid(),
                //ClubId = ContextFactory.ClubIdForUpdate
            }, CancellationToken.None));
        }
    }
}
