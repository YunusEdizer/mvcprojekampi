using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcprojekampi.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginManager loginManager = new LoginManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(p.AdminPassword);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new System.Text.StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));

                p.AdminPassword = sb.ToString();
            }

            var adminUser = loginManager.Login(p.AdminUserName, p.AdminPassword);

            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName, false);
                Session["AdminUserName"] = adminUser.AdminUserName;
                Session["AdminRole"] = adminUser.AdminRole;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
