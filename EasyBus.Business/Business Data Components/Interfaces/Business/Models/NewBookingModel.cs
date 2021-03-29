namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewBookingModel
    {
        public int BusRouteId { get; set; }

        public string UserId { get; set; }

        public short SeatsBooked { get; set; }
    }
}