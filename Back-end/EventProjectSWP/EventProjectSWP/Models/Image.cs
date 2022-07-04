using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EventProjectSWP.Models
{
    public class Image
    {
        
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public int EventId { get; set; }

    }
}
