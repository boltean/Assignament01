using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithWebSite.Models;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events1
        public ActionResult Index()
        {
            //var events = db.Events.Include(p => p.Activity);



             var sevenDays = (DateTime.Now.AddDays(8 - (int)System.DateTime.Now.DayOfWeek)).ToShortDateString();
            //var sevenDays = (DateTime.Now.AddDays(18 - (int)System.DateTime.Now.DayOfWeek)).ToShortDateString();

            DateTime dateValue = DateTime.Parse(sevenDays);
            ViewBag.DateUntil = dateValue;
            DateTime minDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            var events = from e in db.Events.Include(a => a.Activity)
                         where e.EventFrom >= minDate  && e.EventTo <=dateValue && e.IsActive
                         orderby e.EventFrom ascending
                         select e;
            return View(events.ToList());
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