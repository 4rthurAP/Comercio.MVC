using AutoMapper;
using Comercio.MVC.Application.Tarefa.Contrato;
using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Models.TarefaModel;
using Comercio.MVC.Interop.Tarefa.ViewModel;
using Comercio.MVC.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.MVC.Controllers
{
    public class TarefasController : Controller
    {
        private readonly EnviarEmailHandler _enviarEmailHandler;
        private readonly ITarefaApplication _tarefaApplication;
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IMapper _mapper;
        public TarefasController(ITarefaApplication tarefaApplication,
            IUsuarioApplication usuarioApplication,
            IMapper mapper,
            EnviarEmailHandler enviarEmailHandler
            )
        {
            _usuarioApplication = usuarioApplication;
            _tarefaApplication = tarefaApplication;
            _mapper = mapper;
            _enviarEmailHandler = enviarEmailHandler;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Id")))
                if (HttpContext.Session.GetString("IsAdmin") != "True")
                {
                    return RedirectToAction("Index", "Home");
                }

            ViewBag.UsuarioId = new SelectList(_usuarioApplication.BuscaUsuarios(), "Id", "Nome");

            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarefaViewModel tarefaViewModel)
        {
            try
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);

                var usuario = _usuarioApplication.UsuarioBuscaId(tarefa.UsuarioId);

                _enviarEmailHandler.EmailFuncionarioHandler(usuario.Email);

                _tarefaApplication.Cadastrar(tarefa);

                return RedirectToAction("Perfil","Login");
            }
            catch(Exception ex)
            {
                ViewBag.ErroEmail = ex.Message;
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var tarefa = _tarefaApplication.BuscaUsuarioPorId(id);

                _tarefaApplication.Alterar(tarefa);

                var usuario =  _usuarioApplication.UsuarioBuscaId(tarefa.UsuarioId);

                if(tarefa.IsDone)
                {
                    _enviarEmailHandler.EmailManagerHandler(usuario.Email, usuario.Nome);
                }

                return RedirectToAction("Perfil", "Login");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ListarTerefas()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Id"))) 
                return RedirectToAction("Index", "Home");
            int id = Int32.Parse(HttpContext.Session.GetString("Id"));

            var tarefas = _tarefaApplication.BuscaTarefas(id);

            return View(tarefas);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                var tarefa = _tarefaApplication.BuscaUsuarioPorId(id);

                _tarefaApplication.Deletar(tarefa);

                return RedirectToAction("Perfil", "Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
