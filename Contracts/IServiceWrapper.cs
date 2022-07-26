using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Contracts
{
    public interface IServiceWrapper
    {
        public ICourseService CourseService { get; }
        public IUserService UserService { get; }
        public IStudentService StudentService { get; }

    }
}
