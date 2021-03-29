using System.ComponentModel.DataAnnotations;

namespace EasyBus.Shared.Infrastructure.Business.Models
{
    public class NewStopModel
    {
        [Required]
        public string Name { get; set; }
    }
}
