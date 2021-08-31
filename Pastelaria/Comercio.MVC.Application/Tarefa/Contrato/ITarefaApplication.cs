using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Application.Tarefa.Contrato
{
    public interface ITarefaApplication
    {
        Task Cadastrar(Domain.Models.TarefaModel.Tarefa tarefa);
        Task Deletar(Domain.Models.TarefaModel.Tarefa tarefa);
        Task Alterar(Domain.Models.TarefaModel.Tarefa tarefa);
        ICollection<Domain.Models.TarefaModel.Tarefa> BuscaTarefas(int id);
        Domain.Models.TarefaModel.Tarefa BuscaUsuarioPorId(int id);
    }
}
