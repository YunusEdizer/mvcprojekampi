using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm=new ContactManager(new EfContactDal());
        ContactValidator cv=new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            string userMail = "yazar@mail.com"; // oturumdan User.Identity.Name de olabilir
            var unread = mm.GetListInbox().Where(x => x.IsRead == false && x.ReceiverMail == userMail).Count();
            ViewBag.UnreadCount = unread;
            return PartialView();
        }
    }
}