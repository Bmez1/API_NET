using UniversityAPI.Contracts;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Services.Clases
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IRepositoryWrapper repository) : base(repository)
        {
        }

        // Metodos de la interfaz
        public void Add(User entity)
        {
            repository.UserContext.Create(entity);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.UserContext.Delete(id);
            repository.Save();
        }

        public IEnumerable<User> GetAll()
        {
            return repository.UserContext.GetAll();
        }

        public User GetById(int id)
        {
            return repository.UserContext.GetById(id);
        }

        public IEnumerable<User> GetPagination(int numPagina, int numItems)
        {
            return repository.UserContext.GetPagination(numPagina, numItems);
        }

        public void Update(User entity)
        {
            repository.UserContext.Update(entity);
            repository.Save();
        }

        // Metodos propios
        public IEnumerable<User> GetUsersByEmail(string email)
        {
            return repository.UserContext.GetByCondition(x => x.Email.Equals(email));
        }

    }
}
