namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewBookingModel
    {
        public int BusRouteId { get; set; }

        public string PassengerName { get; set; }

        public byte Age { get; set; }

        public string IdProof { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }
    }
}