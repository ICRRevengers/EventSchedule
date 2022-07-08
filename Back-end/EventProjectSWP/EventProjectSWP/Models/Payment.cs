namespace EventProjectSWP.Models
{
    public class Payment
    {
        public int paymentId { get; set; }
        public string paymentUrl { get; set; }
        public int paymentFee { get; set; }
        public string paymentDetail { get; set; }
        public int adminId { get; set; }

    }
}
