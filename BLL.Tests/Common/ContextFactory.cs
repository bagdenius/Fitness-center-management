using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public static class ContextFactory
    {
        public static Guid ClubIdForUpdate = Guid.NewGuid();
        public static Guid ClubIdForDelete = Guid.NewGuid();

        public static Guid ClubPassIdForUpdate = Guid.NewGuid();
        public static Guid ClubPassIdForDelete = Guid.NewGuid();

        public static Guid UserIdForUpdate = Guid.NewGuid();
        public static Guid UserIdForDelete = Guid.NewGuid();

        public static Guid WorkoutIdForUpdate = Guid.NewGuid();
        public static Guid WorkoutIdForDelete = Guid.NewGuid();

        public static FitnessContext Create() 
        {
            var options = new DbContextOptionsBuilder<FitnessContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FitnessContext(options);
            context.Database.EnsureCreated();
            context.Clubs.AddRange(
                new Club 
                {
                    Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB"),
                    Name = "Name1",
                    City = "City1",
                    Address = "Address1"
                },
                new Club
                {
                    Id = Guid.Parse("AD442107-E5F8-4623-A309-D82970836F15"),
                    Name = "Name2",
                    City = "City2",
                    Address = "Address2"
                },
                new Club
                {
                    Id = ClubIdForUpdate,
                    Name = "Name3",
                    City = "City3",
                    Address = "Address3"
                },
                new Club
                {
                    Id = ClubIdForDelete,
                    Name = "Name4",
                    City = "City4",
                    Address = "Address4"
                });
            context.ClubsPass.AddRange(
                new ClubPass
                {
                    Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15"),
                    Name = "Name1",
                    ClubId = ClubIdForUpdate,
                    AvailableNumberOfVisits = 1, 
                    Price = 1,
                    IsNet = false
                },
                new ClubPass
                {
                    Id = Guid.Parse("CDF6BD57-3512-4206-95B3-819AC8630DB7"),
                    Name = "Name2",
                    ClubId = ClubIdForUpdate,
                    AvailableNumberOfVisits = 2,
                    Price = 2,
                    IsNet = true
                },
                new ClubPass
                {
                    Id = ClubPassIdForUpdate,
                    Name = "Name3",
                    ClubId = ClubIdForUpdate,
                    AvailableNumberOfVisits = 3,
                    Price = 3,
                    IsNet = false
                },
                new ClubPass
                {
                    Id = ClubPassIdForDelete,
                    Name = "Name4",
                    ClubId = ClubIdForUpdate,
                    AvailableNumberOfVisits = 4,
                    Price = 4,
                    IsNet = false
                });
            context.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF"),
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    AvailableNumberOfVisitsByClubPass = 1,
                    ClubPassId = ClubPassIdForUpdate,
                    WorkoutId = WorkoutIdForUpdate
                 },
                new User
                {
                    Id = Guid.Parse("4C1F38F2-AF12-40EC-A8D4-FB439285ABF9"),
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    AvailableNumberOfVisitsByClubPass = 2,
                    ClubPassId = ClubPassIdForUpdate,
                    WorkoutId = WorkoutIdForUpdate
                },
                new User
                {
                    Id = UserIdForUpdate,
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    AvailableNumberOfVisitsByClubPass = 3,
                    ClubPassId = ClubPassIdForUpdate,
                    WorkoutId = WorkoutIdForUpdate
                },
                new User
                {
                    Id = UserIdForDelete,
                    FirstName = "FirstName4",
                    LastName = "LastName4",
                    AvailableNumberOfVisitsByClubPass = 4,
                    ClubPassId = ClubPassIdForUpdate,
                    WorkoutId = WorkoutIdForUpdate
                });
            context.Workouts.AddRange(
                new Workout 
                {
                    Id = Guid.Parse("CB500691-F0F5-4BC3-A003-4485A4700911"),
                    Type = "Type1",
                    Price = 1,
                    Time = DateTime.Today,
                    ClubId = ClubIdForUpdate
                },
                new Workout
                {
                    Id = Guid.Parse("104BF890-C539-4194-B3EC-C416DF17E355"),
                    Type = "Type2",
                    Price = 2,
                    Time = DateTime.Today,
                    ClubId = ClubIdForUpdate
                },
                new Workout
                {
                    Id = WorkoutIdForUpdate,
                    Type = "Type3",
                    Price = 3,
                    Time = DateTime.Today,
                    ClubId = ClubIdForUpdate
                },
                new Workout
                {
                    Id = WorkoutIdForDelete,
                    Type = "Type4",
                    Price = 4,
                    Time = DateTime.Today,
                    ClubId = ClubIdForUpdate
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(FitnessContext context) 
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
