using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoUrl { get; set; }
        public int EventId { get; set; }
        public string VideoName { get; set; }
    }
}
