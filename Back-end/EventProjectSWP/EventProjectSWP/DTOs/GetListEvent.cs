using System;

namespace EventProjectSWP.DTOs
{
    public class GetListEvent
    {
        public int eventID { get; set; }
        public string eventName { get; set; }
        public string eventContent { get; set; }
        public bool eventStatus { get; set; }
        public DateTime eventStart { get; set; }
        public DateTime eventEnd { get; set; }
        public string locationDetail { get; set; }
        public int adminId { get; set; }
        public string adminName { get; set; }
        public int paymentFee { get; set; }
        public string paymentUrl { get; set; }
        public string categoryName { get; set; }
        public bool canFeedBack { get; set; }
    }
}
