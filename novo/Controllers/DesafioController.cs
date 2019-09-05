using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class DesafioController : Controller
    {
        static int valor_antigo = 0;

        // GET: Desafio
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int txt_numero, int txt_antigo)
        {
            ViewData["Resultado"] = txt_numero;

            //valor_antigo = Convert.ToInt32(ViewData["Resultado"]);
            txt_antigo = Convert.ToInt32(ViewData["Resultado"]);
            //ViewData["Resultado"] = Convert.ToInt32(ViewData["Resultado"]) + txt_numero;

            return View();
        }

        public ActionResult Somar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Somar(int txt_numero)
        {
            ViewData["Resultado"] = valor_antigo + txt_numero;
            valor_antigo = Convert.ToInt32(ViewData["Resultado"]);

            if (Convert.ToInt32(ViewData["Resultado"]) % 2 == 0)
            {
                ViewData["Mensagem"] = ViewData["Resultado"] + " - PAR";
                ViewBag._Cor = "green";
            }
            else
            {
                ViewData["Mensagem"] = ViewData["Resultado"] + " - ÍMPAR";
                ViewBag._Cor = "red";
            }

            return View();
        }
    }
}