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
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Estudiante>? Estudiantes { get; set; }
    }
}
