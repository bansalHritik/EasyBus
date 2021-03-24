using EasyBus.Data.Models;
using System;

namespace EasyBus.Data.Models
{
    public class BusStop
    {
        public long Id { get; set; }

        public Bus Bus { get; set; }

        public Stop Stop { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

    }
}
