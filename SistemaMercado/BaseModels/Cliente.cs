using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public int EnderecoID{ get; set; }
    }
}
