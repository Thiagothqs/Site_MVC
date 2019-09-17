using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio_12_09_19.Controllers
{
    public class MenuLateralController : Controller
    {
        // GET: MenuLateral
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bone()
        {
            return View();
        }

        public ActionResult Meia()
        {
            return View();
        }

        public ActionResult Sapato()
        {
            return View();
        }
    }
}