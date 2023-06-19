using API.Models;

namespace API.Repositories
{
    public interface IGenericRepo<TEntity, TKey>
    {
            IEnumerable<TEntity> GetAll();
            TEntity? GetByKey(TKey key);
            int Insert(TEntity entity);
            int Update(TEntity entity);
            int Delete(TKey key);

    }
}
