using AutoMapper;
using Comercio.MVC.Domain.Models.TarefaModel;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Interop.Cadastro;
using Comercio.MVC.Interop.Tarefa.ViewModel;
using Comercio.MVC.Interop.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.MVC.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CadastroViewModel, Usuario>()
                .ReverseMap();

            CreateMap<TarefaViewModel, Tarefa>()
                .ReverseMap();

            CreateMap<UsuarioDto, Usuario>()
                .ReverseMap();
        }
    }
}
