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