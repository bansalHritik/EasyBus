using EasyBus.Data.Models;
using EasyBus.Data.Contexts;
using EasyBus.Shared.Repository;

namespace EasyBus.Data.Repository
{
    public class BusRepository : Repository<Bus>, IBusRepository<Bus>
    {
        public BusRepository(ApplicationContext context) : base(context) { }

        
    }
}
