using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebAPI
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public Guid ClubPassId { get; set; }
        public Guid WorkoutId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
    }
}
