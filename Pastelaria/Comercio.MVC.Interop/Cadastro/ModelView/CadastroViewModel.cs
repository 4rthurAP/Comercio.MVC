using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Interop.Cadastro
{
    public class CadastroViewModel
    {
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo nome deve ter de 3 a 150 dígitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Nome { get; set; }

        [Display(Name = "TelefoneFixo", Description = "TelefoneFixo")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O número de telefone deve ter de 5 a 11 digitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string TelefoneFixo { get; set; }

        [Display(Name = "TelefoneCelular", Description = "TelefoneCelular")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O número de telefone deve ter de 5 a 11 digitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string TelefoneCelular { get; set; }

        [Display(Name = "E-mail", Description = "Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail inválido.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "O e-mail deve de 5 a 60 dígitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Email { get; set; }

        [Display(Name = "E Admin", Description = "E Admin")]
        public string IsAdmin { get; set; }

        [Display(Name = "Data de nascimento", Description = "Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Preencha este campo")]
        public string DataDeNascimento { get; set; }

        [Display(Name = "Endereco", Description = "Endereco")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Endereco { get; set; }

        [Display(Name = "Senha", Description = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve ter de 8 a 20 dígitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar senha", Description = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Preencha este campo")]
        public string ConfirmarSenha { get; set; }
    }
}
