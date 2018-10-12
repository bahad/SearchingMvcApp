using mvcSearching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcSearching.Controllers
{
    public class HomeController : Controller
    {
        SearchDBEntities db = new SearchDBEntities();
        public ActionResult Index()
        {
            return View(db.Ogrencilers.ToList());
        }

        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Ogrenciler> ogrenci = new List<Ogrenciler>();
            if(SearchBy == "ID")
            {
                try
                   { 
                     int Id = Convert.ToInt32(SearchValue);
                     ogrenci = db.Ogrencilers.Where(x => x.id == Id || SearchValue == null).ToList();
                   }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not ID",SearchValue);                   
                }
                return Json(ogrenci, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ogrenci = db.Ogrencilers.Where(x => x.isim.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(ogrenci, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}