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
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        { 
            var user = await unitOfWork.Users.GetUserAsync(request.Id);
            if (user == null || user.Id != request.Id)
                throw new NotFoundException(nameof(User), request.Id);
            return mapper.Map<UserModel>(user);
        }
    }
}
