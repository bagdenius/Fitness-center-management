using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class AddClubPassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddClubPassCommandHandler_Success()
        {
            //Arange
            var handler = new AddClubPassCommandHandler(unitOfWork);
            var Name = "Name";
            var ClubId = ContextFactory.ClubIdForUpdate;
            var AvailableNumberOfVisits = 1;
            var Price = 1;
            var IsNet = false;

            //Act
            var clubPassId = await handler.Handle(
                new AddClubPassCommand
                {
                    Name = Name,
                    ClubId = ClubId,
                    AvailableNumberOfVisits = AvailableNumberOfVisits,
                    Price = Price,
                    IsNet = IsNet
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.ClubsPass.SingleOrDefaultAsync(clubPass =>
                clubPass.Id == clubPassId && clubPass.Name == Name && clubPass.ClubId == ClubId 
                && clubPass.AvailableNumberOfVisits == AvailableNumberOfVisits && clubPass.Price == Price && clubPass.IsNet == IsNet));
        }


        [Fact]
        public async Task AddClubPassCommandHandler_FailedOnClubId()
        {
            // Arrange
            var handler = new AddClubPassCommandHandler(unitOfWork);
            var ClubId = Guid.NewGuid();

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new AddClubPassCommand
            { ClubId = ClubId }, CancellationToken.None));
        }
    }
}
