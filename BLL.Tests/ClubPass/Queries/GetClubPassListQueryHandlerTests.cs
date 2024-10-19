using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using UoW;
using ViewModels;
using Shouldly;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetClubPassListQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetClubPassListQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubPassListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClubPassListQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetClubPassListQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<ClubPassModel>>();
            result.Count.ShouldBe(4);
        }
    }
}
