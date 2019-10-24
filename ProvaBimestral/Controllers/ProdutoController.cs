using ProvaBimestral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (usuario.Login.Equals("adm") && usuario.Senha.Equals("123"))
            {
                //Session["usuario"] = usuario;
                Session["login"] = "adm";
                Session["senha"] = "123";
                return RedirectToAction("CadastrarProduto");
            }
            else
            {
                Session["login"] = "user";
                Session["senha"] = "user";
                //Session["usuario"] = usuario;
                return RedirectToAction("PadraoUsuario");
            }
        }

        public ActionResult DadosDoProduto(int id)
        {
            Produto produto = new Produto();
            return View(produto.Busca_Produtos_ID(id)[0]);
        }

        public ActionResult PadraoUsuario()
        {
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            else
            {
                produto.Cadastrar();
                return View();
            }
            //return View();
        }

        public ActionResult AlterarProduto(int id)
        {
            Produto produto = new Produto();
            return View(produto.Busca_Produtos_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produto)
        {
            produto.Alterar(produto);
            return View();
        }

        public ActionResult DeletarProduto(int id)
        {
            Produto produto = new Produto();
            produto = produto.Busca_Produtos_ID(id)[0];
            return View(produto);
        }

        [HttpPost]
        public ActionResult DeletarProduto(FormCollection form, int id)
        {
            Produto produto = new Produto();
            produto = produto.Busca_Produtos_ID(id)[0];
            produto.Deletar(produto);
            return View(produto);
            //return RedirectToAction("ListarAluno");
        }

        public ActionResult Celular()
        {
            Produto produto = new Produto();

            return View(produto.Busca_Produto_Categoria("Celular"));
        }

        public ActionResult Tablet()
        {
            Produto produto = new Produto();
            return View(produto.Busca_Produto_Categoria("Tablet"));
        }

        public ActionResult Notebook()
        {
            Produto produto = new Produto();
            return View(produto.Busca_Produto_Categoria("Notebook"));
        }

        public ActionResult Carregadores()
        {
            Produto produto = new Produto();
            return View(produto.Busca_Produto_Categoria("Carregadores"));
        }

        public ActionResult validacao(string categoria)
        {
            if (categoria.Equals("Celular") || categoria.Equals("Tablet") || categoria.Equals("Notebook") || categoria.Equals("Carregadores"))
            {

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}