namespace EventProjectSWP.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentUrl { get; set; }
        public int PaymentFee { get; set; }
        public string PaymentDetail { get; set; }
        public int AdminId { get; set; }

    }
}
