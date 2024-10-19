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

    public class AddClubPassCommandHandler : IRequestHandler<AddClubPassCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddClubPassCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddClubPassCommand request, CancellationToken cancellationToken)
        {
            var club = unitOfWork.Clubs.Get(request.ClubId);
            if (club == null)
                throw new NotFoundException(nameof(Club), request.ClubId);
            var clubPass = new ClubPass
            {
                Id = Guid.NewGuid(),
                ClubId = request.ClubId,
                Name = request.Name,
                AvailableNumberOfVisits = request.AvailableNumberOfVisits,
                IsNet = request.IsNet,
                Price = request.Price
            };
         
            await unitOfWork.ClubPasses.AddAsync(clubPass, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return clubPass.Id;
        }
    }
}
