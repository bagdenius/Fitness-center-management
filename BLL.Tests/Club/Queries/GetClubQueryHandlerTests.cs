using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UoW;
using AutoMapper;
using ViewModels;
using Xunit;
using Shouldly;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetClubQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetClubQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClubQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetClubQuery
            { Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB") }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ClubModel>();
            result.Name.ShouldBe("Name1");
            result.City.ShouldBe("City1");
            result.Address.ShouldBe("Address1");
        }

        [Fact]
        public async Task GetClubQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetClubQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetClubQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
