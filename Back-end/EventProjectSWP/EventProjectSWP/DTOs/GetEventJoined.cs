namespace EventProjectSWP.DTOs
{
    public class GetEventJoined
    {
        public int users_id { get; set; }
        public string users_name { get; set; }
        public string users_phone { get; set; }
        public string users_address { get; set; }
        public string users_email { get; set; }
        public string date_participated { get; set; }
        public string event_name { get; set; }
        public string event_id { get; set; }
        public bool is_feedback { get; set; }
    }
}
