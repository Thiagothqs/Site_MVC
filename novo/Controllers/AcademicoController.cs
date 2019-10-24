using novo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class AcademicoController : Controller
    {
        FACEAR_2019Entities db = new FACEAR_2019Entities();
        // GET: Academico
        public ActionResult Index()
        {
            //Busca Tudo
            var lista = db.Academico.ToList();

            //Busca o primeiro registro (Objeto)
            //var lista = db.Academico.FirstOrDefault();
            //var lista = db.Academico.First();

            //Busca apenas 2 registros
            //var lista = db.Academico.Take(2);

            //Ordernar
            //var lista = db.Academico.OrderBy(x=>x.Nome);

            //Busca por tudo
            //var lista = db.Academico.Where(x=>x.Nome.Contains("Le"));
            //var lista = db.Academico.Where(x=>x.Nome.StartsWith("A"));

            //Exemplo de vários comandos na mesma lista
            //var lista = db.Academico.Where(x=>x.Nome.Contains("l") && x.Sexo=="M").OrderByDescending(x=>x.Nome);

            int qtd = db.Academico.Where(x=>x.Sexo=="F").Count();

            int soma_de_id = db.Academico.Sum(x=> x.Id_Academico);

            return View(lista);
        }

        public ActionResult Create()
        {
            if (db.Academico.Any(x => x.Nome == "Fabiano"))
            {
                var ac = db.Academico.FirstOrDefault(x=>x.Nome == "Fabiano");
                ac.Nome = "Fabiano Nezello";
                var nota = ac.Nota.First();
                nota.Nome_Materia = "PHP";
                nota.Nota_I = 10;

                db.Entry(ac).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                Academico ac = new Academico();
                ac.Nome = "Fabiano";
                ac.Sexo = "M";

                Nota nota = new Nota();
                nota.Nota_I = 3;
                nota.Nota_II = 3.6m;
                nota.Nota_III = 4.0m;
                nota.Nota_IIII = 8.5m;
                nota.Nome_Materia = "POO";
                ac.Nota.Add(nota);

                Nota nota_ = new Nota();
                nota_.Nota_I = 9;
                nota_.Nota_II = 7.6m;
                nota_.Nota_III = 9.0m;
                nota_.Nota_IIII = 9.5m;
                nota_.Nome_Materia = "JAVA";
                ac.Nota.Add(nota_);

                db.Academico.Add(ac);
                db.SaveChanges();
            }
            return View();
        }
    }
}