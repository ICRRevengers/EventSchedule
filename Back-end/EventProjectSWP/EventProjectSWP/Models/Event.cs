using System;

namespace EventProjectSWP.Models
{
    public class Event
    {
        public int eventID { get; set; }
        public string eventName { get; set; }
        public string eventContent { get; set; }
        public DateTime eventStart { get; set; }
        public DateTime eventEnd { get; set; }
        public string createdBy { get; set; }
        public string eventCode { get; set; }
        public bool eventStatus { get; set; }
        public bool paymentStatus { get; set; }
        public string categoryID { get; set; }
        public string locationID { get; set; }
        public int adminID { get; set; }

    }
}
