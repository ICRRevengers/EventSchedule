using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace EventProjectSWP.DTOs
{
    public class AddEvent
    {
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string CreatedBy { get; set; }
        public string EventCode { get; set; }
        public bool EventStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public string CategoryID { get; set; }
        public string LocationID { get; set; }
        public int AdminID { get; set; }
        public IFormFile files { get; set; }
    }
}


