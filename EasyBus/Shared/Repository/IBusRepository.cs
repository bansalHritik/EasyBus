namespace EasyBus.Shared.Repository
{
    public interface IBusRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

    }
}
