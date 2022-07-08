using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EventProjectSWP.Models
{
    public class Image
    {
        public int imageId { get; set; }
        public string imageUrl { get; set; }
        public string imageName { get; set; }
        public int eventId { get; set; }

    }
}
