using Comercio.MVC.Application.Tarefa.Contrato;
using Comercio.MVC.Domain.Interfaces.Repository;
using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Application.Tarefa
{
    public class TarefaApplication : ITarefaApplication
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaRepositoryReadOnly _tarefaRepositoryReadOnly;
        public TarefaApplication(ITarefaRepository tarefaRepository,
            ITarefaRepositoryReadOnly tarefaRepositoryReadOnly)
        {
            _tarefaRepositoryReadOnly = tarefaRepositoryReadOnly;
            _tarefaRepository = tarefaRepository;
        }

        public async Task Cadastrar(Domain.Models.TarefaModel.Tarefa tarefa)
        {
            await _tarefaRepository.GravarTarefa(tarefa);
        }

        public async Task Deletar(Domain.Models.TarefaModel.Tarefa tarefa)
        {
            await _tarefaRepository.ExcluirTarefa(tarefa);
        }

        public async Task Alterar(Domain.Models.TarefaModel.Tarefa tarefa)
        {
            await _tarefaRepository.AtualizarTarefa(tarefa);
        }

        public ICollection<Domain.Models.TarefaModel.Tarefa> BuscaTarefas(int id)
        {
            return _tarefaRepositoryReadOnly.BuscaTarefas(id);
        }

        public Domain.Models.TarefaModel.Tarefa BuscaUsuarioPorId(int id)
        {
            return _tarefaRepositoryReadOnly.BuscaTarefaPorId(id);
        }
    }
}
