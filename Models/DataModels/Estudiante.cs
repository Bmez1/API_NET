using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Estudiante : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Apellidos { get; set; } = string.Empty;
        [Required]
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
