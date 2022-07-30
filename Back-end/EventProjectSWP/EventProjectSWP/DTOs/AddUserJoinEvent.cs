using System;

namespace EventProjectSWP.DTOs
{
    public class AddUserJoinEvent
    {
        public int eventID { get; set; }
        public string userID { get; set; }
        public DateTime dateParticipated { get; set; }
        public bool payment_status { get; set; }
        public bool users_status { get; set; }
    }
}
