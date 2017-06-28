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

        public List<ItemVenda> Itens { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        public virtual Cliente _Cliente { get; set; }

    }
}
