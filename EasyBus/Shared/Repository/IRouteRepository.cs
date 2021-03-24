namespace EasyBus.Shared.Repository
{
    public interface IRouteRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity Find(long sourceStopId, long destStopId);
    }
}
