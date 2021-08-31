using AutoMapper;
using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Models.UsuarioModel;
using Comercio.MVC.Interop.Cadastro;
using Comercio.MVC.Services.Criptografia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Comercio.MVC.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IMapper _mapper;

        public CadastroController(IUsuarioApplication usuarioApplication,
            IMapper mapper)
        {
            _mapper = mapper;
            _usuarioApplication = usuarioApplication;
        }
        public IActionResult Cadastro()
        {
            var existeUsuarios = _usuarioApplication.ExisteUsuarios();

            if (!existeUsuarios)
            {
                return View();
            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Id")))
                if (HttpContext.Session.GetString("IsAdmin") == "True")
                    return View();

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(CadastroViewModel cadastroModel)
        {
            Cryptography cryptography = new Cryptography(MD5.Create());

            if (_usuarioApplication.EmailExiste(cadastroModel.Email)) ModelState.AddModelError("Email", "O e-mail inserido já cadastrado!");

            if (_usuarioApplication.TelefoneFixoExiste(cadastroModel.TelefoneFixo)) ModelState.AddModelError("Telefone Fixo", "O telefone inserido já cadastrado!");

            if (_usuarioApplication.TelefoneCelularExiste(cadastroModel.TelefoneCelular)) ModelState.AddModelError("Telefone Fixo", "O telefone inserido já cadastrado!");

            if (!cryptography.HashVerify(cadastroModel.ConfirmarSenha, cadastroModel.Senha))
            {
                ModelState.AddModelError("Senha", "As senhas não correspondem.");
            }

            try
            {
                var usuario = _mapper.Map<Usuario>(cadastroModel);

                _usuarioApplication.Cadastrar(usuario);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            ViewBag.CadastroSucesso = "Usuario cadastrado com sucesso!";

            return RedirectToAction("Perfil", "Login");
        }
    }
}
