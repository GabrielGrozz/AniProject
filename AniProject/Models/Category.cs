using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AniProject.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O categoria deve ter 1 ou mais caracteres, com o limite de 50 caracteres")]
        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para a categoria")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "A descrição da categoria deve ter 10 ou mais caracteres, com o limite de 400 caracteres")]
        [Display(Name = "Descrição")]
        public string CategoryDescription { get; set; }

        [Required(ErrorMessage = "Informe um anime para ")]
        [Display(Name = "Animes")]
        public List<Anime> Animes { get; set; }
    }
}
