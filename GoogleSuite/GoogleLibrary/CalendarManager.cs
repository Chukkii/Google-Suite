using System;
using Google.GData.Calendar;

namespace GoogleLibrary
{
    public class CalendarManager
    {
        private CalendarService _myService;
        private string _userID;
        private string _password;

        public CalendarManager(string email, string password)
        {
            _userID = email;
            _password = password;
            _myService = new CalendarService("Bruce's Application");
            _myService.setUserCredentials(_userID, _password);
        }

        public CalendarFeed GetAllCalendars()
        {
            CalendarQuery query = new CalendarQuery();
            query.Uri = new Uri("http://www.google.com/calendar/feeds/default/owncalendars/full");
            CalendarFeed resultFeed = _myService.Query(query);
            return resultFeed;
        }

        public EventFeed GetAllCalendarEvents()
        {
            EventQuery query = new EventQuery();
            query.Uri = new Uri("https://www.google.com/calendar/feeds/" + _userID + "/private/full");
            EventFeed resultFeed = _myService.Query(query);
            return resultFeed;
        }
    }
}