using EasyBus.Data.Models;
using System.Collections.Generic;

namespace EasyBus.Shared.Repository
{
    public interface IRouteRepository : IRepository<Route>
    {
        new Route Get(int routeId);

        new IEnumerable<Route> GetAll();

        Route Find(int sourceStopId, int destStopId);

        Route Find(string sourceName, string destName);

        IEnumerable<Route> GetAllRoutesFromSource(int sourceId);

        IEnumerable<Route> GetAllRoutesFromSource(string sourceName);

        IEnumerable<Route> GetAllRoutesToDest(int destId);

        IEnumerable<Route> GetAllRoutesToDest(string destName);
    }
}