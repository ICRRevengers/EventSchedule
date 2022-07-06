using System;

namespace EventProjectSWP.DTOs
{
    public class AddFeedback
    {
        public string Comment { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }
    }
}
