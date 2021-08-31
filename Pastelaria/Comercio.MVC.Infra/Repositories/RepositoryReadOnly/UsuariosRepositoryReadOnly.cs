using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Infra.DataContext;
using Comercio.MVC.Services.Criptografia;
using Microsoft.EntityFrameworkCore;

namespace Comercio.MVC.Infra.Repositories.RepositoryReadOnly
{
    public class UsuarioRepositoryReadOnly : IUsuarioRepositoryReadOnly

    {
        private readonly Context _context;
        public UsuarioRepositoryReadOnly(Context context)
        {
            _context = context;
        }
        public bool VerificaTelefoneCelularExiste(string telefoneFixo)
        {
            return _context.Usuarios.Where(e => e.TelefoneCelular.Equals(telefoneFixo)).Any();
        }

        public bool VerificaTelefoneFixoExiste(string telefoneCelular)
        {
           
            return _context.Usuarios.Where(e => e.TelefoneFixo.Equals(telefoneCelular)).Any();
        }

        public bool VerificaSeUsuarioExiste(int id)
        {
            return  _context.Usuarios.Any(e => e.Id == id);
        }

        public bool VerificaEmailUsuarioExiste(string email)
        {
            return _context.Usuarios.Where(m => m.Email.Equals(email)).Any();
        }

        public Usuario VerificaLogin(string email, string senha)
        {
            Cryptography cryptography = new Cryptography(MD5.Create());
            string passwordCript = cryptography.HashGenerate(senha);

            var usuario = _context.Usuarios.Where(p => p.Email.Equals(email) && p.Senha.Equals(passwordCript)).FirstOrDefault();
            if (usuario is null) 
                return usuario;

            return usuario;
        }

        public Usuario BuscaUsuarioPorId(int id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }
        public ICollection<Usuario> BuscaUsuarios()
        {
            return _context.Usuarios.ToList();
        }
    }
}
