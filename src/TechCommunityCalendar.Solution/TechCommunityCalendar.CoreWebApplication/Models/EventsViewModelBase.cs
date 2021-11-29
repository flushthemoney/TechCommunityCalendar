﻿using System.Collections.Generic;
using System.Linq;
using TechCommunityCalendar.Interfaces;

namespace TechCommunityCalendar.CoreWebApplication.Models
{
    public abstract class EventsViewModelBase
    {
        public IEnumerable<ITechEvent> Events { get; set; } = new List<ITechEvent>();
        public IEnumerable<ITechEvent> UpcomingEvents { get; set; } = new List<ITechEvent>();
        public IEnumerable<ITechEvent> RecentEvents { get; set; } = new List<ITechEvent>();

        public int EventsCount { get { return UpcomingEvents.Count(); } }
        public int UpcomingEventsCount { get { return UpcomingEvents.Count(); } }
        public int RecentEventsCount { get { return UpcomingEvents.Count(); } }
    }
}
