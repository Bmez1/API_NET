using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        public ICourseRepository CursoContext { get; }
        public IUserRepository UserContext { get; }
        public IStudentRepository StudentContext { get; }

        void Save();
    }
}
