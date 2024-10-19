using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class AddUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddUserCommandHandler_Success()
        {
            //Arange
            var handler = new AddUserCommandHandler(unitOfWork);
            var FirstName = "First Name";
            var LastName = "Last Name";
            var ClubPassId = ContextFactory.ClubIdForUpdate;
            var WorkoutId = ContextFactory.WorkoutIdForUpdate;

            //Act
            var userId = await handler.Handle(
                new AddUserCommand
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    ClubPassId = ClubPassId,
                    WorkoutId = WorkoutId
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Users.SingleOrDefaultAsync(user =>
                user.Id == userId && user.FirstName == FirstName && user.LastName == LastName
                && user.ClubPassId == ClubPassId && user.WorkoutId == WorkoutId));
        }
    }
}
