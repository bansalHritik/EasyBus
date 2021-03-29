using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using System.Collections.Generic;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IRouteBDC
    {
        OperationResult Add(NewRouteModel route);

        OperationResult Remove(int routeId);

        OperationResult Update(int routeId, RouteDTO routeDTO);

        OperationResult<RouteDTO> Get(int routeId);

        OperationResult<IEnumerable<RouteDTO>> GetAll();

        OperationResult<IEnumerable<RouteDTO>> GetAllFromSource(int sourceId);

        OperationResult<IEnumerable<RouteDTO>> GetAllFromSource(string sourceName);

        OperationResult<IEnumerable<RouteDTO>> GetAllFromDestination(int destinationId);

        OperationResult<IEnumerable<RouteDTO>> GetAllFromDestination(string destinationName);
    }
}