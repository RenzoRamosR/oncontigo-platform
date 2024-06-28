using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;


namespace oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Medicine>().ToTable("medicines");
            builder.Entity<Medicine>().HasKey(m => m.Id);
            builder.Entity<Medicine>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Medicine>().OwnsOne(m => m.Information,
                mI =>
                {
                    mI.WithOwner().HasForeignKey("Id");
                    mI.Property(mI => mI.Name).HasColumnName("MedicineName");
                    mI.Property(mI=> mI.Description).HasColumnName("MedicineDescription");
                });

            builder.Entity<PatientFollowUp>().ToTable("patient_follow_ups");  // Llave primaria

            builder.Entity<PatientFollowUp>().HasKey(p => p.Id);
            builder.Entity<PatientFollowUp>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<PatientFollowUp>()
                .Property(pf => pf.Status)
                .IsRequired();

            builder.Entity<PatientFollowUp>()
                .HasMany(pf => pf.Medicines)
                .WithOne(m => m.PatientFollowUp)
                .HasForeignKey(m => m.PatientFollowUpId);

            builder.Entity<PatientFollowUp>()
                .OwnsOne(p => p.PatientId,
                a =>
                {
                    a.WithOwner().HasForeignKey("Id");
                    a.Property(a => a.patientId).HasColumnName("patient");
                });



            builder.Entity<PatientFollowUp>()
                .OwnsOne(p => p.DoctorId,
                a =>
                {
                    a.WithOwner().HasForeignKey("Id");
                    a.Property(a => a.doctorId).HasColumnName("doctor");
                });


            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(c => c.Id);
            builder.Entity<User>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(c => c.PasswordHash).IsRequired();

            builder.Entity<Doctor>().ToTable("Doctors");
            builder.Entity<Doctor>().HasKey(c => c.Id);
            builder.Entity<Doctor>().Property(c => c.Id).IsRequired();


            builder.Entity<Patient>().ToTable("Patients");
            builder.Entity<Patient>().HasKey(c => c.Id);
            builder.Entity<Patient>().Property(c => c.Id).IsRequired();



            builder.UseSnakeCaseNamingConvention();

        }
    }
}
