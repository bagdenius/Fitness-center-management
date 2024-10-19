using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveClubCommandHandler : IRequestHandler<RemoveClubCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveClubCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveClubCommand request, CancellationToken cancellationToken)
        {
            var club = await unitOfWork.Clubs.GetByIdAsync(request.Id, cancellationToken);
            if (club == null)
                throw new NotFoundException(nameof(Club), request.Id);
            unitOfWork.Clubs.Remove(club.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
