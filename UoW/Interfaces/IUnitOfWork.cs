using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Club> Clubs { get; }
        IGenericRepository<ClubPass> ClubPasses { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Workout> Workouts { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
