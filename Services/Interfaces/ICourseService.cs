using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services.Interfaces
{
    public interface ICourseService : IGenericService<Course>
    {
        IEnumerable<Course> GetByLevelWhitOneEstudentOrMore(int level);
        IEnumerable<Course> GetByLevelAndCategory(int level, Category categoria);
        IEnumerable<Course> GetWithoutStudents();

    }
}
