using mvcprojekampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct=new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName="Yazılım",
                CategoryCount=8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Film",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Dizi",
                CategoryCount = 1
            });
            return ct;

        }
    }
}