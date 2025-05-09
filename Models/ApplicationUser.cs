using Healthcare_platform.Models.patient;
using Healthcare_platform.Models.professionals;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace Healthcare_platform.Models
{
    public enum UserRole
        {
            Admin ,
            Doctor,
            Trainer,
            Nutritionist,
            Patient
        }

        public class ApplicationUser : IdentityUser
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string Gender { get; set; } = string.Empty;
            public int Age { get; set; } = 0;
            public string ProfileImageUrl { get; set; } = string.Empty;
            public UserRole Role { get; set; }

            public Patient Patient { get; set; }
            public Doctor Doctor { get; set; }
            public Trainer Trainer { get; set; }
            public Nutritionist Nutritionist { get; set; }
        }
    }

