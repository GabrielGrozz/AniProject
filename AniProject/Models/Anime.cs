using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AniProject.Models
{
    [Table("Animes")]
    public class Anime
    {
        [Key]
        public int AnimeId { get; set; }

        [Required(ErrorMessage = "Informe o nome do anime")]
        [StringLength(150, MinimumLength = 1, ErrorMessage ="O nome deve ter 1 ou mais caracteres, com o limite de 150 caracteres")]
        [Display(Name = "Nome")]
        public string AnimeName { get; set; }

        [Required(ErrorMessage = "Informe a descrição do anime")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "A descrição do anime deve ter 10 ou mais caracteres, com o limite de 400 caracteres")]
        [Display(Name = "Descrição")]
        public string AnimeDescription  { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
