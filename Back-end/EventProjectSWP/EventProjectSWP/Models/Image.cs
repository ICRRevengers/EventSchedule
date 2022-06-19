using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EventProjectSWP.Models
{
    public class Image
    {
        public string ImageId { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string EventId { get; set; }

    }
}
