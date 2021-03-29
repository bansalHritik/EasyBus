using EasyBus.Shared.Functional;

namespace EasyBus.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string User { get; set; }

        public BusRoute BusRoute { get; set; }

        public short NumberOfSeats { get; set; }

        public BookingStatusType Status { get; set; }
    }
}