using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class ClubModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ClubPassModel> ClubPasses { get; set; }
        public List<WorkoutModel> Workouts { get; set; }

        public override string ToString()
        {
            return $"Фітнес клуб {Name}" +
                $"\nМісто: {City}" +
                $"\nАдреса: {Address}"+
                $"\nАбонементи: {ClubPasses}"+
                $"\nЗаняття за записом: {Workouts}";
        }
    }
}
