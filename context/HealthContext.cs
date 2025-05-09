using Healthcare_platform.Models;
using Healthcare_platform.Models.patient;
using Healthcare_platform.Models.professionals;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Healthcare_platform.context
{
    public class HealthContext : IdentityDbContext<ApplicationUser>
    {
        public HealthContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HealthCare_platform;Integrated Security=True; Trust Server Certificate = True");
        }

        public HealthContext(DbContextOptions<HealthContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Nutritionist> Nutritionists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDoctor> PatientDoctors { get; set; }
        public DbSet<PatientTrainer> PatientTrainers { get; set; }
        public DbSet<PatientNutritionist> PatientNutritionists { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ApplicationUser config
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.firstname).HasMaxLength(100);
                entity.Property(u => u.lastname).HasMaxLength(100);
                entity.Property(u => u.Gender).HasMaxLength(10);
                entity.Property(u => u.ProfileImageUrl).HasMaxLength(500);
                entity.Property(u => u.Role)
                      .HasConversion<string>()
                      .IsRequired()
                      .HasMaxLength(20);
            });

            // Doctor
            builder.Entity<Doctor>(entity =>
            {
                entity.HasOne(d => d.User)
                      .WithOne(u => u.Doctor)
                      .HasForeignKey<Doctor>(d => d.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.SubscriptionPlan)
                      .WithOne(sp => sp.Doctor)
                      .HasForeignKey<Doctor>(d => d.SubscriptionPlanId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Trainer
            builder.Entity<Trainer>(entity =>
            {
                entity.HasOne(t => t.User)
                      .WithOne(u => u.Trainer)
                      .HasForeignKey<Trainer>(t => t.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.SubscriptionPlan)
                      .WithOne(sp => sp.Trainer)
                      .HasForeignKey<Trainer>(t => t.SubscriptionPlanId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Nutritionist
            builder.Entity<Nutritionist>(entity =>
            {
                entity.HasOne(n => n.User)
                      .WithOne(u => u.Nutritionist)
                      .HasForeignKey<Nutritionist>(n => n.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.SubscriptionPlan)
                      .WithOne(sp => sp.Nutritionist)
                      .HasForeignKey<Nutritionist>(n => n.SubscriptionPlanId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Patient
            builder.Entity<Patient>(entity =>
            {
                entity.HasOne(p => p.User)
                      .WithOne(u => u.Patient)
                      .HasForeignKey<Patient>(p => p.Id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // PatientDoctor
            builder.Entity<PatientDoctor>()
                .HasKey(pd => new { pd.PatientId, pd.DoctorId });

            builder.Entity<PatientDoctor>()
                .HasOne(pd => pd.Patient)
                .WithMany(p => p.PatientDoctors)
                .HasForeignKey(pd => pd.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PatientDoctor>()
                .HasOne(pd => pd.Doctor)
                .WithMany(d => d.PatientDoctors)
                .HasForeignKey(pd => pd.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            // PatientTrainer
            builder.Entity<PatientTrainer>()
                .HasKey(pt => new { pt.PatientId, pt.TrainerId });

            builder.Entity<PatientTrainer>()
                .HasOne(pt => pt.Patient)
                .WithMany(p => p.PatientTrainers)
                .HasForeignKey(pt => pt.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PatientTrainer>()
                .HasOne(pt => pt.Trainer)
                .WithMany(t => t.PatientTrainers)
                .HasForeignKey(pt => pt.TrainerId)
                .OnDelete(DeleteBehavior.NoAction);

            // PatientNutritionist
            builder.Entity<PatientNutritionist>()
                .HasKey(pn => new { pn.PatientId, pn.NutritionistId });

            builder.Entity<PatientNutritionist>()
                .HasOne(pn => pn.Patient)
                .WithMany(p => p.PatientNutritionists)
                .HasForeignKey(pn => pn.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PatientNutritionist>()
                .HasOne(pn => pn.Nutritionist)
                .WithMany(n => n.PatientNutritionists)
                .HasForeignKey(pn => pn.NutritionistId)
                .OnDelete(DeleteBehavior.NoAction);

            // Messages
            builder.Entity<Message>(entity =>
            {
                entity.HasOne(m => m.Sender)
                      .WithMany()
                      .HasForeignKey(m => m.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Receiver)
                      .WithMany()
                      .HasForeignKey(m => m.ReceiverId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
