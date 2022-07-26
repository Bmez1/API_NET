using UniversityAPI.Database;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Repositories.Clases
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDBContext context) : base(context)
        {
        }
    }
}
