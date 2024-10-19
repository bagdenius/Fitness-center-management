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
    public class GetClubPassQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetClubPassQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubPassQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClubPassQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetClubPassQuery
            { Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15") }, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<ClubPassModel>();
            result.ClubId.ShouldBe(ContextFactory.ClubIdForUpdate);
            result.Name.ShouldBe("Name1");
            result.AvailableNumberOfVisits.ShouldBe(1);
            result.Price.ShouldBe(1);
            result.IsNet.ShouldBe(false);
        }

        [Fact]
        public async Task GetPassClubQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetClubPassQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetClubPassQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
