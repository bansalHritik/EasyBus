using System;

namespace EasyBus.Data.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public Bus Bus { get; set; }

        public Route Route { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public float Fare { get; set; }
    }
}
