using System;

namespace EasyBus.Shared.Repository.Models
{
    public class BusSearchOption
    {
        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }

        public int? SourceId { get; set; }

        public int? DestId { get; set; }

        public short? MinCapacity { get; set; }


    }
}
