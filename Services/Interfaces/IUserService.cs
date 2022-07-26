using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        IEnumerable<User> GetUsersByEmail(string email);
    }
}
