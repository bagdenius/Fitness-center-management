using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveWorkoutCommandHandler : IRequestHandler<RemoveWorkoutCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveWorkoutCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await unitOfWork.Workouts.GetByIdAsync(request.Id, cancellationToken);
            if (workout == null)
                throw new NotFoundException(nameof(Workout), request.Id);
            unitOfWork.Workouts.Remove(workout.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
