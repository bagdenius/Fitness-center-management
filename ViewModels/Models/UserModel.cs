using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AvailableNumberOfVisitsByClubPass { get; set; }
        public ClubPassModel ClubPass { get; set; }
        public WorkoutModel Workout { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}" +
                 $"\nАбонемент: {ClubPass}" +
                 $"\nЗаняття: {Workout}" + 
                 $"\nДоступна кількість відвідувань фітнес клубу за абонементом: {AvailableNumberOfVisitsByClubPass}";
                 
        }
    }
}
