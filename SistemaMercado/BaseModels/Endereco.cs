﻿using System.ComponentModel.DataAnnotations;

namespace BaseModels
{
    public class Endereco
    {
        [Key]
        public int EnderecoID { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="##.###-###")]
        public string Cep { get; set; }

      
    }
}
