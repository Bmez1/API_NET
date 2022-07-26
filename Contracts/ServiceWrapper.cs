using UniversityAPI.Services.Clases;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Contracts
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        private ICourseService _courseService;
        private IUserService _userService;
        private IStudentService _studentService;

        public ICourseService CourseService => _courseService ?? new CourseService(_repositoryWrapper);
        public IUserService UserService => _userService ?? new UserService(_repositoryWrapper);
        public IStudentService StudentService => _studentService ?? new StudentService(_repositoryWrapper);

        public ServiceWrapper(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}
