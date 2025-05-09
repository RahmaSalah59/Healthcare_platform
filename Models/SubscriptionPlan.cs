using Healthcare_platform.Models.professionals;

namespace Healthcare_platform.Models
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int MaxPatients { get; set; }

        public Doctor Doctor { get; set; }  
        public Nutritionist Nutritionist { get; set; }
        public Trainer Trainer { get; set; }
    }
}