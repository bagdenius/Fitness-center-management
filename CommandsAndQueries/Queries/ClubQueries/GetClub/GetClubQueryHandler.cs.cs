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
    public class GetClubQueryHandler : IRequestHandler<GetClubQuery, ClubModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetClubQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ClubModel> Handle(GetClubQuery request, CancellationToken cancellationToken)
        {
            var club = await unitOfWork.Clubs.GetByIdAsync(request.Id, cancellationToken);
            if (club == null || club.Id != request.Id)
                throw new NotFoundException(nameof(Club), request.Id);
            return mapper.Map<ClubModel>(club);
        }
    }
}
