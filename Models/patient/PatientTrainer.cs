using Healthcare_platform.Models.professionals;

namespace Healthcare_platform.Models.patient
{
    public class PatientTrainer
    {
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }

}