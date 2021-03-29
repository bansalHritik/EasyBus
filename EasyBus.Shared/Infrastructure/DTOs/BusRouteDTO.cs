using System;

namespace EasyBus.Shared.Infrastructure.DTOs
{
    public class BusRouteDTO
    {
        public BusDTO Bus { get; set; }
        public RouteDTO Route { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}