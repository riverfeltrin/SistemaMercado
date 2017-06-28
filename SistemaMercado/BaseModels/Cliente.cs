using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseModels
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required]
        //validar o cpf
        public string CPF { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("_Endereco")]
        public int EnderecoID { get; set; }

        public virtual Endereco _Endereco { get; set; }



    }
}
