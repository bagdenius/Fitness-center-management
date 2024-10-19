using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using UoW;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<UserModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.Users.GetAllAsync(cancellationToken);
            return mapper.Map<List<UserModel>>(users);
        }
    }
}
