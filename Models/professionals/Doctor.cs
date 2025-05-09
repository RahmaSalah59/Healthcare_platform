using Healthcare_platform.Models.patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Healthcare_platform.Models.professionals
{
    public class Doctor
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Bio { get; set; }

        [Required]
        [Range(0, 100)]
        public int Experience { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        public List<string> Certificates { get; set; } = new List<string>();

        [Required]
        public ApplicationUser User { get; set; }

        public SubscriptionPlan SubscriptionPlan { get; set; }

        public int? SubscriptionPlanId { get; set; }

        public ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}