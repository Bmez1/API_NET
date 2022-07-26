using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Apellidos { get; set; } = string.Empty;
        [Required]
        public int Edad { get; set; }
        [Required]
        public List<Course> Cursos { get; set; } = new List<Course>();
    }
}
