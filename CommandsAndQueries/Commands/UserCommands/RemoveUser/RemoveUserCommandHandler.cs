using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.Users.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);
            unitOfWork.Users.Remove(user.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
