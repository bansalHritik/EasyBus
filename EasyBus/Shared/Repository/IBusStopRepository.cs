using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Repository
{
    public interface IBusStopRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
