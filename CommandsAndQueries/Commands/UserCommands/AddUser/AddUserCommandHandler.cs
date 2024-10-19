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
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddUserCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            ClubPass clubPass = null;
            if (request.ClubPassId != null) 
                clubPass = unitOfWork.ClubPasses.Get((Guid)request.ClubPassId);
        
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClubPassId = request.ClubPassId,
                WorkoutId = request.WorkoutId,
            };
            if (clubPass != null)
            {
                user.AvailableNumberOfVisitsByClubPass = clubPass.AvailableNumberOfVisits;
            }

            await unitOfWork.Users.AddAsync(user, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return user.Id;
        }
    }
}
