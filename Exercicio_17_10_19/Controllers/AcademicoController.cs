using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio_17_10_19.Controllers
{
    public class AcademicoController : Controller
    {
        Exercicio_17_10_19Entities db = new Exercicio_17_10_19Entities();

        // GET: Academico
        public ActionResult Index()
        {
            var listagem = db.Academico.Where(x=>x.Ativo == true).ToList();
            return View(listagem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Academico academico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Academico.Add(academico);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(academico);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos");
                return View(academico);
            }
        }

        public ActionResult Edit(int id)
        {
            var academico = db.Academico.Find(id);
            return View(academico);
        }

        [HttpPost]
        public ActionResult Edit(Academico academico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(academico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(academico);
                }
            }
            else
            {
                return View(academico);
            }
        }

        public ActionResult Delete(int id)
        {
            var academico = db.Academico.Find(id);
            return View(academico);
        }

        [HttpPost]
        public ActionResult Delete(Academico academico, int id)
        {
            try
            {
                var ac = db.Academico.Find(id);
                //db.Academico.Remove(p);
                ac.Ativo = false;
                db.Entry(ac).State = EntityState.Modified;
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View(academico);
            }
        }
        
        public ActionResult Search(FormCollection form)
        {
            Academico ac = new Academico();
            if (form["ordenar"].Contains("nome"))
            {
                var academico = db.Academico.Where(x => x.Nome.Equals(form["nome"])).Where(x => x.Sexo.Equals(form["sexo"])).OrderBy(x=> x.Nome).Take(Convert.ToInt32(form["qtd"]));
                return View(academico);
            }
            else if (form["ordenar"].Contains("sexo"))
            {
                var academico = db.Academico.Where(x => x.Nome.Equals(form["nome"])).Where(x => x.Sexo.Equals(form["sexo"])).OrderBy(x => x.Sexo).Take(Convert.ToInt32(form["qtd"]));
                return View(academico);
            }

            return View();
        }
    }
}