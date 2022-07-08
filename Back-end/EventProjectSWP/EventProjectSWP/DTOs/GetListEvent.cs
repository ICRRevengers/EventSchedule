using System;

namespace EventProjectSWP.DTOs
{
    public class GetListEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string CreatedBy { get; set; }
        public string EventCode { get; set; }
        public bool EventStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public string CategoryID { get; set; }
        public string LocationID { get; set; }
        public int AdminID { get; set; }
        public bool CanFeedBack { get; set; }
    }
}
