using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaMercado.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Key]
        public int ClienteID { get; set; }


        public string Nome { get; set; }


        //validar o cpf
        public string CPF { get; set; }


        public string Rua { get; set; }



        public int Numero { get; set; }


        public string Bairro { get; set; }

        public string Cidade { get; set; }


        public string Estado { get; set; }


        public string Cep { get; set; }

        [Required]
        public int EnderecoID { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As duas senhas precisam ser iguais!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]

        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As duas senhas precisam ser iguais!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
