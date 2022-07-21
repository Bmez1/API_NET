using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public enum Nivel
    {
        Básico, Intermedio, Avanzado
    }
    public class Curso : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Básico;
        [Required]
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        [Required]
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
