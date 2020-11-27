
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ProjetRobinF.dal;
using System.Security.Cryptography;
using System.Text;

namespace ProjetRobinF.Controllers
{
    public class AdminsController : Controller
    {
        private ProjetContext db = new ProjetContext();

        public ActionResult Index()
        {
            if (Session["idAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Pseudo, string Password)
        {
            if (ModelState.IsValid)
            {

                var f_password = GetMD5(Password);
                var data = db.Admins.Where(s => s.Pseudo.Equals(Pseudo) && s.Password.Equals(f_password)).FirstOrDefault();
                if (data != null)
                {

                    Session["Pseudo"] = data.Pseudo;
                    Session["idAdmin"] = data.idAdmin;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
