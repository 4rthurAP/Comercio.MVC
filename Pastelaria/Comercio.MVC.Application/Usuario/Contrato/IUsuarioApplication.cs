using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Application.Usuario.Contrato
{
    public interface IUsuarioApplication
    {
        Domain.Models.UsuarioModel.Usuario UsuarioBuscaId(int id);
        bool EmailExiste(string email);
        bool TelefoneFixoExiste(string telefoneFixo);
        bool TelefoneCelularExiste(string telefoneCelular);
        Domain.Models.UsuarioModel.Usuario VerificaLogin(string email, string senha);
        Task Cadastrar(Domain.Models.UsuarioModel.Usuario usuario);
        Task Deletar(Domain.Models.UsuarioModel.Usuario usuario);
        Task Alterar(Domain.Models.UsuarioModel.Usuario usuario);
        ICollection<Domain.Models.UsuarioModel.Usuario> BuscaUsuarios();

    }
}
