using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comercio.MVC.Interop.Usuario.Dto;
using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Interfaces.Repository;
using Comercio.MVC.Services.Criptografia;
using System.Security.Cryptography;

namespace Comercio.MVC.Application.Usuario
{
   public class UsuarioApplication : IUsuarioApplication
   {
        private readonly IUsuarioRepositoryReadOnly _usuarioRepositoryReadOnly;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioApplication(IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioRepositoryReadOnly = usuarioRepositoryReadOnly;
        }

        public bool EmailExiste(string email)
        {
            return _usuarioRepositoryReadOnly.VerificaEmailUsuarioExiste(email);
        }

        public bool TelefoneCelularExiste(string telefoneCelular)
        {
            return  _usuarioRepositoryReadOnly.VerificaTelefoneCelularExiste(telefoneCelular);
        }

        public bool TelefoneFixoExiste(string telefoneFixo)
        {
            return _usuarioRepositoryReadOnly.VerificaTelefoneFixoExiste(telefoneFixo);
        }

        public Domain.Models.UsuarioModel.Usuario UsuarioBuscaId(int id)
        {
            return _usuarioRepositoryReadOnly.BuscaUsuarioPorId(id);
        }

        public Domain.Models.UsuarioModel.Usuario BuscaUsuarioPorId(int id)
        {
            return _usuarioRepositoryReadOnly.BuscaUsuarioPorId(id);
        }

        public ICollection<Domain.Models.UsuarioModel.Usuario> BuscaUsuarios()
        {
            return _usuarioRepositoryReadOnly.BuscaUsuarios();
        }

        public Domain.Models.UsuarioModel.Usuario VerificaLogin(string email, string senha)
        {
            return _usuarioRepositoryReadOnly.VerificaLogin(email, senha);
        }

        public async Task Cadastrar(Domain.Models.UsuarioModel.Usuario usuario)
        {
            Cryptography cryptography = new Cryptography(MD5.Create());

            usuario.Senha = cryptography.HashGenerate(usuario.Senha);

            await _usuarioRepository.GravarUsuario(usuario);
        }

        public async Task Deletar(Domain.Models.UsuarioModel.Usuario usuario)
        {
           await _usuarioRepository.ExcluirUsuario(usuario);
        }

        public async Task Alterar(Domain.Models.UsuarioModel.Usuario usuario)
        {
            await _usuarioRepository.AtualizarUsuario(usuario);
        }
   }
}
