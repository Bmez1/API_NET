using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPI.Models.DataModels
{
    public class Categoria : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
