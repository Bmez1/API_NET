using UniversityAPI.Contracts;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Services.Clases
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(IRepositoryWrapper repository) : base(repository)
        {
        }

        public void Add(Student entity)
        {
            repository.StudentContext.Create(entity);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.StudentContext.Delete(id);
            repository.Save();
        }

        public IEnumerable<Student> GetAll()
        {
            return repository.StudentContext.GetAll();
        }

        public Student GetById(int id)
        {
            return repository.StudentContext.GetById(id);
        }

        public void Update(Student entity)
        {
            repository.StudentContext.Update(entity);
            repository.Save();
        }

        public IEnumerable<Student> GetPagination(int numPagina, int numItems)
        {
            return repository.StudentContext.GetPagination(numPagina, numItems);
        }


        // Metodos propios
        public IEnumerable<Student> GetWithCourseOrMore()
        {
            return repository.StudentContext.GetByCondition(x => x.Cursos.Count > 1);
        }

        public IEnumerable<Student> GetAdults()
        {
            return repository.StudentContext.GetByCondition(x => x.Edad > 17);
        }

    }
}
