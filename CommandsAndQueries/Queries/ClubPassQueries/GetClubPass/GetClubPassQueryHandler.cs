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
    public class GetClubPassQueryHandler : IRequestHandler<GetClubPassQuery, ClubPassModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetClubPassQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ClubPassModel> Handle(GetClubPassQuery request, CancellationToken cancellationToken)
        {
            var clubPass = await unitOfWork.ClubPasses.GetByIdAsync(request.Id, cancellationToken);
            if (clubPass == null || clubPass.Id != request.Id)
                throw new NotFoundException(nameof(ClubPass), request.Id);
            return mapper.Map<ClubPassModel>(clubPass);
        }
    }
}
