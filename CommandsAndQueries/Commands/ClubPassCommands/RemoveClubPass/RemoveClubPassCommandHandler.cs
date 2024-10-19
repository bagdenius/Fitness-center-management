using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveClubPassCommandHandler : IRequestHandler<RemoveClubPassCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveClubPassCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveClubPassCommand request, CancellationToken cancellationToken)
        {
            var clubPass = await unitOfWork.ClubPasses.GetByIdAsync(request.Id, cancellationToken);
            if (clubPass == null)
                throw new NotFoundException(nameof(ClubPass), request.Id);
            unitOfWork.ClubPasses.Remove(clubPass.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
