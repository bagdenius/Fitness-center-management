using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebAPI
{
    public class UpdateClubPassModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
    }
}
