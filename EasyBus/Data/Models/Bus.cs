using System.ComponentModel.DataAnnotations;

namespace EasyBus.Data.Models
{
    public class Bus
    {

        /// <summary>
        /// Denotes unique identification number of the bus. 
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Denotes government registered vechile number.
        /// </summary>
        [Required, StringLength(50)]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Denotes total number of seats in the bus.
        /// </summary>
        public short Capacity { get; set; }

        /// <summary>
        /// Denotes number of seats booked.
        /// </summary>
        public short SeatsBooked { get; set; }

        /// <summary>
        /// Denotes operator or owner of the bus.
        /// </summary>
        public string Operator { get; set; }
        //public virtual User User;

        /// <summary>
        /// Any other details or description of the bus.
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; }

    }
}
