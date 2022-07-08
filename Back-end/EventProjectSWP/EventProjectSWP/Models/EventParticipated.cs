using System;

namespace EventProjectSWP.Models
{
    public class EventParticipated
    {
        public int eventID { get; set; }
        public string userID { get; set; }
        public DateTime dateParticipated { get; set; }
        public bool paymentStatus { get; set; }
        public bool users_status { get; set; }

    }
}
