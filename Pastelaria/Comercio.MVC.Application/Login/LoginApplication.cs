using Comercio.MVC.Application.Login.Contrato;
using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Application.Login
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IUsuarioRepositoryReadOnly _usuarioRepositoryReadOnly;
        public LoginApplication(IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly)
        {
            _usuarioRepositoryReadOnly = usuarioRepositoryReadOnly;
        }
    }
}
