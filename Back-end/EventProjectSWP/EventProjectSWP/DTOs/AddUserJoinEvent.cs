using System;

namespace EventProjectSWP.DTOs
{
    public class AddUserJoinEvent
    {
        public int eventID { get; set; }
        public string userID { get; set; }
        public DateTime dateParticipated { get; set; }
    }
}
