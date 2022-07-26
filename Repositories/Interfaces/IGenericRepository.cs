using System.Linq.Expressions;

namespace UniversityAPI.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetPagination(int numPagina, int numItems);
        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Save();
    }
}
