using novo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        FACEAR_2019Entities db = new FACEAR_2019Entities();

        public ActionResult Index()
        {
            var listagem = db.Produto.ToList();
            return View(listagem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(produto);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos");
                return View(produto);
            }
        }

        public ActionResult Edit(int id)
        {
            var produto = db.Produto.Find(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(produto);
                }
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult Delete(int id)
        {
            var produto = db.Produto.Find(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            try
            {
                var p = db.Produto.Find(produto.Id_Produto);
                db.Produto.Remove(p);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View(produto);
            }
        }
    }
}