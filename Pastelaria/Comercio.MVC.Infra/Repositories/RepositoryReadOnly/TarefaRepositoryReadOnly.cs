using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using Comercio.MVC.Domain.Models.TarefaModel;
using Comercio.MVC.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Infra.Repositories.RepositoryReadOnly
{
    public class TarefaRepositoryReadOnly : ITarefaRepositoryReadOnly
    {
        private readonly Context _context;
        public TarefaRepositoryReadOnly(Context context)
        {
            _context = context;
        }

        public Tarefa BuscaTarefaPorId(int id)
        {
            return _context.Tarefas.Where(x => x.Id == id).FirstOrDefault();
        }
        public ICollection<Tarefa> BuscaTarefas(int id)
        {
            return _context.Tarefas.Where(e => e.UsuarioId == id).ToList();
        }
    }
}
