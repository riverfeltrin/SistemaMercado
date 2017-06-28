using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class ItemVenda
    {
        [Key]
        public int ItemVendaID { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
