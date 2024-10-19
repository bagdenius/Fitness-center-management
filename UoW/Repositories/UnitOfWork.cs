using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessContext context;

        public IGenericRepository<Club> Clubs { get; set; }
        public IGenericRepository<ClubPass> ClubPasses { get; set; }
        public IGenericRepository<User> Users { get; set; }
        public IGenericRepository<Workout> Workouts { get; set; }

        public UnitOfWork(FitnessContext context, IGenericRepository<Club> clubs, IGenericRepository<ClubPass> clubPasses, IGenericRepository<User> users, IGenericRepository<Workout> workouts) 
        {
            this.context = context;
            Clubs = clubs;
            ClubPasses = clubPasses;
            Users = users;
            Workouts = workouts;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        } 
    }
}
