using System;

namespace EventProjectSWP.DTOs
{
    public class AddFeedback
    {
        public string comment { get; set; }
        public string rating { get; set; }
        public string eventId { get; set; }
        public string userId { get; set; }
    }
}
