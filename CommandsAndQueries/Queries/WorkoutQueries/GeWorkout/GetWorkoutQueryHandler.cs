using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;


namespace CommandsAndQueries
{
    public class GetWorkoutQueryHandler : IRequestHandler<GetWorkoutQuery, WorkoutModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetWorkoutQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<WorkoutModel> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workout = await unitOfWork.Workouts.GetByIdAsync(request.Id, cancellationToken);
            if (workout == null || workout.Id != request.Id)
                throw new NotFoundException(nameof(Workout), request.Id);
            return mapper.Map<WorkoutModel>(workout);
        }
    }
}
