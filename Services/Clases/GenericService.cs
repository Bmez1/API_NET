using UniversityAPI.Contracts;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Services.Clases
{
    public abstract class GenericService<TEntity> where TEntity : class
    {
        protected readonly IRepositoryWrapper repository;

        public GenericService(IRepositoryWrapper repository)
        {
            this.repository = repository; 
        }
    }
}
