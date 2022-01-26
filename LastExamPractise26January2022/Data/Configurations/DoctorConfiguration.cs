using LastExamPractise26January2022.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LastExamPractise26January2022.Data.Configurations
{
    public class DoctorConfiguration :IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.SurName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Position).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p=>p.IsDeleted).HasDefaultValue(false);
        }
    }

}
