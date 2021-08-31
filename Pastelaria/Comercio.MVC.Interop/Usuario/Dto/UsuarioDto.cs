using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Interop.Usuario.Dto
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public bool IsAdmin { get; set; }
        public string Endereco { get; set; }
    }
}
