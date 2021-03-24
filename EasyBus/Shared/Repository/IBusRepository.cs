using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Repository
{
    public interface IBusRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

    }
}
