using AutoMapper;
using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Interop.Usuario.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioApplication _usuariosApplication;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioApplication usuariosApplication,
            IMapper mapper)
        {
            _mapper = mapper;
            _usuariosApplication = usuariosApplication;
        }
        // GET: UsuariosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Id")))
                return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id)
        {
            try
            {
                var usuario = _usuariosApplication.UsuarioBuscaId(id);

                _usuariosApplication.Alterar(usuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var usuario = _usuariosApplication.UsuarioBuscaId(id);

                _usuariosApplication.Deletar(usuario);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
