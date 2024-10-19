using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UoW;
using ViewModels;
using DataBase;

namespace CommandsAndQueries
{
    public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateWorkoutCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await unitOfWork.Workouts.GetByIdAsync(request.Id, cancellationToken);
            if (workout == null)
                throw new NotFoundException(nameof(Workout), request.Id);
            workout.Id = request.Id;
            workout.Type = request.Type;
            workout.Price = request.Price;
            workout.Time = request.Time;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
