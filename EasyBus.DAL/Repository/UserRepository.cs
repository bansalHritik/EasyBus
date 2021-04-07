using EasyBus.DAL.Interfaces.Repository;
using EasyBus.Data.Contexts;
using EasyBus.Data.Repository;

namespace EasyBus.DAL.Repository
{
    internal class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}