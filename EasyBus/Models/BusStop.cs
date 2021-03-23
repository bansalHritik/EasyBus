using EasyBus.EntityDataModels.Models;
using System;

namespace EasyBus.Models
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
