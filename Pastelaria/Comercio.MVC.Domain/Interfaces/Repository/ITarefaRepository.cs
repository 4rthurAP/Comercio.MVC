using Comercio.MVC.Domain.Models.TarefaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Domain.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        Task GravarTarefa(Tarefa tarefa);
        Task ExcluirTarefa(Tarefa tarefa);
        Task AtualizarTarefa(Tarefa tarefa);
    }
}
