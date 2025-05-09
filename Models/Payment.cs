namespace Healthcare_platform.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }

        public ApplicationUser User { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
