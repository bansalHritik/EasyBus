namespace EasyBus.Shared.Infrastructure.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public BusRouteDTO BusRoute { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string IdProof { get; set; }

        public int BusId { get; set; }
    }
}