using UniversityAPI.Database;
using UniversityAPI.Repositories.Clases;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Contracts
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private readonly UniversityDBContext _dbContext;
        private ICourseRepository _courseRepository;
        private IUserRepository _userRepository;
        private IStudentRepository _studentRepository;

        public ICourseRepository CursoContext => _courseRepository ?? new CourseRepository(_dbContext);
        public IUserRepository UserContext => _userRepository ?? new UserRepository(_dbContext);
        public IStudentRepository StudentContext => _studentRepository ?? new StudentRepository(_dbContext);

        public RepositoryWrapper(UniversityDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
