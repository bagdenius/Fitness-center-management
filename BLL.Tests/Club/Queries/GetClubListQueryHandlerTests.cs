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
    public class GetClubListQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetClubListQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClubListQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetClubListQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<ClubModel>>();
            result.Count.ShouldBe(4);
        }
    }
}
