using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class ClubPassModel
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
        
        public override string ToString()
        {
            return $"Абонемент {Name}" +
                $"\nКлуб: {ClubId}" +
                $"\nМережевий абонемент (так/ні): {IsNet}" +
                $"\nЦіна: {Price} грн.";
        }
    }
}
