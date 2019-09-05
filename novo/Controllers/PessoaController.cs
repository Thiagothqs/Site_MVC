using novo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            ViewData["Id_Pessoa"] = 1;
            ViewData["Nome"] = "Fabiano";
            ViewData["Idade"] = 32;

            Pessoa p1 = new Pessoa();
            p1.Id_Pessoa = 2;
            p1.Nome = "Marcão";
            p1.Idade = 78;

            ViewBag._Id = p1.Id_Pessoa;
            ViewBag._Nome = p1.Nome;
            ViewBag._Idade = p1.Idade;

            return View();
        }

        public ActionResult Details()
        {
            Pessoa p1 = new Pessoa();
            p1.Id_Pessoa = 3;
            p1.Nome = "Hellen";
            p1.Idade = 56;

            return View(p1);
        }
    }
}