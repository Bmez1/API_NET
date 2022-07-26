using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Database
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        // Agregando las tablas
        public DbSet<User>? Users  { get; set; }
        public DbSet<Course>? Cursos { get; set; }
        public DbSet<Category>? Categorias { get; set; }
        public DbSet<Student>? Estudiantes { get; set; }
    }
}
