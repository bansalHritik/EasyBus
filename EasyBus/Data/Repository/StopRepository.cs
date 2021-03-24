using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;

namespace EasyBus.Data.Repository
{
    public class StopRepository : Repository<Stop>, IStopRepository<Stop>
    {
        public StopRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
