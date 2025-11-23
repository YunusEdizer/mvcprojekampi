using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcprojekampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
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
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo=wm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

    }
}
