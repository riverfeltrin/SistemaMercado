using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseModels
{
    public class Venda
    {
        [Key]
        public int VendaID { get; set; }

        [Required]
        public string FormaPag { get; set; }

        public ICollection<Produto> Itens { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public virtual Venda _Venda { get; set; }
    }
}
