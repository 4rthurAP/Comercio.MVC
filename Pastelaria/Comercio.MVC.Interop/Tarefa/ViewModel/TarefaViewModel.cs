using Comercio.MVC.Interop.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Interop.Tarefa.ViewModel
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool IsDone { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
