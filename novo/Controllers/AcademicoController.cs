using novo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Listar_Academicos()
        {
            var lista = db.Academico.ToList();
            return View(lista);
        }

        public ActionResult Cadastrar_Alunos_Notas()
        {
            return View();
        }

        public ActionResult Alterar_Alunos_Notas(int id)
        {
            var academico = db.Academico.Find(id);
            return View(academico);
        }

        [HttpPost]
        public ActionResult Alterar_Alunos_Notas(Academico ac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(ac).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Listar_Academicos");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(ac);
                }
            }
            else
            {
                return View(ac);
            }
        }

        [HttpPost]
        public ActionResult Cadastrar_Alunos_Notas(Academico ac, FormCollection form)
        {
            ac.Nota = (List<Nota>) Session["notas"];
            db.Academico.Add(ac);
            db.SaveChanges();

            return View();
        }

        public JsonResult Retorna_Lista_Academicos(string nome, string sexo, string ativo)
        {
            var lista = db.Academico.ToList();
            
            //System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaAAAAAAAAAA" + ativo);

            if (nome != null && nome != "")
            {
                lista = db.Academico.Where(x => x.Nome.StartsWith(nome)).ToList();
            }
            else if (sexo != null && sexo != "")
            {
                lista = db.Academico.Where(x => x.Sexo.Equals(sexo)).ToList();
            }
            else if (ativo != null && ativo != "")
            {
                bool vamo = Convert.ToBoolean(ativo);
                lista = db.Academico.Where(x => x.Ativo.Equals(vamo)).ToList();
            }

            List<Academico> lista_academicos = new List<Academico>();
            foreach (var item in lista)
            {
                Academico ac = new Academico();
                ac.Nome = item.Nome;
                ac.Sexo = item.Sexo;
                lista_academicos.Add(ac);
            }

            return Json(new
            {
                lista = lista_academicos
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adicionar_Nota_Sessao(string nome, string n1, string n2, string n3, string n4, string posicao)
        {
            Nota nota = new Nota();
            nota.Nome_Materia = nome;
            nota.Nota_I = Convert.ToDecimal(n1);
            nota.Nota_II = Convert.ToDecimal(n2);
            nota.Nota_III = Convert.ToDecimal(n3);
            nota.Nota_IIII = Convert.ToDecimal(n4);

            //System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaAAAAAAAAAA" + posicao);
            if (posicao == "")
            {
                if (Session["notas"] != null)
                {
                    ((List<Nota>)Session["notas"]).Add(nota);
                    nota.Id_Nota = ((List<Nota>)Session["notas"]).Count;
                }
                else
                {
                    Session["notas"] = new List<Nota>();
                    ((List<Nota>)Session["notas"]).Add(nota);
                    nota.Id_Nota = ((List<Nota>)Session["notas"]).Count;
                }
            }
            else
            {
                ((List<Nota>)Session["notas"])[Convert.ToInt32(posicao)] = nota;
            }

            return Json(new
            {
                lista = Session["notas"]
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remover_Nota_Sessao(int id)
        {
            ((List<Nota>)Session["notas"]).Remove(((List<Nota>)Session["notas"])[id]);

            return Json(new
            {
                lista = Session["notas"]
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Alterar_Adicionar_Nota(string nome, string n1, string n2, string n3, string n4, string posicao, string idNota)
        {
            Nota nota = new Nota();
            nota.Nome_Materia = nome;
            nota.Nota_I = Convert.ToDecimal(n1);
            nota.Nota_II = Convert.ToDecimal(n2);
            nota.Nota_III = Convert.ToDecimal(n3);
            nota.Nota_IIII = Convert.ToDecimal(n4);

            Session["todos"] = new List<Nota>();
            //System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaAAAAAAAAAA" + posicao);
            if (idNota != "")
            {
                var nota_academico = db.Nota.Find(idNota);
                var notas = db.Nota.Where(x => x.Id_Academico == nota_academico.Id_Academico).ToList();
                
                for(int i=0; i < notas.Count(); i++)
                {
                    if (notas[i].Id_Nota == nota_academico.Id_Nota)
                    {
                        notas[i] = nota;
                    }
                    ((List<Nota>) Session["todos"]).Add(notas[i]);
                }
            }
            else if (posicao == "")
            {
                if (Session["notas"] != null)
                {
                    ((List<Nota>)Session["notas"]).Add(nota);
                    //nota.Id_Nota = ((List<Nota>)Session["notas"]).Count;
                }
                else
                {
                    Session["notas"] = new List<Nota>();
                    ((List<Nota>)Session["notas"]).Add(nota);
                    //nota.Id_Nota = ((List<Nota>)Session["notas"]).Count;
                }
            }
            else
            {
                ((List<Nota>)Session["notas"])[Convert.ToInt32(posicao)] = nota;
            }

            for (int i = 0; i < ((List<Nota>) Session["notas"]).Count; i++)
            {
                //var esse = 
                ((List<Nota>)Session["todos"]).Add(((List<Nota>) Session["notas"])[i]);
            }

            return Json(new
            {
                lista = Session["todos"]
            }, JsonRequestBehavior.AllowGet);
        }
    }
}