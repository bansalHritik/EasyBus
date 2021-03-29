using System;

namespace EasyBus.Shared.Infrastructure.DTOs
{
    public class BookingDTO
    {
        public int ArrivalStopId { get; set; }

        public int DepartureStopId { get; set; }

        public DateTime DateAndTime { get; set; }

        public short NumberOfSeats { get; set; }

        public int BusId { get; set; }
    }
}