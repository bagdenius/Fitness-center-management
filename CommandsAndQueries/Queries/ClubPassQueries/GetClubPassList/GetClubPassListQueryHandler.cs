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
    public class GetClubPassListQueryHandler : IRequestHandler<GetClubPassListQuery, List<ClubPassModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetClubPassListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }  

        public async Task<List<ClubPassModel>> Handle(GetClubPassListQuery request, CancellationToken cancellationToken)
        {
            var clubPasses = await unitOfWork.ClubPasses.GetAllAsync(cancellationToken);
            return mapper.Map<List<ClubPassModel>>(clubPasses);
        }
    }
}
