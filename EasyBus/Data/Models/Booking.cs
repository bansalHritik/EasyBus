using System;

namespace EasyBus.Data.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public string User { get; set; }

        public Stop ArrivalStop { get; set; }

        public Stop DepartureStop { get; set; }

        public long Fare { get; set; }

        public DateTime DateAndTime { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
