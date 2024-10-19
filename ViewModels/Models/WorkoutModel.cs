using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class WorkoutModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public Guid ClubId { get; set; }
 
        public override string ToString()
        {
            return $"Тренування {Type}" +
                $"\nКлуб: {ClubId}" +
                $"\nЦіна: {Price} грн."; 
        }
    }
}
