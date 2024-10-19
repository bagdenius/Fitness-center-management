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
    public class GetClubListQueryHandler : IRequestHandler<GetClubListQuery, List<ClubModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetClubListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<ClubModel>> Handle(GetClubListQuery request, CancellationToken cancellationToken)
        {
            var clubs = await unitOfWork.Clubs.GetAllAsync(cancellationToken);
            return mapper.Map<List<ClubModel>>(clubs);
        }
    }
}
