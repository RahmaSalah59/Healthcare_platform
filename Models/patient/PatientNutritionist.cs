using Healthcare_platform.Models.professionals;

namespace Healthcare_platform.Models.patient
{
    public class PatientNutritionist
    {
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string NutritionistId { get; set; }
        public Nutritionist Nutritionist { get; set; }
    }
}