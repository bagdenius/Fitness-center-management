using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class AddClubCommandHandler : IRequestHandler<AddClubCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddClubCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddClubCommand request, CancellationToken cancellationToken)
        {
            var club = new Club
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                City = request.City
            };
            await unitOfWork.Clubs.AddAsync(club, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return club.Id;
        }
    }
}
