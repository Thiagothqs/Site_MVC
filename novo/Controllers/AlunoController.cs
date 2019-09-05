using novo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace novo.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int txt_id, string txt_nome, int txt_idade, string lista_alunos)
        {
            Aluno a1 = new Aluno();
            a1.Id_Pessoa = txt_id;
            a1.Nome = txt_nome;
            a1.Idade = txt_idade;

            ViewData["Id_Pessoa"] = txt_id;
            ViewBag._Nome = txt_nome;
            ViewData["Idade"] = txt_idade;

            if(txt_idade < 18)
            {
                ViewData["Mensagem"] = "A idade não pode ser menor que 18";
            }
            else
            {
                lista_alunos += a1.Id_Pessoa+ " - "+a1.Nome+" - "+a1.Idade;
            }

            //ViewBag._Nome = txt_nome;
            ViewData["lista_alunos"] = lista_alunos;

            return View();
        }

        public ActionResult New_Aluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New_Aluno(FormCollection form)
        {
            Pessoa p1 = new Pessoa();
            p1.Nome = form["txt_nome"];
            p1.Idade = Convert.ToInt32(form["txt_idade"]);
            return View();
        }

        public ActionResult Novo_Aluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo_Aluno(Aluno a1, FormCollection form)
        {
            if (string.IsNullOrEmpty(a1.Nome))
            {
                ModelState.AddModelError("", "O campo nome não pode ser nulo");
            }
            if (!a1.Idade.HasValue)//(string.IsNullOrEmpty(a1.Nome))
            {
                ModelState.AddModelError("", "O campo Idade é obrigatório");
            }
            if (string.IsNullOrEmpty(a1.Sexo))
            {
                ModelState.AddModelError("Sexo", "O campo sexo é obrigatório");
            }
            else
            {
                if (a1.Sexo != "M" && a1.Sexo != "F")
                {
                    ModelState.AddModelError("Sexo", "O sexo deve ser M ou F");
                }
            }

            if (!a1.Peso.HasValue)
            {
                ModelState.AddModelError("Peso", "O peso é obrigatório");
            }
            else if (a1.Peso > 300 || a1.Peso < 0)
            {
                ModelState.AddModelError("Peso", "O peso não pode ser menor que 0 ou maior que 300");
            }

            return View();
        }

        public ActionResult CadastrarAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAluno(Aluno aluno)
        {
            aluno.Cadastrar();
            return View();
        }

        public ActionResult ListarAluno()
        {
            Aluno aluno = new Aluno();
            return View(aluno.Busca_Alunos());
        }

        public ActionResult AlterarAluno(int id)
        {
            Aluno aluno = new Aluno();
            return View(aluno.Busca_Alunos_ID(id)[0]);
        }

        [HttpPost]
        public ActionResult AlterarAluno(Aluno aluno)
        {
            aluno.Alterar(aluno);
            //return View();
            return RedirectToAction("ListarAluno");
        }

        public ActionResult DeletarAluno(int id)
        {
            Aluno aluno = new Aluno();
            aluno = aluno.Busca_Alunos_ID(id)[0];
            return View(aluno);
        }

        [HttpPost]
        public ActionResult DeletarAluno(FormCollection form, int id)
        {
            Aluno aluno = new Aluno();
            aluno = aluno.Busca_Alunos_ID(id)[0];
            aluno.Deletar(aluno);
            //return View(aluno);
            return RedirectToAction("ListarAluno");
        }
    }
}