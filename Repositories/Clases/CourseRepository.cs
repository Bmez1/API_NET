using UniversityAPI.Database;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Repositories.Clases
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityDBContext context) : base(context)
        {
        }

    }
}
