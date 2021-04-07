using System.ComponentModel.DataAnnotations;

namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewRouteModel
    {
        [Required]
        public int SourceId { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}