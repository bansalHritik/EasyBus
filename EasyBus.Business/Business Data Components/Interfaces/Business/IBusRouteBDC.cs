using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Models;
using System;
using System.Collections.Generic;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IBusRouteBDC : IBDC
    {
        OperationResult<BusRouteDTO> Get(int id);
        OperationResult<IEnumerable<BusDetailDTO>> GetAll();
        IEnumerable<BusDetailDTO> GetBusWithDestination(int destId);
        IEnumerable<BusDetailDTO> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime);
        IEnumerable<BusDetailDTO> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime, short capacity);

        IEnumerable<BusDetailDTO> GetBusWithSource(int sourceId);
        IEnumerable<BusDetailDTO> GetBusWithSource(int destId, DateTime fromTime, DateTime toTime);

        IEnumerable<BusDetailDTO> GetBusWithSource(int destId, DateTime fromTime, DateTime toTime, short capacity);
        OperationResult<IEnumerable<BusDetailDTO>> GetBusesWithRoute(int routeId);

        OperationResult<IEnumerable<BusDetailDTO>> GetAllBuses(BusSearchOption options);

        OperationResult Add(NewBusRouteModel busRouteDTO);

        OperationResult Update(int busRouteId, NewBusRouteModel busRouteDTO);

        OperationResult Remove(int busRouteId);
    }
}