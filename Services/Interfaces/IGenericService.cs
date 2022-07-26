namespace UniversityAPI.Services.Interfaces
{
    public interface IGenericService<TEntity>
    {
        IEnumerable<TEntity> GetPagination(int numPagina, int numItems);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
