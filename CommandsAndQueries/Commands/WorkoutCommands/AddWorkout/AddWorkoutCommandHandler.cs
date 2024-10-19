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
    public class AddWorkoutCommandHandler : IRequestHandler<AddWorkoutCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddWorkoutCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
        {
            var club = unitOfWork.Clubs.Get(request.ClubId);
            if (club == null)
                throw new NotFoundException(nameof(Club), request.ClubId);
            var workout = new Workout
            {
                Id = Guid.NewGuid(),
                ClubId = request.ClubId,
                Type = request.Type,
                Price = request.Price,
                Time = request.Time
            };
            await unitOfWork.Workouts.AddAsync(workout, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return workout.Id;
        }
    }
}
