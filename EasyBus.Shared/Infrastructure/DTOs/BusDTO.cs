namespace EasyBus.Shared.Infrastructure.DTOs
{
    /// <summary>
    /// Defines the <see cref="BusDTO" />.
    /// </summary>
    public class BusDTO
    {
        /// <summary>
        /// Gets or sets the VechileNumber.
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets the Capacity.
        /// </summary>
        public short Capacity { get; set; }

        /// <summary>
        /// Gets or sets the SeatsBooked.
        /// </summary>
        public short SeatsBooked { get; set; }

        /// <summary>
        /// Gets or sets the Details.
        /// </summary>
        public string Description { get; set; }

        public string Operator { get; set; }
    }
}
