using System.ComponentModel.DataAnnotations;

namespace EasyBus.Models
{
    public class Stop
    {
        /// <summary>
        /// Unique ID for each stop
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the stop
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }

    }
}
