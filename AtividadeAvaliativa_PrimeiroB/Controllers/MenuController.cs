using AtividadeAvaliativa_PrimeiroB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtividadeAvaliativa_PrimeiroB.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Esporte()
        {
            if (ViewBag._Tipo == "user")
            {
                return Redirect("/Menu/EsporteUsuario");
            }

            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Esporte"));
        }

        public ActionResult CadastrarNoticia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNoticia(Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return View(noticia);
            }
            else
            {
                noticia.Cadastrar();
                return View();
            }
            //return View();
        }

        public ActionResult AlterarNoticia(int id)
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarNoticia(Noticia noticia)
        {
            noticia.Alterar(noticia);
            return View();
        }

        public ActionResult DeletarNoticia(int id)
        {
            Noticia noticia = new Noticia();
            noticia = noticia.Busca_Noticias_ID(id)[0];
            return View(noticia);
        }

        [HttpPost]
        public ActionResult DeletarNoticia(FormCollection form, int id)
        {
            Noticia noticia = new Noticia();
            noticia = noticia.Busca_Noticias_ID(id)[0];
            noticia.Deletar(noticia);
            return View(noticia);
            //return RedirectToAction("ListarAluno");
        }

        public ActionResult Noticias()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Noticias"));
        }

        public ActionResult Famosos()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Famosos"));
        }

        public ActionResult TecnologiaGames()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("TecnologiaGames"));
        }

        public ActionResult Politica()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Politica"));
        }

        public ActionResult Carros()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Carros"));
        }
        ////////////////////
        public ActionResult EsporteUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Esporte"));
        }

        public ActionResult NoticiasUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Noticias"));
        }

        public ActionResult FamososUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Famosos"));
        }

        public ActionResult TecnologiaGamesUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("TecnologiaGames"));
        }

        public ActionResult PoliticaUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Politica"));
        }

        public ActionResult CarrosUsuario()
        {
            Noticia noticia = new Noticia();
            return View(noticia.Busca_Noticias_Classificacao("Carros"));
        }
    }
}