using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContextRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly FitnessContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public ContextRepository(FitnessContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }
        public TEntity Get(Guid id)
        {
            return _dbSet.Find(id);
        }
        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<User> GetUserAsync(Guid id) =>
            await _context.Users.Include("ClubPass").Include("Workout")
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            if (typeof(TEntity) == typeof(Club))
                return await _dbSet.AsNoTracking().Include("ClubPasses").Include("Workouts").ToListAsync(cancellationToken);
            if (typeof(TEntity) == typeof(User))
                return await _dbSet.AsNoTracking().Include("ClubPass").Include("Workout").ToListAsync(cancellationToken);
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
