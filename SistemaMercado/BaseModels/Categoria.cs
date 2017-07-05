using System.ComponentModel.DataAnnotations;

namespace BaseModels
{
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }

        [Display(Name ="Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome{ get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
