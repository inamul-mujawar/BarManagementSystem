using BarManagementSystem.DAL;
using BarManagementSystem.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BarManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        BarDal barDal = new BarDal();
        // GET: Admin
        public ActionResult Login()
        {
            TempData["ErrorMessage"] = TempData["ErrorMessage"] != null ? TempData["ErrorMessage"] : null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin,string returnUrl)
        {
            if (barDal.ListOfAdminDetails().Where(x => (x.userName == admin.userName && x.password == admin.password)).Count() >= 1)
            {
                string identityCookie = admin.userName + "|" + false;
                Session["UserLogin"] = identityCookie;
                FormsAuthentication.SetAuthCookie(identityCookie, false);
                return Redirect("/Bar/Tables");
            }
            else
            {
                TempData["ErrorMessage"] = "Error";
                return Redirect("/Admin/Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Remove("");
            Session.Abandon();
            return Redirect("/Admin/Login");
        }
    }
}