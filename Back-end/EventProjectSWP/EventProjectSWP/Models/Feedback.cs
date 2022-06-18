using System;

namespace EventProjectSWP.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }

    }
}
