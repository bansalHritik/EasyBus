using EasyBus.Shared.Functional;
using System.ComponentModel.DataAnnotations;

namespace EasyBus.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string PassengerName { get; set; }

        public BusRoute BusRoute { get; set; }

        [Range(1, 120)]
        public byte Age { get; set; }


        public string IdProof { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10)]
        public string MobileNumber { get; set; }

        public BookingStatusType Status { get; set; }

        public string ByUser { get; set; }
    }
}