using Comercio.MVC.Domain.Interfaces.Repository;
using Comercio.MVC.Domain.Models.TarefaModel;
using Comercio.MVC.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Infra.Repositories.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Context _context;

        public TarefaRepository(Context context)
        {
            _context = context;
        }

        public async Task GravarTarefa(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirTarefa(Tarefa tarefa)
        {
            _context.Remove(tarefa);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);

            await _context.SaveChangesAsync();
        }
    }
}
