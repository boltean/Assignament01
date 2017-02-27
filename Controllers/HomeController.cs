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

            var firstDay = "";
            var lastDay = "";


            if ((int)System.DateTime.Now.DayOfWeek == 0)
            {
                firstDay = DateTime.Now.ToShortDateString() + " 12:00";
            }
            else
            {
                firstDay = DateTime.Now.AddDays(1 - (int)System.DateTime.Now.DayOfWeek).ToShortDateString() + " 12:00";
            }


            if ((int)System.DateTime.Now.DayOfWeek == 0)
            {
                lastDay = System.DateTime.Now.ToShortDateString() + " 23:59";
            }
            else
            {
                lastDay = (DateTime.Now.AddDays(7 - (int)System.DateTime.Now.DayOfWeek)).ToShortDateString() + " 23:59";
            }
            
            DateTime maxDate = DateTime.Parse(lastDay);

            ViewBag.DateUntil = maxDate;
            DateTime minDate = Convert.ToDateTime(firstDay);

            var events = from e in db.Events.Include(a => a.Activity)
                         where e.EventFrom >= minDate && e.EventTo <= maxDate && e.IsActive
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