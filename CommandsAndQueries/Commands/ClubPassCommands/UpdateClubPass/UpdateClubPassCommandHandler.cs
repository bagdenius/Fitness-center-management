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
    public class UpdateClubPassCommandHandler : IRequestHandler<UpdateClubPassCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateClubPassCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateClubPassCommand request, CancellationToken cancellationToken)
        {
            var clubPass = await unitOfWork.ClubPasses.GetByIdAsync(request.Id, cancellationToken);
            if (clubPass == null)
                throw new NotFoundException(nameof(ClubPass), request.Id);
            clubPass.Id = request.Id;
            clubPass.Name = request.Name;
            clubPass.AvailableNumberOfVisits = request.AvailableNumberOfVisits;
            clubPass.IsNet = request.IsNet;
            clubPass.Price = request.Price;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
