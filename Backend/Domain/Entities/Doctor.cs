using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Enums;

namespace Shared.Entities;

public class Doctor : UserBase, IEntityTypeConfiguration<Doctor>
{
       public string MedicalLicenseNumber { get; set; }
       public string Specialty { get; set; }
       public string OfficeNumber { get; set; }
       public Clinic Clinic { get; set; }
       public Guid ClinicId { get; set; }
       public List<DoctorSchedule> DoctorSchedules { get; set; }
       public List<Vacation> Vacations { get; set; }
       public List<Appointment> Appointments { get; set; }

       public Doctor()
       {
              Role = UserRole.Doctor;
       }

       public void Configure(EntityTypeBuilder<Doctor> builder)
       {
              new UserBaseConfiguration<Doctor>().Configure(builder);

              builder.Property(d => d.MedicalLicenseNumber)
                     .IsRequired()
                     .HasMaxLength(50);

              builder.Property(d => d.Specialty)
                     .IsRequired()
                     .HasMaxLength(100);

              builder.Property(d => d.OfficeNumber)
                     .HasMaxLength(10);

              builder.HasOne(d => d.Clinic)
                     .WithMany(c => c.Doctors)
                     .HasForeignKey(d => d.ClinicId);

              builder.HasMany(d => d.DoctorSchedules)
                     .WithOne(a => a.Doctor)
                     .HasForeignKey(a => a.DoctorId);

              builder.HasMany(d => d.Vacations)
                     .WithOne(v => v.Doctor)
                     .HasForeignKey(v => v.DoctorId);

              builder.HasMany(d => d.Appointments)
                     .WithOne(a => a.Doctor)
                     .HasForeignKey(a => a.DoctorId);
       }
}