using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViewModels;
using AutoMapper;
using UoW;

namespace CommandsAndQueries
{
    public class GetWorkoutListQueryHandler : IRequestHandler<GetWorkoutListQuery, List<WorkoutModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetWorkoutListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<WorkoutModel>> Handle(GetWorkoutListQuery request, CancellationToken cancellationToken)
        {
            var workouts = await unitOfWork.Workouts.GetAllAsync(cancellationToken);
            return mapper.Map<List<WorkoutModel>>(workouts);
        }
    }
}
