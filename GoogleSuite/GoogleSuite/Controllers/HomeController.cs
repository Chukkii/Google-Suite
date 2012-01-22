using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.GData.Calendar;
using System.Web.Mvc;
using System.Web.Services.Description;
using GoogleLibrary;

namespace GoogleSuite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private CalendarManager _calendarManager = new CalendarManager("Bruce@Brucechoi.com", "stuffis11");

        public ActionResult Index()
        {
            EventFeed eventFeed = _calendarManager.GetAllCalendarEvents();
            List<EventEntry> entries = new List<EventEntry>();

            foreach (EventEntry eventEntry in eventFeed.Entries)
            {
                entries.Add(eventEntry);
            }

            return View(entries);
        }

    }
}
