namespace Healthcare_platform.Models.patient
{

    public class PatientReport
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public DateTime ReportDate { get; set; }
        public string MealDescription { get; set; }
        public string ExerciseDescription { get; set; }
        public int SleepHours { get; set; }
        public int WaterIntake { get; set; }
        public string Notes { get; set; }

        public Patient Patient { get; set; }
    }
}
