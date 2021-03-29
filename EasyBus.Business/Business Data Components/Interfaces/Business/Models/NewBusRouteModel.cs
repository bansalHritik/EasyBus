using System;

namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewBusRouteModel
    {
        public int BusId { get; set; }

        public int RouteId { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public float Fare { get; set; }
    }
}