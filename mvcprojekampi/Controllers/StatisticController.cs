
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace mvcprojekampi.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categories = cm.GetList();

            ViewBag.TotalCategories = categories.Count();
            ViewBag.HasSoftwareCategory = categories.Any(x => x.CategoryName.ToLower() == "software") ? "Var" : "Yok";
            ViewBag.CategoryWithA = categories.Count(x => x.CategoryName.ToLower().Contains("a"));
            ViewBag.LongestCategory = categories.OrderByDescending(x => x.CategoryName.Length).FirstOrDefault()?.CategoryName;
            ViewBag.StatusDifference = categories.Count(x => x.CategoryStatus == true) - categories.Count(x => x.CategoryStatus == false);

            return View();
        }
    }
}
