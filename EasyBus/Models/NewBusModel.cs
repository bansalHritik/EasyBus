using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Models
{
    public class NewBusModel
    {

        [Required]
        public string VechileNumber { get; set; }

        public short Capacity { get; set; }

        public short SeatsBooked { get; set; }

        [Required]
        public string Operator { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
