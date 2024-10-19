using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Workout
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
    }
}
