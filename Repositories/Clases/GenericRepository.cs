using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniversityAPI.Database;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Repositories.Clases
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly UniversityDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(UniversityDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity) => _dbSet.Add(entity);

        public void Delete(int id)
        {
            var itemDelete = _dbSet.Find(id);
            if (itemDelete is not null)
            {
                _dbSet.Remove(itemDelete);
            }
        }

        public IEnumerable<TEntity> GetPagination(int numPagina, int numItems)
        {
            int startIndex = (numPagina - 1) * numItems;
            var items = _dbSet.Skip(startIndex).Take(numItems).ToList();
            return items;
        }

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

        public TEntity GetById(int id) => _dbSet.Find(id);

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save() => _context.SaveChanges();

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression) => _dbSet.Where(expression).AsNoTracking();


    }
}
