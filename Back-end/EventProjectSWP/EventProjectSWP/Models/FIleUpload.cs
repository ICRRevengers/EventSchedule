using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Models
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
