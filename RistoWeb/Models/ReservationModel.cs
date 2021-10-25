using RistoWeb.Entity;

namespace RistoWeb.Models
{
    public class ReservationModel
    {
        public int maxSeats = 10;
        public Reservation reservation { get; set; }
        public bool isAlreadyReserved { get; set; }
        public bool successReservation { get; set; }
        public bool seatsFull { get; set; }
    }
}
