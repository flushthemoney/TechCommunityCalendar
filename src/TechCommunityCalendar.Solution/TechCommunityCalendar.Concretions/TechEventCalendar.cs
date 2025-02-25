﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechCommunityCalendar.Enums;
using TechCommunityCalendar.Interfaces;

namespace TechCommunityCalendar.Concretions
{
    public class TechEventCalendar
    {
        public static IEnumerable<ITechEvent> GetCurrentEvents(IEnumerable<ITechEvent> events)
        {
            return events.Where(x =>
                DateTime.Now.Date >= x.StartDate // It is or after the start date
                && DateTime.Now <= x.EndDate // And it is or before the end date
                || DateTime.Now.Date == x.StartDate.Date) // To catch short events today
                    .OrderByDescending(x => x.StartDate);
        }

        public static IEnumerable<ITechEvent> GetUpcomingEvents(IEnumerable<ITechEvent> events)
        {
            return events.Where(x => x.StartDate.Date > DateTime.Now.Date  // Future events
                && x.StartDate.Date <= DateTime.Now.AddDays(30)) // No more than 30 days in the future
                    .OrderBy(x => x.StartDate);
        }

        public static IEnumerable<ITechEvent> GetRecentEvents(IEnumerable<ITechEvent> events, int totalDays = 30)
        {
            return events.Where(x => DateTime.Now.Date > x.EndDate
                && DateTime.Now.Date.Subtract(x.EndDate).TotalDays <= totalDays)
                    .OrderByDescending(x => x.StartDate);
        }

        public static IEnumerable<ITechEvent> Search(string searchTerm, IEnumerable<ITechEvent> events)
        {
            return events.Where(x=>
                x.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                || x.Country.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                || x.City.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                ).OrderByDescending(x => x.StartDate);
        }

        public static string GetEventTypeIcon(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Call_For_Papers:
                    return "📣";

                case EventType.Conference:
                    return "🧠";

                case EventType.Hackathon:
                    return "👩‍💻";

                case EventType.Meetup:
                    return "🤝";

                case EventType.Website:
                    return "💻";
            }

            return string.Empty;
        }
    }
}
