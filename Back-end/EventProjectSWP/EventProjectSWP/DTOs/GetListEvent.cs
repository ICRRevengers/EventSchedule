using System;

namespace EventProjectSWP.DTOs
{
    public class GetListEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public bool EventStatus { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string LocationDetail { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public int PaymentFee { get; set; }
        public string PaymentUrl { get; set; }
        public string CategoryName { get; set; }
        public bool CanFeedBack { get; set; }
    }
}
