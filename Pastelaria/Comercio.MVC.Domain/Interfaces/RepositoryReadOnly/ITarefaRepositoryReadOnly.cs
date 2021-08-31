using Comercio.MVC.Domain.Models.TarefaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Domain.Interfaces.RepositoryReadOnly
{
    public interface ITarefaRepositoryReadOnly
    {
        Tarefa BuscaTarefaPorId(int id);
        ICollection<Tarefa> BuscaTarefas(int id);
    }
}
