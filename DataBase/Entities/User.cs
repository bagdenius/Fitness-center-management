using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AvailableNumberOfVisitsByClubPass { get; set; }
        public Guid? ClubPassId { get; set; }
        public ClubPass ClubPass { get; set; }
        public Guid? WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
