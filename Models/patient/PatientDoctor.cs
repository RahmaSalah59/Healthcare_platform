using Healthcare_platform.Models.professionals;

namespace Healthcare_platform.Models.patient
{
    public class PatientDoctor
    {
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }

}