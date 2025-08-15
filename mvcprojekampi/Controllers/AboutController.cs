using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var abouvalues = abm.GetList();
            return View(abouvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult MakeActive(int id)
        {
            var value = abm.GetByID(id);
            value.AboutStatus = true;
            abm.AboutUpdate(value);
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var value = abm.GetByID(id);
            value.AboutStatus = false;
            abm.AboutUpdate(value);
            return RedirectToAction("Index");
        }
    }
}