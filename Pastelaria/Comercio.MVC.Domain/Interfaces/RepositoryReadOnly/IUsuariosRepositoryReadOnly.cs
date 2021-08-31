using Comercio.MVC.Domain.Models.UsuarioModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Domain.Interfaces.RepositoryReadOnly
{
    public interface IUsuarioRepositoryReadOnly
    {
        bool VerificaTelefoneCelularExiste(string telefoneFixo);
        bool VerificaTelefoneFixoExiste(string telefoneCelular);
        bool VerificaSeUsuarioExiste(int id);
        Usuario BuscaUsuarioPorId(int id);
        bool VerificaEmailUsuarioExiste(string email);
        Usuario VerificaLogin(string email, string senha);
        ICollection<Usuario> BuscaUsuarios();

        bool ExisteUsuarios();
    }
}
