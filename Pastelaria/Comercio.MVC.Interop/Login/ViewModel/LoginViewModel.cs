﻿using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Interop.Login.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail", Description = "Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail inválido.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O e-mail deve de 5 a 60 dígitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Email { get; set; }

        [Display(Name = "Senha", Description = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve ter de 8 a 20 dígitos")]
        [Required(ErrorMessage = "Preencha este campo")]
        public string Senha { get; set; }
    }
}
