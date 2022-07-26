using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public enum Nivel
    {
        Básico, Intermedio, Avanzado
    }
    public class Course : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Básico;
        [Required]
        public List<Category> Categorias { get; set; } = new List<Category>();
        [Required]
        public List<Student> Estudiantes { get; set; } = new List<Student>();
    }
}
