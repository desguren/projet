using ProjetRobinF.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjetRobinF.Controllers
{
    public class HomeController : Controller
    {
        private ProjetContext _db = new ProjetContext();
        public ActionResult Index()
        {
                return View();
         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description de Travel Japan";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nous contacter";

            return View();
        }

    }

}

 