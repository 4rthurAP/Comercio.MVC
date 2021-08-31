using Comercio.MVC.Domain.Models.UsuarioModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task GravarUsuario(Usuario usuario);
        Task ExcluirUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
    }
}
