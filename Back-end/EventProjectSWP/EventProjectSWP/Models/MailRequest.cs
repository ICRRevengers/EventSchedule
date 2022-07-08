using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EventProjectSWP.Models
{
    public class MailRequest
    {
        public string toEmail { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<IFormFile> attachments { get; set; }
    }
}
