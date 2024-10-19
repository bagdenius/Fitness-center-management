using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Club
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ClubPass> ClubPasses { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
