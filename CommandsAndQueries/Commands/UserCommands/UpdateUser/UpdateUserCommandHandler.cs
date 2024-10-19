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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var clubPass = unitOfWork.ClubPasses.Get(request.ClubPassId);
            var workout = unitOfWork.Workouts.Get(request.WorkoutId);
            var user = await unitOfWork.Users.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);
            user.Id = request.Id;
            if (user.ClubPassId == request.ClubPassId && (user.FirstName == null || request.FirstName == null) &&
                (user.LastName == request.LastName || request.LastName == null) &&
                (user.WorkoutId == request.WorkoutId || workout == null))
            {
                user.AvailableNumberOfVisitsByClubPass--;
                if (user.AvailableNumberOfVisitsByClubPass == 0)
                {
                    user.ClubPassId = null;
                }
            }
            else if (user.WorkoutId == request.WorkoutId && (user.FirstName == request.FirstName || request.FirstName == null) &&
                (user.LastName == request.LastName || request.LastName == null) &&
                (user.ClubPassId == request.ClubPassId || clubPass == null))
            {
                user.WorkoutId = null;
            }
            else
            {
                user.ClubPassId = request.ClubPassId;
                user.WorkoutId = request.WorkoutId;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                if(user.ClubPassId != request.ClubPassId && clubPass != null)
                    user.AvailableNumberOfVisitsByClubPass = clubPass.AvailableNumberOfVisits;
            }
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
