using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio_17_10_19.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        Exercicio_17_10_19Entities db = new Exercicio_17_10_19Entities();
        
        // GET: Academico
        public ActionResult Index(int id)
        {
            var listagem = db.Materia.Where(x=>x.Id_Academico == id).Where(x => x.Disponivel == true).ToList();
            return View(listagem);
        }

        public ActionResult Create(int id)
        {
            ViewData["Id_Academico"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Materia materia, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    materia.Id_Academico = Convert.ToInt32(form["Id_Academico"]);

                    db.Materia.Add(materia);
                    db.SaveChanges();

                    //return RedirectToAction("Index");
                    
                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(materia);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos");
                return View(materia);
            }
        }

        public ActionResult Edit(int id)
        {
            var materia = db.Materia.Find(id);
            return View(materia);
        }

        [HttpPost]
        public ActionResult Edit(Materia materia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(materia).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = materia.Id_Academico });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(materia);
                }
            }
            else
            {
                return View(materia);
            }
        }

        public ActionResult Delete(int id)
        {
            var materia = db.Materia.Find(id);
            return View(materia);
        }

        [HttpPost]
        public ActionResult Delete(Materia materia, int id)
        {
            try
            {
                var m1 = db.Materia.Find(id);
                //db.Academico.Remove(p);
                m1.Disponivel = false;
                db.Entry(m1).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index", new { id = m1.Id_Academico });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                var m1 = db.Materia.Find(id);
                return View(m1);
            }
        }
    }
}