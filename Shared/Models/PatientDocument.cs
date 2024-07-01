using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Models;

public class PatientDocument : IEntityTypeConfiguration<PatientDocument>
{
       public Guid Id { get; private set; }
       public Patient Patient { get; set; }
       public Guid PatientId { get; set; }
       public string FileName { get; set; }
       public byte[] FileContent { get; set; }
       public DateTime UploadDate { get; set; } = DateTime.Now;

       public void Configure(EntityTypeBuilder<PatientDocument> builder)
       {
              builder.HasKey(pd => pd.Id);

              builder.Property(pd => pd.FileName)
                     .IsRequired()
                     .HasMaxLength(255);

              builder.Property(pd => pd.FileContent)
                     .IsRequired();

              builder.Property(pd => pd.UploadDate)
                     .IsRequired();

              builder.HasOne(pd => pd.Patient)
                     .WithMany(p => p.Documents)
                     .HasForeignKey(pd => pd.PatientId);
       }
}
