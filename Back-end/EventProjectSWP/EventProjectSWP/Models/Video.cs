using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Models
{
    public class Video
    {
        public int videoId { get; set; }
        public string videoUrl { get; set; }
        public int eventId { get; set; }
        public string videoName { get; set; }
    }
}
