using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio_17_10_19.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        Exercicio_17_10_19Entities db = new Exercicio_17_10_19Entities();

        public ActionResult Index(int id)
        {
            var listagem = db.Nota.Where(x => x.Id_Materia == id).ToList();
            return View(listagem);
        }

        public ActionResult Create(int id)
        {
            Nota n1 = new Nota();
            Materia m1 = db.Materia.Find(id);
            n1.Id_Materia = id;
            n1.Nota_Materia = m1.Descricao;
            //ViewData["Id_Materia"] = id;
            return View(n1);
        }

        [HttpPost]
        public ActionResult Create(Nota nota, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //nota.Id_Materia = Convert.ToInt32(form["Id_Materia"]);

                    db.Nota.Add(nota);
                    db.SaveChanges();

                    //return RedirectToAction("Index");

                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(nota);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos");
                return View(nota);
            }
        }

        public ActionResult Edit(int id)
        {
            var nota = db.Nota.Find(id);
            return View(nota);
        }

        [HttpPost]
        public ActionResult Edit(Nota nota)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(nota).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = nota.Id_Materia });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(nota);
                }
            }
            else
            {
                return View(nota);
            }
        }
    }
}