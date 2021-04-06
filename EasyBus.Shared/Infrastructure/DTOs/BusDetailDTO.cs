using System;

namespace EasyBus.Shared.Infrastructure.DTOs
{
    public class BusDetailDTO
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public BusDTO Bus { get; set; }

        public RouteDTO Route { get; set; }

        public float Fare { get; set; }
    }
}