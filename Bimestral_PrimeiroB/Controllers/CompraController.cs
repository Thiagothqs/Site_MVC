using Bimestral_PrimeiroB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bimestral_PrimeiroB.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            cliente.Cadastrar();
            return View();
        }

        public ActionResult AlterarCliente(int id)
        {
            Cliente cliente = new Cliente();
            return View(cliente.Busca_Usuarios_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarCliente(Cliente cliente)
        {
            cliente.Alterar(cliente);
            return View();
        }

        public ActionResult DeletarCliente(int id)
        {
            Cliente cliente = new Cliente();
            cliente = cliente.Busca_Usuarios_ID(id)[0];
            return View(cliente);
        }

        [HttpPost]
        public ActionResult DeletarCliente(FormCollection form, int id)
        {
            Cliente cliente = new Cliente();
            cliente = cliente.Busca_Usuarios_ID(id)[0];
            cliente.Deletar(cliente);
            return View(cliente);
            //return RedirectToAction("ListarAluno");
        }

        public ActionResult CadastrarVendedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarVendedor(Vendedor vendedor)
        {
            vendedor.Cadastrar();
            return View();
        }

        public ActionResult AlterarVendedor(int id)
        {
            Vendedor vendedor = new Vendedor();
            return View(vendedor.Busca_Usuarios_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarVendedor(Vendedor vendedor)
        {
            vendedor.Alterar(vendedor);
            return View();
        }

        public ActionResult DeletarVendedor(int id)
        {
            Vendedor vendedor = new Vendedor();
            vendedor = vendedor.Busca_Usuarios_ID(id)[0];
            return View(vendedor);
        }

        [HttpPost]
        public ActionResult DeletarVendedor(FormCollection form, int id)
        {
            Vendedor vendedor = new Vendedor();
            vendedor = vendedor.Busca_Usuarios_ID(id)[0];
            vendedor.Deletar(vendedor);
            return View(vendedor);
            //return RedirectToAction("ListarAluno");
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            produto.Cadastrar();
            return View();
        }

        public ActionResult AlterarProduto(int id)
        {
            Produto produto = new Produto();
            return View(produto.Busca_Usuarios_ID(id)[0]);
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
            produto = produto.Busca_Usuarios_ID(id)[0];
            return View(produto);
        }

        [HttpPost]
        public ActionResult DeletarProduto(FormCollection form, int id)
        {
            Produto produto = new Produto();
            produto = produto.Busca_Usuarios_ID(id)[0];
            produto.Deletar(produto);
            return View(produto);
            //return RedirectToAction("ListarAluno");
        }

        public ActionResult CadastrarPedido()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPedido(Pedido pedido)
        {
            pedido.Cadastrar();
            return View();
        }

        public ActionResult AlterarPedido(int id)
        {
            Pedido pedido = new Pedido();
            return View(pedido.Busca_Usuarios_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarPedido(Pedido pedido)
        {
            pedido.Alterar(pedido);
            return View();
        }

        public ActionResult DeletarPedido(int id)
        {
            Pedido pedido = new Pedido();
            pedido = pedido.Busca_Usuarios_ID(id)[0];
            return View(pedido);
        }

        [HttpPost]
        public ActionResult DeletarPedido(FormCollection form, int id)
        {
            Pedido pedido = new Pedido();
            pedido = pedido.Busca_Usuarios_ID(id)[0];
            pedido.Deletar(pedido);
            return View(pedido);
            //return RedirectToAction("ListarAluno");
        }
    }
}