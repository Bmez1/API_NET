using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services.Interfaces
{
    public interface IStudentService : IGenericService<Student>
    {
        IEnumerable<Student> GetAdults();
        IEnumerable<Student> GetWithCourseOrMore();
    }
}
