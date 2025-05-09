namespace Healthcare_platform.Models.patient
{

    public class Patient
    {
        public string Id { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Goals { get; set; }
        public string SubscriptionStatus { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<PatientDoctor> PatientDoctors { get; set; }
        public ICollection<PatientTrainer> PatientTrainers { get; set; }
        public ICollection<PatientNutritionist> PatientNutritionists { get; set; }
    }
}