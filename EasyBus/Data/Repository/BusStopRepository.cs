using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;

namespace EasyBus.Data.Repository
{
    public class BusStopRepository: Repository<BusStop>, IBusStopRepository<BusStop>
    {
        public BusStopRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
