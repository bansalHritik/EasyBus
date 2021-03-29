using System.ComponentModel.DataAnnotations;

namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewBusModel
    {
        [Required]
        public string VechileNumber { get; set; }

        [Required]
        public string Operator { get; set; }

        public short Capacity { get; set; }

        public short SeatsBooked { get; set; }

        public string Description { get; set; }
    }
}