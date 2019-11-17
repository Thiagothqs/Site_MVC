using AgendaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaVirtual.Controllers
{
    public class AgendaController : Controller
    {
        AgendaVirtualEntities db = new AgendaVirtualEntities();
        static List<Agenda> lista_ordenada = new List<Agenda>();

        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add_Anotacao(string data, string anotacao, string id)
        {
            Agenda agenda = new Agenda();
            agenda.Data = data;
            agenda.Anotacao = anotacao;

            if (id == "") // Novo
            {
                db.Agenda.Add(agenda);
            }
            else // Alteracao
            {
                int idAnot = Convert.ToInt32(id);
                var anot = db.Agenda.Find(idAnot);

                //agenda.Id_Agenda = idAnot;

                anot.Data = agenda.Data;
                anot.Anotacao = agenda.Anotacao;

                db.Entry(anot).State = EntityState.Modified;
            }

            db.SaveChanges();

            return Json(new
            {
                lista = db.Agenda.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Alterar_Anotacao(string data, string anotacao, string id)
        {
            int idAnot = Convert.ToInt32(id);
            var anot = db.Agenda.Find(idAnot);

            Agenda agenda = new Agenda();
            agenda.Id_Agenda = idAnot;
            agenda.Data = data;
            agenda.Anotacao = anotacao;

            anot = agenda;

            db.Entry(anot).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new
            {
                lista = db.Agenda.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Excluir_Anotacao(string id)
        {
            int idAnot = Convert.ToInt32(id);

            var anot = db.Agenda.Find(idAnot);

            db.Agenda.Remove(anot);
            db.SaveChanges();

            return Json(new
            {
                lista = db.Agenda.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Preenche_Campos(string id)
        {
            int idAnot = Convert.ToInt32(id);
            var anot = db.Agenda.Find(idAnot);

            return Json(new
            {
                dataAtual = anot.Data,
                Anotacao = anot.Anotacao
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Retorna_Lista()
        {
            var listagem = db.Agenda.ToList();
            for (int i = 0; i < listagem.Count; i++)
            {
                for (int j = 0; j < listagem.Count; j++)
                {
                    if(i != j)
                    {
                        var data1 = Convert.ToDateTime(listagem[i].Data);
                        var data2 = Convert.ToDateTime(listagem[j].Data);

                        System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaAAAAAAAAAA" + data1);
                        System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaAAAAAAAAAA" + data2);

                        if (data1 < data2)
                        {
                            var aux = data1;
                            var auxObj = listagem[i];
                            //data1 = data2;
                            //data2 = aux;

                            // 

                            //listagem[i].Data = listagem[j].Data;
                            //listagem[j].Data = aux.ToString();

                            listagem[i] = listagem[j];

                            listagem[j] = auxObj;
                            //listagem[j].Data = aux.ToString();
                        }
                    }
                }
            }
            return Json(new
            {
                lista = listagem
            }, JsonRequestBehavior.AllowGet);
        }
    }
}