using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Burro")]
        public string Titulo { get; set; }
        
        public string Diretor { get; set; }
    }
}
