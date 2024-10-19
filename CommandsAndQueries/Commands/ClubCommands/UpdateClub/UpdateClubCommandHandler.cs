using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using ViewModels;
using DataBase;

namespace CommandsAndQueries
{
    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateClubCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
        {
            var club = await unitOfWork.Clubs.GetByIdAsync(request.Id, cancellationToken);
            if (club == null)
                throw new NotFoundException(nameof(Club), request.Id);
            club.Id = request.Id;
            club.Name = request.Name;
            club.City = request.City;
            club.Address = request.Address;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
