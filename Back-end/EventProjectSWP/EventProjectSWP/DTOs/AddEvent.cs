using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace EventProjectSWP.DTOs
{
    public class AddEvent
    {
        public string eventName { get; set; }
        public string eventContent { get; set; }
        public DateTime eventStart { get; set; }
        public DateTime eventEnd { get; set; }
        public bool eventStatus { get; set; }
        public string categoryID { get; set; }
        public string locationID { get; set; }
        public int adminID { get; set; }
        public string paymentUrl { get; set; }
        public int paymentFee { get; set; }
        //public IFormFile files { get; set; }
    }
}


