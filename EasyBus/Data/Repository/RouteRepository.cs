namespace EasyBus.Data.Repository
{
    using EasyBus.Data.Contexts;
    using EasyBus.Data.Models;
    using EasyBus.Shared.Repository;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="RouteRepository" />.
    /// </summary>
    public class RouteRepository : Repository<Route>, IRouteRepository<Route>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationContext"/>.</param>
        public RouteRepository(ApplicationContext context) : base(context)
        {
        }

        /// <summary>
        /// The Find.
        /// </summary>
        /// <param name="sourceStopId">The sourceStopId<see cref="long"/>.</param>
        /// <param name="destStopId">The destStopId<see cref="long"/>.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        public Route Find(long sourceStopId, long destStopId)
        {
            return Find(route => route.SourceStop.Id == sourceStopId
                                && route.DestStop.Id == destStopId)
                   .SingleOrDefault();
        }
    }
}
