using AtividadeAvaliativa_PrimeiroB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtividadeAvaliativa_PrimeiroB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (usuario.Tipo.Equals("user"))
            {
                ViewBag._Id = usuario.Id_Usuario;
                ViewBag._Nome = usuario.Nome;
                ViewBag._Senha = usuario.Senha;
                ViewBag._Tipo = usuario.Tipo;

                return Redirect("/Menu/NoticiasUsuario");
                //return RedirectToAction("NoticiasAluno");
            }
            else if (usuario.Tipo.Equals("admin"))
            {
                ViewBag._Id = usuario.Id_Usuario;
                ViewBag._Nome = usuario.Nome;
                ViewBag._Senha = usuario.Senha;
                ViewBag._Tipo = usuario.Tipo;

                return Redirect("/Menu/CadastrarNoticia");
                //return RedirectToAction("CadastrarNoticia");
            }

            return View();
        }

        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(FormCollection form)
        {
            Usuario u1 = new Usuario();
            u1.Nome = form["txt_nome"];
            u1.Senha = form["txt_senha"];
            u1.Tipo = form["txt_tipo"];
            u1.Cadastrar();

            return View();
        }
    }
}