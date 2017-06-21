using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome{ get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
