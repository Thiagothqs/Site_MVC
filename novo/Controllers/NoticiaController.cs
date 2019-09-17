using novo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index()
        {
            List<Noticias> lista_noticias = new List<Noticias>();
            if (Session["Noticias"] != null)
            {
                lista_noticias = (List<Noticias>)Session["Noticias"];
            }
            else
            {
                Noticias n1 = new Noticias();
                n1.ID = 1;
                n1.ID_Topico = 1;
                n1.Titulo = "Neymar"; // Esportes
                n1.Descricao = "Neymar faz mais 3 jogo pela seleção";
                lista_noticias.Add(n1);

                Noticias n2 = new Noticias();
                n2.ID = 2;
                n2.ID_Topico = 2; //Jornalismo
                n2.Titulo = "Lula continua na cadeia";
                n2.Descricao = "STF nega pedido de soltura de Lula";
                lista_noticias.Add(n2);

                Noticias n3 = new Noticias();
                n3.ID = 3;
                n3.ID_Topico = 2; //Jornalismo
                n3.Titulo = "Criança some em Araucária";
                n3.Descricao = "Mais uma criança some em Araucária nomeio da fumaça";
                lista_noticias.Add(n3);

                Session["Noticias"] = lista_noticias;
            }
            return View(lista_noticias);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Noticias> lista_noticias = new List<Noticias>();
            if (Session["Noticias"] != null)
            {
                lista_noticias = (List<Noticias>)Session["Noticias"];
            }
            var n1 = lista_noticias.Find(x => x.ID == id);

            return View(n1);
        }
    }
}