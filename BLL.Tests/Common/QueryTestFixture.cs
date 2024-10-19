using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using UoW;
using Repository;
using AutoMapper;
using CommandsAndQueries;
using UI.WebAPI;
using Xunit;


namespace BLL.Tests
{
    public class QueryTestFixture : IDisposable
    {
        private readonly FitnessContext context;
        private readonly IGenericRepository<Club> clubRepository;
        private readonly IGenericRepository<ClubPass> clubPassRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Workout> workoutRepository;
        public IUnitOfWork unitOfWork;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            clubRepository = new ContextRepository<Club>(context);
            clubPassRepository = new ContextRepository<ClubPass>(context);
            userRepository = new ContextRepository<User>(context);
            workoutRepository = new ContextRepository<Workout>(context);

            unitOfWork = new UnitOfWork(context, clubRepository, clubPassRepository, userRepository, workoutRepository);
            var configurationProvider = new MapperConfiguration(cfg =>
            cfg.AddProfiles(new List<Profile>()
            {

                new ClubMapper(),
                new ClubPassMapper(),
                new UserMapper(),
                new WorkoutMapper(),

                new ClubModelMapper(),
                new ClubPassModelMapper(),
                new UserModelMapper(),
                new WorkoutModelMapper()
            }));
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
