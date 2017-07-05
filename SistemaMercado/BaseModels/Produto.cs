using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseModels
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name ="Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name ="Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Display(Name ="Categoria")]
        public int CategoriaID { get; set; }

        [Display(Name ="Categoria")]
        public virtual Categorias _Categoria { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public bool Ativo { get; set; }
    }
}
