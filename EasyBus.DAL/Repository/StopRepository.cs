using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;

namespace EasyBus.Data.Repository
{
    public class StopRepository : Repository<Stop>, IStopRepository
    {
        public StopRepository(ApplicationContext context) : base(context)
        {
        }
    }
}