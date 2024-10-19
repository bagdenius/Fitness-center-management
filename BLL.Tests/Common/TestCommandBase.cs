using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using UoW;
using Repository;

namespace BLL.Tests
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly FitnessContext context;
        private readonly IGenericRepository<Club> clubRepository;
        private readonly IGenericRepository<ClubPass> clubPassRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Workout> workoutRepository;
        public IUnitOfWork unitOfWork;

        public TestCommandBase()
        {
            context = ContextFactory.Create();
            clubRepository = new ContextRepository<Club>(context);
            clubPassRepository = new ContextRepository<ClubPass>(context);
            userRepository = new ContextRepository<User>(context);
            workoutRepository = new ContextRepository<Workout>(context);
            unitOfWork = new UnitOfWork(context, clubRepository, clubPassRepository, userRepository, workoutRepository);
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }
}
