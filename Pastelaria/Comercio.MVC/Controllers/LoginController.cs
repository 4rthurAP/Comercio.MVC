using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Interop.Cadastro;
using Comercio.MVC.Services.Criptografia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;

namespace Comercio.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public LoginController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            //if (!String.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId"))) return RedirectToAction(nameof(Perfil));
            var usuario = _usuarioApplication.VerificaLogin(email, senha);
            if (usuario is null)
            {
                ViewBag.Erro = "Não foi possível realizar login. Dados incorretos!";
                return RedirectToAction("Index", "Home");
            }

            StartSessionLogin(usuario);

            return RedirectToAction(nameof(Perfil));
        }

        public IActionResult ListaUsuarios()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Id")))
            {
                if (HttpContext.Session.GetString("IsAdmin") == "True")
                {
                    var usuarios = _usuarioApplication.BuscaUsuarios();

                    return View(usuarios);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Perfil()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Id"))) return RedirectToAction(nameof(Login));
            int id = Int32.Parse(HttpContext.Session.GetString("Id"));

            var usuario = _usuarioApplication.UsuarioBuscaId(id);

            return View(usuario);
        }
        private void StartSessionLogin(Usuario usuario)
        {
            HttpContext.Session.SetString("IsAdmin", (usuario.IsAdmin).ToString());
            HttpContext.Session.SetString("Nome", usuario.Nome);
            HttpContext.Session.SetString("Email", usuario.Email);
            HttpContext.Session.SetString("TelefoneFixo", usuario.TelefoneFixo);
            HttpContext.Session.SetString("TelefoneCelular", usuario.TelefoneCelular);
            HttpContext.Session.SetString("Id", usuario.Id.ToString());
        }

        public void Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            HttpContext.Session.Remove("Nome");
            HttpContext.Session.Remove("TelefoneFixo");
            HttpContext.Session.Remove("TelefoneCelular");
            HttpContext.Session.Remove("Email");
            Response.Redirect(Url.Action("Index", "Home"));
        }
    }
}
