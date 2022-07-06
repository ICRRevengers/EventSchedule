using System;

namespace EventProjectSWP.Models
{
    public class EventParticipated
    {
        public int EventID { get; set; }
        public string UserID { get; set; }
        public DateTime DateParticipated { get; set; }
        public bool PaymentStatus { get; set; }
        public bool users_status { get; set; }

    }
}
