using UniversityAPI.Contracts;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Services.Clases
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(IRepositoryWrapper repository) : base(repository)
        {
        }

        // Metodos de la interfaz
        public void Add(Course entity)
        {
            repository.CursoContext.Create(entity);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.CursoContext.Delete(id);
            repository.Save();
        }

        public IEnumerable<Course> GetAll()
        {
            return repository.CursoContext.GetAll();
        }

        public Course GetById(int id)
        {
            return repository.CursoContext.GetById(id);
        }

        public void Update(Course entity)
        {
            repository.CursoContext.Update(entity);
            repository.Save();
        }

        public IEnumerable<Course> GetPagination(int numPagina, int numItems)
        {
            return repository.CursoContext.GetPagination(numPagina, numItems);
        }

        // Metodos propios
        public IEnumerable<Course> GetByLevelAndCategory(int level, Category categoria)
        {
            return repository.CursoContext.GetByCondition(x => x.Categorias.Any(c => c.Name.Equals(categoria.Name)) && x.Nivel == (Nivel)level);
        }

        public IEnumerable<Course> GetByLevelWhitOneEstudentOrMore(int level)
        {
            return repository.CursoContext.GetByCondition(c => c.Nivel == (Nivel)level && c.Estudiantes.Count > 0);
        }

        public IEnumerable<Course> GetWithoutStudents()
        {
            return repository.CursoContext.GetByCondition(c => c.Estudiantes.Count < 1);
        }
    }
}
