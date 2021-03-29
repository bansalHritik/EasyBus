using EasyBus.Data.Models;

namespace EasyBus.Shared.Repository
{
    public interface IBusRepository : IRepository<Bus>
    {
        Bus Get(string vechileNumber);

        bool ChangeSeatBookedCount(int busId, short count);
    }
}