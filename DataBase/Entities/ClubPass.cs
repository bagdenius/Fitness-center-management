using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class ClubPass
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
    }
}
