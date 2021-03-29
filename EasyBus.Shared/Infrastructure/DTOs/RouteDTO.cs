using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Infrastructure.DTOs
{
    public class RouteDTO
    {
        public StopDTO SourceStop { get; set; }

        public StopDTO DestinationStop { get; set; }
    }
}
