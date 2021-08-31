using Comercio.MVC.Domain.Interfaces.Repository;
using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Infra.DataContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Infra.Repositories.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task GravarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirUsuario(Usuario usuario)
        {
             _context.Remove(usuario);

             await _context.SaveChangesAsync();
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);

            await _context.SaveChangesAsync();
        }
    }
}

