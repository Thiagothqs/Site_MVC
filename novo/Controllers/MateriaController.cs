using novo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        FACEAR_2019Entities db = new FACEAR_2019Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Outros_Comandos_Jquery()
        {
            return View();
        }

        public JsonResult Retorna_Hora()
        {
            DateTime hora_atual = DateTime.Now;
            string Nome_Autor = "Professor";

            return Json(new
            {
                hora = hora_atual.ToString("dd/MM/yyyy"),
                nome = Nome_Autor
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Retorna_Qtd_Letras(string nome, string sobrenome)
        {
            int qtd = nome.Length;
            qtd += sobrenome.Length;
            
            return Json(new
            {
                qtd
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.Academicos = new SelectList(db.Academico.ToList(), "Id_Academico", "Nome", 2);
            return View();
        }

        public ActionResult Edit()
        {
            var materia = db.Materia.FirstOrDefault();
            ViewBag.Academicos = new SelectList(db.Academico.ToList(), "Id_Academico", "Nome", 3);
            return View(materia);
        }
    }
}