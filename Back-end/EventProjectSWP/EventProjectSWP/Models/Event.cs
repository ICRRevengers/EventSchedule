using System;

namespace EventProjectSWP.Models
{
    public class Event
    {
        public string EventID { get; set; }
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public DateTime EventTimeline { get; set; }
        public string CreatedBy { get; set; }
        public string EventCode { get; set; }
        public bool EventStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public string CategoryID { get; set; }
        public string LocationID { get; set; }
        public int ClubID { get; set; }

    }
}
