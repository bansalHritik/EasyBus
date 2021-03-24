using System.ComponentModel.DataAnnotations;

namespace EasyBus.Data.Models
{
    public class Stop
    {
        /// <summary>
        /// Unique ID for each stop
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the stop
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }

    }
}
