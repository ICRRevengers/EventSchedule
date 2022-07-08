using System;

namespace EventProjectSWP.Models
{
    public class Feedback
    {
        public int feedbackId { get; set; }
        public string comment { get; set; }
        public string rating { get; set; }
        public DateTime createdTime { get; set; }
        public string eventId { get; set; }
        public string userId { get; set; }

    }
}
