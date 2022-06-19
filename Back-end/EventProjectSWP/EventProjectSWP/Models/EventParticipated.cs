using System;

namespace EventProjectSWP.Models
{
    public class EventParticipated
    {
        public string EventID { get; set; }
        public string UserID { get; set; }
        public DateTime DateParticipated { get; set; }
        public bool PaymentStatus { get; set; }

    }
}
