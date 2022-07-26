using UniversityAPI.Database;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Repositories.Clases
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(UniversityDBContext context) : base(context)
        {
        }

    }
}
