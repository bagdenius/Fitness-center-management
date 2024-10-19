using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class AddClubCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddClubCommandHandler_Success() 
        {
            //Arange
            var handler = new AddClubCommandHandler(unitOfWork);
            var Name = "Name";
            var City = "City";
            var Address = "Address";

            //Act
            var clubId = await handler.Handle(
                new AddClubCommand
                {
                    Name = Name,
                    City = City,
                    Address = Address
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Clubs.SingleOrDefaultAsync(club =>
                club.Id == clubId && club.Name == Name && club.City == City && club.Address == Address));
        }
    }
}
