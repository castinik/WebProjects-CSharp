using System;
using System.ComponentModel.DataAnnotations;

namespace RistoWeb.Entity
{
    public class Reservation
    {
        [Key]
        public Guid ResID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateRes { get; set; }
        public int Seats { get; set; }
        public bool Dinner { get; set; }
        public bool Lunch { get; set; }
    }
}
